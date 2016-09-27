using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Dao;
using MODEL.NewModel;
using System.Configuration;
using System.Collections.ObjectModel;

namespace FinancialRegulationSRV.Tools
{
    public class BillOperate
    {
        string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
        string hisFilePath = ConfigurationManager.AppSettings["hisFilePath"].ToString();
        string reportPath = ConfigurationManager.AppSettings["hisFilePath"].ToString();
        public List<BillFileCheck> BillFiles { get; set; }
        public DateTime SearchDate { get; set; }
        private JG_DepositDao deposit =JG_DepositDao.Instance;//获取存款实例
        private JG_PaymentDao payment = JG_PaymentDao.Instance;//获取支付实例
        private SeasonInterestDao seasoninterest = SeasonInterestDao.Instance;//获取季度结息实例
        public BillOperate()
        {

        }

        /// <summary>
        /// 开启对账单生成工作,并将对账单放到指定的目录里,对账单生成调用Excel,保存格式为xls
        /// </summary>
        /// <param name="billFiles">对账单文件集合</param>
        /// <param name="searchDate">查询时间</param>
        /// <returns>全部对账单生成成功并保存到指定目录返回true</returns>
        public bool Start(List<BillFileCheck> billFiles, DateTime searchDate)
        {
            SearchDate = searchDate;
            BillFiles = billFiles;
            bool result = false;
            try
            {
                ProduceBill();
                result= true;
            }
            catch (Exception)
            {
                billFiles = null;
            }

            return result;
        }

        /// <summary>
        /// 生成对账单
        /// </summary>
        private bool  ProduceBill()
        {
            List<string> txtInfo = new List<string>();
            foreach (BillFileCheck item in BillFiles)
            {
                string info = item.BussinessCode + "|" + item.CertificateNum + "|" + item.RegulatoryAccount + "|" + item.FirmName + "|" + item.TradeType + "|" + item.TradeFundAmount + "|" + item.TradeObject + "|" + item.TradeMark + "|" + item.ProjectCode;
                txtInfo.Add(info);
            }
            if (txtInfo.Count > 0)
            {
                try
                {
                    File.WriteAllLines(filePath, txtInfo);
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        private List<BillFileCheck> GetBillInfo(DateTime BillTime)
        {
            List<DepositFund> DFlist=  deposit.Selects().ToList<DepositFund>();
            List<FundPayment> FPlist = payment.Selects().ToList<FundPayment>();
            ObservableCollection<BillFileCheck> ocbf = new ObservableCollection<BillFileCheck>();
           
            return null;
        }

       
    }
}