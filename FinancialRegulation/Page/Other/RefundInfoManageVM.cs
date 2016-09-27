using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using FinancialRegulation.ViewModel;
using System.Windows.Forms;
using FundsRegulatoryClient.RefunTradeSrv;

namespace FinancialRegulation.Page.Fund
{
    public class RefundInfoManageVM : BaseManageVM<RefundTrade>
    {
      
        public override void LoadCommand()
        {
            SearchCommand = new DelegateCommand(Search);
            RefundCommand = new DelegateCommand(RefundExecute);
         
          // DeleteCommand = new DelegateCommand(DeleteExecute);
        }
        public override void LoadData()
        {
            FlushExecute();
        }
        /// <summary>
        /// 客户端
        /// </summary>
        FundsRegulatoryClient.RefundTradeClient client = new FundsRegulatoryClient.RefundTradeClient();
        #region 属性
        private string fileName;
        /// <summary>
        /// 生成的文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string filePath;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string currentServerNo = null;
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string CurrentServerNo
        {
            get { return currentServerNo; }
            set
            {
                currentServerNo = value;
                this.RaisePropertyChanged("CurrentServerNo");
            }
        }

        private string currentCorp = null;

        public string CurrentCorp
        {
            get { return currentCorp; }
            set { currentCorp = value;
            this.RaisePropertyChanged("CurrentCorp");
            }
        }
        private string manageAccount = null;
        /// <summary>
        /// 监管账户
        /// </summary>
        public string ManageAccount
        {
            get { return manageAccount; }
            set
            {
                manageAccount = value;
                this.RaisePropertyChanged("ManageAccount");
            }
        }

        #endregion

        #region 命令
        public DelegateCommand SearchCommand { get; set; }
        
        public DelegateCommand RefundCommand { get; set; }
    
        #endregion

        #region 方法
        private void Search()
        {
            //if (string.IsNullOrEmpty(CurrentServerNo) && string.IsNullOrEmpty(CurrentCorp) && string.IsNullOrEmpty(ManageAccount))
            //{
            //    FlushExecute(); return;
            //}
            //FlushExecute();
            // List<UnknowBill> ub = new List<UnknowBill>();
            // if (!string.IsNullOrEmpty(CurrentServerNo))
            // {
            //     var result = from i in this.Models where (!string.IsNullOrEmpty(i.UB_BankSerialNum) && i.UB_BankSerialNum.Contains(CurrentServerNo)) select i;
            //     ub = result.ToList<UnknowBill>();
            // }
            //else { ub = this.Models.ToList<UnknowBill>(); }
            //if (!string.IsNullOrEmpty(CurrentCorp))
            //{
            //    var result = from i in ub where (!string.IsNullOrEmpty(i.UB_FirmName) && i.UB_FirmName.Contains(CurrentCorp)) select i;
            //    ub = result.ToList<UnknowBill>();
            //}
            //if (!string.IsNullOrEmpty(ManageAccount))
            //{
            //    var result = from i in ub where (!string.IsNullOrEmpty(i.UB_ManageAccount) && i.UB_ManageAccount.Contains(ManageAccount)) select i;
            //    ub = result.ToList<UnknowBill>();
            //}
            //ObservableCollection<UnknowBill> temp = new ObservableCollection<UnknowBill>();
            //ub.ForEach(p => temp.Add(p));
            //this.Models = temp;
        }

        private void RefundExecute()
        {

            Page.RefundInfoAddToEdit ukInfo = new RefundInfoAddToEdit(this.Models);
            ukInfo.ShowDialog();
        }
        public override void FlushExecute() 
        {
            this.Models.Clear();
            //总行可以查看所有
            if (VMHelp.PointCode == Tools.HelpClass.Current.MainWebSite)
            {
                this.Models = client.Selects();;
                return;
            }
            foreach (RefundTrade item in client.Selects())
            {
                if (item.Bankwebsite == VMHelp.PointCode)
                {
                    this.Models.Add(item);
                }
            }  
        }
        #endregion

    }
}
