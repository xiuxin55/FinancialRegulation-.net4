using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 交易冲正
    /// </summary>
    public class TradeReverse
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        public string  PaymentID { get; set; }//付款凭证编号
        public string  ReverseSerialNum { get; set; }//冲正编号
        public string ReverseBank { get; set; }//冲正银行
        public string BankSiteID { get; set; }//银行网点号
        public string BankTellerID { get; set; }//银行柜员号
        public string ReverseInstr { get; set; }//冲正说明
        public DateTime? ReverseTime { get; set; }//冲正时间
    }
}
