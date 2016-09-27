using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.ViewModel;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_InterestRateSrv;
using Microsoft.Practices.Prism.Commands;

namespace FinancialRegulation.Page.Other
{
    public class InterestRateEditVM : BaseEditVM<JG_InterestRateInfo>
    {

        public JG_InterestRateClient client = JG_InterestRateClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;

        public override void LoadCommand()
        {

        }

        #region 属性

        //利率
        private JG_InterestRateInfo _jirInfo;

        public JG_InterestRateInfo JirInfo
        {
            get { return _jirInfo; }
            set
            {
                _jirInfo = value;
                this.RaisePropertyChanged("JirInfo");
            }
        }

        

        #endregion

        #region 命令

        #endregion

        #region 方法

        public override void OKExecute()
        {
            if (JirInfo.InterestRate == null)
            {
                VMHelp.ShowMessage("利率不能为空!", true);
                return;
            }

            JirInfo.ID = Guid.NewGuid().ToString();
            JirInfo.SetDate = DateTime.Now;
           
            FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
            db.DB_Time=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.DB_InterestRate = JirInfo.InterestRate;
            
            if (InterestClient.UpdateJG_DayBalanceInfo(db))
            {
                if (client.AddJG_InterestRateInfo(JirInfo))
                {
                    VMHelp.ShowMessage("添加成功!", true);
                    windowClose();
                }
            }
        }

        #endregion
    }
}
