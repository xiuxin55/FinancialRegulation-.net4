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
    public partial class DutyList : Form
    {
        public DutyList()
        {
            InitializeComponent();
        }

        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DutyList_Load(object sender, EventArgs e)
        {
            this.dgvODuty.AutoGenerateColumns = false;
            this.dgvUDuty.AutoGenerateColumns = false;
            BindUserDuty();
        }
        DataSet dsUserDuty;
        /// <summary>
        /// 绑定用户职责
        /// </summary>
        private void BindUserDuty()
        {
            dsUserDuty = UserDutyManagerClient.Current.GetUserDutyByID(UserID);
            if (dsUserDuty != null)
            {
                this.dgvODuty.DataSource = dsUserDuty.Tables[0];
                this.dgvUDuty.DataSource = dsUserDuty.Tables[1];
            }
        }
        List<FundsRegulatoryClient.UserDutyManagerSrv.UserDuty> lsUserDuty = new List<FundsRegulatoryClient.UserDutyManagerSrv.UserDuty>();
        
        DataGridViewRow drCurrentRow = new DataGridViewRow();
        /// <summary>
        /// 分配一个职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            lsUserDuty.Clear();
            drCurrentRow = dgvUDuty.CurrentRow;
            FundsRegulatoryClient.UserDutyManagerSrv.UserDuty ud = new FundsRegulatoryClient.UserDutyManagerSrv.UserDuty();
            ud.UserID = UserID;
            ud.DutyID = drCurrentRow.Cells[0].Value.ToString();
            lsUserDuty.Add(ud);
            FundsRegulatoryClient.UserDutyManagerSrv.UserDuty[] userdutys = lsUserDuty.ToArray();
            if (UserDutyManagerClient.Current.LicendToUser(userdutys) == "1")
            {
                BindUserDuty();
            }
        }
        /// <summary>
        /// 分配所有职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            lsUserDuty.Clear();
            DataTable dtUDuty = dsUserDuty.Tables[1];
            int count = dtUDuty.Rows.Count;
            if(count>0)
            {
                for (int i = 0; i < count; i++)
                {
                    DataRow dr = dtUDuty.Rows[i];
                    FundsRegulatoryClient.UserDutyManagerSrv.UserDuty ud = new FundsRegulatoryClient.UserDutyManagerSrv.UserDuty();
                    ud.UserID = UserID;
                    ud.DutyID = dr["DutyID"].ToString();
                    lsUserDuty.Add(ud);
                }
                FundsRegulatoryClient.UserDutyManagerSrv.UserDuty[] userdutys = lsUserDuty.ToArray();
                if (UserDutyManagerClient.Current.LicendToUser(userdutys) == "1")
                {
                    BindUserDuty();
                }
            }
            
        }
        /// <summary>
        /// 移除一个职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            string UserDutyID = dgvODuty.CurrentRow.Cells[3].Value.ToString();
            if (UserDutyManagerClient.Current.RemoveDuty(new string[] { UserDutyID }) == "1")
            {
                BindUserDuty();
            }
        }
        /// <summary>
        /// 移除所有职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            List<string> lsRemoveID = new List<string>();
            DataTable dtODuty = dsUserDuty.Tables[0];
            int count = dtODuty.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    DataRow dr = dtODuty.Rows[i];
                    lsRemoveID.Add(dr["UserDutyID"].ToString());
                }
                if (UserDutyManagerClient.Current.RemoveDuty(lsRemoveID.ToArray()) == "1")
                {
                    BindUserDuty();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
