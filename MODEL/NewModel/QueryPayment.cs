using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 应付资金查询
    /// </summary>
    public class QueryPayment
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        public string PaymentNum { get; set; }//付款凭证编号
    }
}
