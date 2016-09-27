using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using FundsRegulatoryClient.JG_AccountManageSrv;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 账户查找
    /// </summary>
    class AccountSearchVM : BaseManageVM<JG_AccountManageInfo>
    {
        #region 构造函数
        public AccountSearchVM()
        {
        }

        public AccountSearchVM(Action<ObservableCollection<JG_AccountManageInfo>> likesearchCommand)
        {
            this.likesearchCommand = likesearchCommand;
        }
        #endregion
        #region 属性
        public Action<ObservableCollection<JG_AccountManageInfo>> likesearchCommand;
        /// <summary>
        /// 客户端访问对象
        /// </summary>
        public JG_AccountManageClient client = JG_AccountManageClient.Instance;
        private DateTime? dtBegin;
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? DtBegin
        {
            get { return dtBegin; }
            set { dtBegin = value; }
        }
        private DateTime? dtEnd;
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? DtEnd
        {
            get { return dtEnd; }
            set { dtEnd = value; }
        }
        #endregion
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            SearchCommand = new DelegateCommand(SearchExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #region 命令定义
        DelegateCommand searchCommand;
        /// <summary>
        /// 查找命令
        /// </summary>
        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }
        private DelegateCommand cancelCommand;
        /// <summary>
        /// 取消
        /// </summary>
        public DelegateCommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                RaisePropertyChanged("CancelCommand");
            }
        }
        #endregion
        #region 命令方法
        /// <summary>
        /// 查找命令
        /// </summary>
        private void SearchExecute()
        {
            this.Models = client.Select(CurrentObj);
            if (DtBegin != null && DtEnd != null)
            {
                var result = from i in this.Models
                             where (i.AM_CreateDate != null) && (i.AM_CreateDate >= DtBegin && i.AM_CreateDate <= DtEnd)
                             select i;
                List<JG_AccountManageInfo> temp =result.ToList<JG_AccountManageInfo>();
                ObservableCollection<JG_AccountManageInfo> oj = new ObservableCollection<JG_AccountManageInfo>();
                temp.ForEach(p => oj.Add(p));
                this.Models = oj;
            }   
            //List<JG_AccountManageInfo> temp = new List<JG_AccountManageInfo>();
            //foreach (JG_AccountManageInfo item in Models)
            //{
            //    temp.Add(item);
            //}
            //foreach (JG_AccountManageInfo item in temp)
            //{
            //    if (DtBegin != null && DtEnd != null)
            //    {
            //        if (item.AM_CreateDate != null)
            //        {
            //            if (item.AM_CreateDate >= DtBegin && item.AM_CreateDate <= DtEnd)
            //            { ;}
            //            else
            //            {
            //                this.Models.Remove(item);
            //            }
            //        }
            //    }
            //    else
            //    {
            //       // this.Models.Remove(item);
            //    }
            //}
            if (likesearchCommand != null)
            {
                likesearchCommand(Models);
            }
            if (windowClose != null) windowClose();
        }
        /// <summary>
        /// 取消命令
        /// </summary>
        public virtual void CancelExecute()
        {
            if (windowClose != null) windowClose();
        }
        #endregion



     
    }
}
