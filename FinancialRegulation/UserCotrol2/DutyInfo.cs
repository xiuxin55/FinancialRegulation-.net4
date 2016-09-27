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
    public partial class DutyInfo : Form
    {
        public DutyInfo()
        {
            InitializeComponent();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataRow drDuty;

        public DataRow DrDuty
        {
            get { return drDuty; }
            set { drDuty = value; }
        }
        private void DutyInfo_Load(object sender, EventArgs e)
        {
            if (drDuty != null)
            {
                txtDutyCode.Text = drDuty["DutyCode"].ToString().Trim();
                txtDutyName.Text = drDuty["DutyName"].ToString().Trim();
                txtDescribe.Text = drDuty["Describe"].ToString().Trim();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FundsRegulatoryClient.DutyManageSrv.Duty dt = new FundsRegulatoryClient.DutyManageSrv.Duty();

            dt.DutyCode = txtDutyCode.Text.Trim();
            dt.DutyName = txtDutyName.Text.Trim();
            dt.Describe = txtDescribe.Text.Trim();
            
            try
            {
                if (drDuty != null)
                {
                    dt.DutyID=drDuty["DutyID"].ToString();
                    if (DutyManageClient.Current.UpdateDuty(dt) == "1")
                    {
                        MessageBox.Show("操作成功");
                    }
                }
                else
                {
                    if (DutyManageClient.Current.InsertDuty(dt) == "1")
                    {
                        MessageBox.Show("操作成功");
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
