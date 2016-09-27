using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FundsRegulatoryClient;
using System.Net;
using Encryption4Net;

namespace FinancialRegulation.UserCotrol2
{
    public partial class UserInfo :Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }
        DataRowView drUser;
        string userID;
        Encryption ep = new Encryption();
        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDuty_Click(object sender, EventArgs e)
        {
            DutyList dl = new DutyList();
            if (drUser != null)
                dl.UserID = drUser["UserID"].ToString();
            else
                dl.UserID = userID;
            dl.ShowDialog();
        }
        FundsRegulatoryClient.UserManageSrv.UserInfo ui = new FundsRegulatoryClient.UserManageSrv.UserInfo();
        /// <summary>
        /// 提交信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("登录名不能为空");
                txtUserCode.Focus();
                return;
            }
            if (txtPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("登录密码不能为空");
                txtPwd.Focus();
                return;
            }
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("用户姓名不能为空");
                txtUserName.Focus();
                return;
            }
            ui.UserCode = txtUserCode.Text.Trim();            
            ui.UserPwd = ep.EnCode(txtPwd.Text.Trim());
            ui.Sex = "男";
            if (rbtnFemale.Checked)
                ui.Sex = "女";
            ui.LinkTel = txtLinkTel.Text.Trim();
            ui.UserName = txtUserName.Text.Trim();
            ui.Email = txtEmail.Text.Trim();
            string hostname = Dns.GetHostName();
            ui.Describe = txtDescribe.Text.Trim();
            ui.Ssq = cmbDist.SelectedValue.ToString();

            try
            {
                if (drUser != null)
                {
                    ui.UserId = drUser["UserID"].ToString();
                    if (UserManageClient.Current.UpdateUserByID(ui) == "1")
                    {
                        MessageBox.Show("用户信息修改成功！");
                    }
                }
                else
                {
                    ui.UserId = userID;
                    ui.State = "1";
                    if (UserManageClient.Current.InsertUser(ui) == "1")
                    {
                        MessageBox.Show("用户信息提交成功！");
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public DataRowView DrUser
        {
            get { return drUser; }
            set { drUser = value; }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfo_Load(object sender, EventArgs e)
        {
            if(true)

            BindCmdDist();
            if (drUser != null)
            {
                this.dgvUserDuty.AutoGenerateColumns = false;
                DataSet ds = UserDutyManagerClient.Current.GetUserDutyByID(drUser["UserID"].ToString());
                if (ds != null)
                {
                    this.dgvUserDuty.DataSource = ds.Tables[0];
                }
                txtUserCode.Text = drUser["UserCode"].ToString().Trim();
                txtConfirmPwd.Text = txtPwd.Text = drUser["UserPwd"].ToString().Trim();
                txtPwd.Enabled = false;
                txtConfirmPwd.Enabled = false;
                txtUserName.Text = drUser["UserName"].ToString().Trim();
                if (drUser["Sex"].ToString() == "男")
                {
                    rbtnMale.Checked = true;
                    rbtnFemale.Checked = false;
                }
                else
                {
                    rbtnMale.Checked = false;
                    rbtnFemale.Checked = true;
                }
                txtLinkTel.Text = drUser["LinkTel"].ToString().Trim();
                txtEmail.Text = drUser["Email"].ToString().Trim();
                txtDescribe.Text = drUser["Describe"].ToString().Trim();
                cmbDist.SelectedValue = drUser["SSQ"].ToString().Trim();
            }
            else
            {
                userID = Guid.NewGuid().ToString();
            }
        }

        //绑定行政区
        private void BindCmdDist()
        {
            string[] setCodes = { "04" };
            DataView dv = UserManageClient.Current.GetJG_Branches().Tables[0].DefaultView;

            //DataSet ds = Client.UserManageClient.Current.GetDist();

            cmbDist.DataSource = dv;
            cmbDist.DisplayMember = "BR_BranchName";
            cmbDist.ValueMember = "BR_BranchCode";
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
