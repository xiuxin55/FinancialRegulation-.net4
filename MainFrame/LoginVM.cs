using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using BaseClient.LoginSrv;
using Common;
using System.Windows;
using BaseClient;

namespace MainFrame
{
    public class LoginVM:NotificationObject
    {
        public LoginVM()
        {
            ConfirmCommand = new DelegateCommand(new Action(Confirm));
            UpdatePwdCommand = new DelegateCommand(new Action(UpdatePwd));
            Refresh();
            lg = new Logger();
        }

        #region 命令

        public DelegateCommand ConfirmCommand{get; set;}
        public DelegateCommand UpdatePwdCommand { get; set; }
        public Action CloseAction { get; set; }


        #endregion
        public void SetConfig()
        {
            //CommonData.Instance.SysConfig = FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG;
        }

        #region 属性


        Common.Logger lg;
        /// <summary>
        /// 申请属性
        /// </summary>
        private UserInfo ui;

        public UserInfo Ui
        {
            get { return ui; }
            set
            {
                ui = value;
                this.RaisePropertyChanged("UesrInfo");
            }
        }

        public List<BaseClient.LoginSrv.MenuItem> ListmenuItem { get; set; }





        /// <summary>
        /// 登录用户
        /// </summary>
        private List<UserInfo> listCheckUesrInfo;

        public List<UserInfo> ListCheckUesrInfo
        {
            get { return listCheckUesrInfo; }
            set
            {
                listCheckUesrInfo = value;
                this.RaisePropertyChanged("CheckUserInfo");
            }
        }



        #endregion


        #region 方法

        //获得子集
        private void GetSubMenuItem(MenuItem[] mis,MenuItem mi)
        {
            mi.Children = mis.Where(p => p.Parent == mi.ID).ToArray<MenuItem>();
            foreach (MenuItem item in mi.Children)
            {
                GetSubMenuItem(mis, item);
            }
        }

        private List<MenuItem> GetItems(MenuItem[] mi)
        {
            List<MenuItem> lmItem = mi.Where(p => p.Layer == 1).ToList<MenuItem>();
            foreach (MenuItem item in lmItem)
            {
                GetSubMenuItem(mi, item);
            }
            return lmItem;
        }


        //实例化
        private void Refresh()
        {
            ui = new UserInfo();
        }


        /// <summary>
        /// 验证
        /// </summary>
        private bool Check()
        {
            //登录信息
            if (ui.UserCode == null)
            {
                MessageBox.Show("用户名不能为空！");
                return false;
            }
            if (ui.UserPwd == null)
            {
                MessageBox.Show("密码不能为空！");
                return false;
            }

            return true;
        }


        private bool CheckLogin()
        {
            //加密
            Encryption4Net.Encryption encryption = new Encryption4Net.Encryption();
            string inputPsw = encryption.EnCode(ui.UserPwd);
            ui.UserPwd = inputPsw;
            encryption = null;

            listCheckUesrInfo = LoginClient.Current.CheckUserInfo(ui);

            if (listCheckUesrInfo.Count == 0)
            {
                MessageBox.Show("用户名或密码不存在!");
                return false;
            }
            return true;
        }


        /// <summary>
        /// 读取客户端配置信息
        /// </summary>
        private void ReadClientConfig()
        {
            //Web引用参数
            String[] values = DefineFileReadWrite.ReadXml(
                            CommonData.GetInstance().ConfigFile,
                                        "Config/ClientPara/WebReference/Url");
            if (values.Length == 0)
            {
                CommonData.GetInstance().WebReferenceUrl = "";
            }
            else
            {
                CommonData.GetInstance().WebReferenceUrl = values[0].Trim();
            }
            //Log输出等级 
            values = DefineFileReadWrite.ReadXml(
                            CommonData.GetInstance().ConfigFile,
                                            "Config/ClientPara/Log/LogOutLevel");
            try
            {
                CommonData.GetInstance().LogOutLevel =
                     Int32.Parse(values[0].Trim());
            }
            catch
            {
                CommonData.GetInstance().LogOutLevel = 99;
            }

        }

        //获取用户权限职责
        private void GetUserDspInfo()
        {
            //加密
            Encryption4Net.Encryption encryption = new Encryption4Net.Encryption();
            string inputPsw = encryption.EnCode(ui.UserPwd);
            ui.UserPwd = inputPsw;
            encryption = null;

            listCheckUesrInfo = LoginClient.Current.CheckUserInfo(ui);


            if (listCheckUesrInfo.Count == 0)
            {
                MessageBox.Show("用户名或密码不存在!");
            }
            else
            {
                ListmenuItem = GetItems(listCheckUesrInfo[0].menuitem);
                listCheckUesrInfo[0].menuitem = ListmenuItem.ToArray<MenuItem>();
                MainWindow mw = new MainWindow();
                mw.ui = listCheckUesrInfo[0];
                mw.Show();
                CloseAction.Invoke();
            }
        }

        //登录
        public void Confirm()
        {
            try
            {

                if (Check())
                {
                    ReadClientConfig();

                    if (CheckLogin())
                    {
                        ListmenuItem = GetItems(listCheckUesrInfo[0].menuitem);
                        listCheckUesrInfo[0].menuitem = ListmenuItem.ToArray<MenuItem>();


                        MainWindow mw = new MainWindow();
                        mw.ui = listCheckUesrInfo[0];
                        //mw.Show();
                        Common.CommonData.GetInstance().ListCheckUesrInfo = listCheckUesrInfo[0];
                        CloseAction.Invoke();
                    }
                }

            }
            catch (Exception ex)
            {
                lg.LogWrite(Logger.LogLevel.Debug, "",ex.ToString());
                MessageBox.Show("网络异常,请联系管理员!");
                return;
            }
        }


        //修改密码
        public void UpdatePwd()
        {
            if (Check())
            {
                ReadClientConfig();

                if(CheckLogin())
                {

                    //显示修改密码窗体
                    UpdatePwdWindow upw = new UpdatePwdWindow();
                    upw.MUserID = listCheckUesrInfo[0].UserId.ToString();
                    upw.ShowDialog();
                    //if (upw.ChangePswResult == UpdatePwdWindow.ChangePswResultType.OK)
                    //{
                    //    //this.txtPassword.Text = pswForm.NewPsw ;
                    //    //this.btnLogin .Focus(); 
                    //}
                    //upw = null;
                }
            }
        }

        #endregion
    }
}
