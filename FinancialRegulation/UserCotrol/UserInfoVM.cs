using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.ViewModel;
using System.Data;
using FundsRegulatoryClient;
using System.Windows;
using MahApps.Metro.Controls;
using FundsRegulatoryClient.JG_BranchesSrv;
using Encryption4Net;

namespace FinancialRegulation.UserCotrol
{
    /// <summary>
    ///新建或修改职责
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class UserInfoVM : BaseManageVM<FundsRegulatoryClient.UserManageSrv.UserInfo>
    {
        /// <summary>
        /// 网点webservice
        /// </summary>
        public JG_BranchesClient WebsiteClient = JG_BranchesClient.Instance;
        Encryption ep = new Encryption();
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {

            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OkExecute);
            DutyAllocateCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DutyAllocateExecute);
            WebsiteList = WebsiteClient.Selects();
            
        }

        FundsRegulatoryClient.UserManageSrv.UserInfo _SelectUser;
        public FundsRegulatoryClient.UserManageSrv.UserInfo SelectUser
        {
            get
            {
                if (_SelectUser == null)
                {
                    _SelectUser = new FundsRegulatoryClient.UserManageSrv.UserInfo();
                }
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("SelectUser");
            }
        }

        #endregion 构造加载

        #region 变量属性
        private ObservableCollection<JG_BranchesInfo> websiteList;
        public ObservableCollection<JG_BranchesInfo> WebsiteList
        {
            get
            {
                return websiteList;
            }

            set
            {
                websiteList = value;
                RaisePropertyChanged("WebsiteList");
            }
        }
        public MetroWindow Owner { get; set; }


        private PasswordBox onePassword;
        /// <summary>
        /// 重复的密码
        /// </summary>
        public PasswordBox OnePassword
        {
            get
            {
                return onePassword;
            }

            set
            {
                onePassword = value;
            }
        }

        private PasswordBox repeatePassword;
        /// <summary>
        /// 重复的密码
        /// </summary>
        public PasswordBox RepeatePassword
        {
            get
            {
                return repeatePassword;
            }

            set
            {
                repeatePassword = value;
            }
        }

        ObservableCollection<DutyModel> _OwnDutyList;
        public ObservableCollection<DutyModel> OwnDutyList
        {
            get
            {
                return _OwnDutyList;
            }
            set
            {
                _OwnDutyList = value;
                RaisePropertyChanged("OwnDutyList");
            }

        }
        #endregion 变量属性

        #region 命令定义


        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }
        /// <summary>
        /// 职责分配命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand DutyAllocateCommand { get; set; }

        public bool IsAdd = true;
       


        #endregion 命令定义

        #region 命令方法
        public void OkExecute()
        {
            SelectUser.UserPwd = OnePassword.Password;
          
            if (string.IsNullOrWhiteSpace(SelectUser.UserCode))
            {
                MessageBox.Show("登录名不能为空");
                return;
            }
          
            if (string.IsNullOrWhiteSpace(SelectUser.UserName))
            {
                MessageBox.Show("用户姓名不能为空");
                return;
            }
           
            if (SelectUser.Ssq ==null )
            {
                MessageBox.Show("所属网点不能为空");
                return;
            }
           
            try
            {
                if (!IsAdd)
                {
                    if (SelectUser.UserPwd != RepeatePassword.Password)
                    {
                        MessageBox.Show("两次密码不一致");
                        return;
                    }
                    SelectUser.UserPwd = ep.EnCode(SelectUser.UserPwd);
                    if (UserManageClient.Current.UpdateUserByID(SelectUser) == "1")
                    {
                        MessageBox.Show("用户信息修改成功！");
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(SelectUser.UserPwd))
                    {
                        MessageBox.Show("登录密码不能为空");
                        return;
                    }
                    if (SelectUser.UserPwd != RepeatePassword.Password)
                    {
                        MessageBox.Show("两次密码不一致");
                        return;
                    }
                    SelectUser.UserPwd = ep.EnCode(SelectUser.UserPwd);
                    SelectUser.State = "1";
                    SelectUser.Sex = SelectUser.Sex ?? "男";
                    SelectUser.LinkTel = SelectUser.LinkTel ?? "";
                    SelectUser.Email = SelectUser.Email ?? "";
                    SelectUser.Describe = SelectUser.Describe ?? "";
                    if (UserManageClient.Current.InsertUser(SelectUser) == "1")
                    {
                        MessageBox.Show("用户信息提交成功！");
                    }
                }
                if (this.Owner !=null )
                {
                    this.Owner.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        private void DutyAllocateExecute()
        {
            DutySet  dl = new DutySet();
            dl.VM.UserID = SelectUser.UserId;
            dl.VM.InitialData();
            dl.ShowDialog();
            LoadOwnDutyList();
        }
        #endregion 命令方法
        public  void LoadOwnDutyList()
        {
            DataSet ds = UserDutyManagerClient.Current.GetUserDutyByID(SelectUser.UserId);
            OwnDutyList = new ObservableCollection<DutyModel>(DataSetToModel.UserDutyToModel(ds,0));
        }

    }
}