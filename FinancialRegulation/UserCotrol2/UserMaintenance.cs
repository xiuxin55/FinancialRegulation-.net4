using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FundsRegulatoryClient;

namespace FinancialRegulation.UserCotrol2
{
    public partial class UserMaintenance : UserControl
    {
        public UserMaintenance()
        {
            InitializeComponent();
            //foreach (Control c in this.Controls)
            //    c.Visible = false;
        }
        /// <summary>
        /// 第一次显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void UserMaintenance_Shown(object sender, EventArgs e)
        //{
        //    foreach (Control c in this.Controls)
        //        c.Visible = true;
        //}
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaintenance_Load(object sender, EventArgs e)
        {
            this.dgvUserInfo.AutoGenerateColumns = false;
            BindAllUser();
        }    
        /// <summary>
        /// 绑定所有用户
        /// </summary>
        private void BindAllUser()
        {
            DataSet dsAllUser=UserManageClient.Current.GetAllUser();
            if (dsAllUser != null)
            {
                this.dgvUserInfo.DataSource = dsAllUser.Tables[0];               
            }
        }

        /// <summary>
        /// 单元格双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            if (e.RowIndex == -1)
            {
                return;
            }
            if (this.dgvUserInfo.Rows[e.RowIndex].Cells["ID"].Value == null)
            {
                return;
            }            
        }
        /// <summary>
        /// 设定密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSetPwd_Click(object sender, EventArgs e)
        {
            //SetPassWord spw = new SetPassWord();
            //spw.Show();
        }
        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNewUser_Click(object sender, EventArgs e)
        {
            UserInfo ui = new UserInfo();
            if (ui.ShowDialog() == DialogResult.OK)
            {
                BindAllUser();
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        DataGridViewRow currentRow = new DataGridViewRow();
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvUserInfo.CurrentRow != null)
            {
                currentRow = dgvUserInfo.CurrentRow;
                string userID = currentRow.Cells[0].Value.ToString().Trim();
                string userCode = currentRow.Cells[1].Value.ToString().Trim();
                if (MessageBox.Show("是否删除编号为 " + userCode + " 用户的信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (UserManageClient.Current.DeleteUserByID(userID) == "1")
                    {
                        MessageBox.Show("信息删除成功！");
                        BindAllUser();
                    }
                }
            }

        }
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvUserInfo.CurrentRow != null)
            {
                UserInfo ui = new UserInfo();
                ui.DrUser = ((DataTable)dgvUserInfo.DataSource).DefaultView[dgvUserInfo.CurrentRow.Index];
                if (ui.ShowDialog() == DialogResult.OK)
                {
                    BindAllUser();
                }
            }
        }
        /// <summary>
        /// 用户停用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnLock_Click(object sender, EventArgs e)
        {
            if (dgvUserInfo.CurrentRow != null)
            {
                currentRow = dgvUserInfo.CurrentRow;
                string userID = currentRow.Cells[0].Value.ToString().Trim();
                string state = "0";
                if (currentRow.Cells[7].Value.ToString().Trim() == "停用")
                    state = "1";
                if (UserManageClient.Current.UpdataStateByID(userID,state) == "1")
                {
                    MessageBox.Show("操作成功！");
                    BindAllUser();
                }
            }

        }
        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSetPower_Click(object sender, EventArgs e)
        {
            DutyList dl = new DutyList();
            DataRowView drUser = ((DataTable)dgvUserInfo.DataSource).DefaultView[dgvUserInfo.CurrentRow.Index];
            if (drUser != null)
            {
                dl.UserID = drUser["UserID"].ToString();
                dl.ShowDialog();
            }
        }
    }
}
