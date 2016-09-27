using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 退票交易
    /// </summary>
    public class RefundTrade
    {
        public string PackageLength { get; set; }
        public string BussinessCode { get; set; }
        public string BankCode { get; set; }
        public string ID { get; set; }//ID
        public string BankSerialNum { get; set; }//银行流水号
        public string SerialNum { get; set; }//系统流水号
        public string PaymentID { get; set; }//支付凭证编号
        public decimal? RefundAmount { get; set; }//退票金额
        public string RefundInstr { get; set; }//退票说明
        public DateTime? RefundTime { get; set; }//退票时间
        public string Bankwebsite { get; set; }//网点号
        public string AccountTeller { get; set; }//柜员号
        public string AccountName { get; set; }//退票账号
        public string AccountID { get; set; }//账户生成的id
        public string RT_Type { get; set; }//类型
    }
}
