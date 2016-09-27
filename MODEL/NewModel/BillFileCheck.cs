using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 对账文件字段
    /// </summary>
    public class BillFileCheck
    {
        private string bussinessCode;//账务类型

        public string BussinessCode
        {
            get { return bussinessCode; }
            set { bussinessCode = value; }
        }
        private string certificateNum;//凭证编号

        public string CertificateNum
        {
            get { return certificateNum; }
            set {

                certificateNum = value;
            }
        }
        private string regulatoryAccount;//监管账号

        public string RegulatoryAccount
        {
            get { return regulatoryAccount; }
            set { regulatoryAccount = value; }
        }
        private string firmName;//企业名称

        public string FirmName
        {
            get { return firmName; }
            set {  firmName = value; }
        }
        private string tradeType;//交易类型

        public string TradeType
        {
            get { return tradeType; }
            set {  tradeType = value; }
        }
       
        private decimal? tradeFundAmount;//交易金额

        public decimal? TradeFundAmount
        {
            get { return tradeFundAmount; }
            set
            {
                tradeFundAmount = value;
               
            }
        }
        private string tradeObject;//交易对象

        public string TradeObject
        {
            get { return tradeObject; }
            set {  tradeObject = value; }
        }
        private string tradeMark;//交易标识

        public string TradeMark
        {
            get { return tradeMark; }
            set {  tradeMark = value; }
        }
        private string projectCode;//项目标识码

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }
        private DateTime? time;
        public DateTime? Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
