using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BaseManager;
using FundsRegulatoryClient;
namespace FinancialRegulation.UserCotrol2
{
    public partial class DutyMaintain : UserControl
    {
        public DutyMaintain()
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
        private void DutyMaintain_Shown(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                c.Visible = true;
        }
        /// <summary>
        /// 新增职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNewDuty_Click(object sender, EventArgs e)
        {
            DutyInfo di = new DutyInfo();
            if (di.ShowDialog() == DialogResult.OK)
            {
                BindDuty();
            }
        }

        private void DutyMaintain_Load(object sender, EventArgs e)
        {
            this.dgvDutyInfo.AutoGenerateColumns = false;
            BindDuty();
        }
        /// <summary>
        /// 绑定职责
        /// </summary>
        private void BindDuty()
        {
            DataSet dsAllDuty = DutyManageClient.Current.GetAllDuty();
            if (dsAllDuty != null)
            {
                this.dgvDutyInfo.DataSource = dsAllDuty.Tables[0].DefaultView;
            }
        }

        //private void tsbClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        /// <summary>
        /// 删除职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string DutyID = dgvDutyInfo.CurrentRow.Cells[0].Value.ToString();
            string DutyCode=dgvDutyInfo.CurrentRow.Cells[1].Value.ToString().Trim();
            if (MessageBox.Show("是否删除编号为 " + DutyCode + " 职责的信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DutyManageClient.Current.DeleteDutyByID(DutyID) == "1")
                {
                    MessageBox.Show("删除成功！");
                    BindDuty();
                }
            }            
        }
        /// <summary>
        /// 编辑职责
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            DutyInfo di = new DutyInfo();
            //di.Owner = this;
            //di.DrDuty=((DataView)dgvDutyInfo.DataSource).Rows[dgvDutyInfo.CurrentRow.Index];


            di.DrDuty = ((DataView)dgvDutyInfo.DataSource)[dgvDutyInfo.CurrentRow.Index].Row;
            if (di.ShowDialog() == DialogResult.OK)
            {
                BindDuty();
            }
        }

        private void tsbLicent_Click(object sender, EventArgs e)
        {
            //FunSetForm fsf = new FunSetForm((System.Guid)((DataTable)dgvDutyInfo.DataSource).Rows[dgvDutyInfo.CurrentRow.Index]["DutyID"]);
            FunSetForm fsf = new FunSetForm(((DataView)dgvDutyInfo.DataSource)[dgvDutyInfo.CurrentRow.Index]["DutyID"].ToString());
            fsf.ShowDialog();
        }

    }
}
