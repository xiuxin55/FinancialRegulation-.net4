using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common;
using Encryption4Net;
using BaseClient;
using BaseClient.LoginSrv;

namespace MainFrame
{
    /// <summary>
    /// UpdatePwdWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdatePwdWindow : Window
    {
        public UpdatePwdWindow()
        {
            InitializeComponent();
            txtPwd.Focus();
        }

        private string mUserID = "";
        private string mNewPsw = "";

        public string MUserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }

        public string NewPsw
        {
            get { return mNewPsw; }
        }

        public ChangePswResultType ChangePswResult
        {
            get { return changePswResult; }
            set { changePswResult = value; }
        }

        /// <summary>
        /// 密码修改处理结果
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name=buildYear">事件数据</param> 
        public enum ChangePswResultType
        {
            OK,
            QuitApp
        }
        private ChangePswResultType changePswResult;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //输入内容校验
            if (InputCheckLogin() == false)
            {
                return;
            }

            UserInfo ui = new UserInfo();

            //将画面输入密码的进行密文转换
            Encryption encryption = new Encryption();
            string inputPsw = encryption.EnCode(this.txtPwd.Password);
            ui.UserPwd = inputPsw;
            ui.UserId = MUserID;
            encryption = null;

            //修改密码操作
            int actionRet = 0;
            try
            {
                BaseClient.LoginClient loginClient = LoginClient.Current;
                actionRet = loginClient.UpdateLogin(ui);
                loginClient = null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            if (actionRet != 1)
            {
                MessageBox.Show("密码修改失败!");
                return;
            }

            //设置修改操作结果
            changePswResult = ChangePswResultType.OK;
            mNewPsw = this.txtPwd.Password;

            MessageBox.Show("密码修改成功!");

            //窗体关闭
            this.Close();
        }


        /// <summary>
        /// 登录处理前的校验
        /// </summary>
        /// <returns>正确:true;错误:false</returns>
        private bool InputCheckLogin()
        {
            //新密码：必须
            if (this.txtPwd.Password.Trim().Length == 0)
            {
                MessageBox.Show("新密码不能为空!");
                this.txtPwd.Focus();
                return false;
            }
            //确认密码：必须

            if (this.txtPwdAgin.Password.Trim().Length == 0)
            {
                MessageBox.Show("确认密码不能为空!");
                this.txtPwdAgin.Focus();
                return false;
            }

            //新密码与确认密码：相等

            if (this.txtPwd.Password.Trim() != this.txtPwdAgin.Password.Trim())
            {
                MessageBox.Show("两次密码输入不一致!");
                this.txtPwd.Password = "";
                this.txtPwdAgin.Password = "";
                this.txtPwd.Focus();
                return false;
            }

            //最后返回

            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
