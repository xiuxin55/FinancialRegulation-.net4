using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FundsRegulatoryClient.UserManageSrv;
using FinancialRegulation.ViewModel;
using System.Data;
using FundsRegulatoryClient;
using System.Windows;
using Encryption4Net;

namespace FinancialRegulation.UserCotrol
{
    /// <summary>
    ///用户管理
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class UserMaintenanceVM : BaseManageVM<FundsRegulatoryClient.UserManageSrv.UserInfo>
    {

        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            AddCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddExecute);
            ModifyCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ModifyExecute);
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            DeleteCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DeleteExecute);
            AuthorizeCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AuthorizeExecute);
            NewFlushCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LoadData);
            LockCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LockExecute);
            UserMaintainList = new ObservableCollection<FundsRegulatoryClient.UserManageSrv.UserInfo>();
        }
        private List<FundsRegulatoryClient.UserManageSrv.UserInfo> CacheUserList = new List<FundsRegulatoryClient.UserManageSrv.UserInfo>();
        ObservableCollection<FundsRegulatoryClient.UserManageSrv.UserInfo> _UserMaintainList;
        public ObservableCollection<FundsRegulatoryClient.UserManageSrv.UserInfo> UserMaintainList
        {
            get
            {
                return _UserMaintainList;
            }
            set
            {
                _UserMaintainList = value;
                RaisePropertyChanged("UserMaintainList");
            }

        }
        FundsRegulatoryClient.UserManageSrv.UserInfo _SelectUser;
        public FundsRegulatoryClient.UserManageSrv.UserInfo SelectUser
        {
            get
            {
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("SelectUser");
            }
        }
        public override void LoadData()
        {
            UserMaintainList.Clear();
            UserMaintainList = new ObservableCollection<FundsRegulatoryClient.UserManageSrv.UserInfo>(GetData());


        }
        private List<FundsRegulatoryClient.UserManageSrv.UserInfo> GetData()
        {
            DataSet dsAllUser = UserManageClient.Current.GetAllUser();
            return DataSetToModel.UserInfoToModel(dsAllUser,0);
        }
        #endregion 构造加载

        #region 变量属性

        private string _condition;

        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition
        {
            get { return _condition; }
            set
            {
                _condition = value;
                RaisePropertyChanged("Condition");
            }
        }

        #endregion 变量属性

        #region 命令定义

   
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _authorizeCommand;//授权命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand newFlushCommand;//新的刷新命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand _LockCommand;//锁定解锁命令
        public Microsoft.Practices.Prism.Commands.DelegateCommand LockCommand
        {
            get { return _LockCommand; }
            set { _LockCommand = value; this.RaisePropertyChanged("LockCommand"); }
        }


        public Microsoft.Practices.Prism.Commands.DelegateCommand NewFlushCommand
        {
            get { return newFlushCommand; }
            set { newFlushCommand = value; this.RaisePropertyChanged("NewFlushCommand"); }
        }
        

        /// <summary>
        /// 授权命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand AuthorizeCommand
        {
            get { return _authorizeCommand; }
            set { _authorizeCommand = value; }
        }

       
        /// <summary>
        /// 查询筛选
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand SearchCommand
        {
            get
            {
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }

        #endregion 命令定义

        #region 命令方法
        public override void AddExecute()
        {
            UserInfo di = new UserInfo();
            di.VM.SelectUser = new FundsRegulatoryClient.UserManageSrv.UserInfo();
            di.VM.SelectUser.UserId = Guid.NewGuid().ToString();
            di.VM.IsAdd = true;
            di.ShowDialog();
            LoadData();
        }
        public override void ModifyExecute()
        {
            UserInfo di = new UserInfo();
            di.VM.SelectUser = SelectUser;
            di.VM.LoadOwnDutyList();
            di.VM.IsAdd = false;
            di.ShowDialog();
            LoadData();
            
        }
        public override void DeleteExecute()
        {
            if(SelectUser!=null)
            {
                if (System.Windows.Forms.MessageBox.Show("是否删除编号为 " + SelectUser.UserCode + " 的用户信息", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (UserManageClient.Current.DeleteUserByID(SelectUser.UserId) == "1")
                    {
                        MessageBox.Show("删除成功！");
                        UserMaintainList.Remove(SelectUser);
                    }
                }
            }
        }
        private void SearchExecute()
        {
            UserMaintainList.Clear();
            if(Condition ==null)
            {
                UserMaintainList = new ObservableCollection<FundsRegulatoryClient.UserManageSrv.UserInfo>(GetData());
                return;
            }
            CacheUserList = GetData();
            foreach (var item in CacheUserList)
            {
                //if(item.UserCode.Contains(Condition) || item.UserName.Contains(Condition) || item.UserDescribe.Contains(Condition))
                //{
                //    UserMaintainList.Add(item.Clone());
                //}
            }
        }
        private void AuthorizeExecute()
        {
            if (SelectUser != null && SelectUser.UserId != null)
            {
                FunSetForm fsf = new FunSetForm(SelectUser.UserId);
                fsf.ShowDialog();
               
            }
        }
        /// <summary>
        /// 锁定解锁
        /// </summary>
        private void LockExecute()
        {
            string state = "0";
            if (SelectUser.State.Trim() == "停用")
                state = "1";
            if (UserManageClient.Current.UpdataStateByID(SelectUser.UserId, state) == "1")
            {
                
                MessageBox.Show("操作成功！");
                LoadData();
            }
        }
        #endregion 命令方法


    }

   
}