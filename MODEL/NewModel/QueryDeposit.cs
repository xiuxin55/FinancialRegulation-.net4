using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 应缴资查询
    /// </summary>
    public class QueryDeposit
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        public string DepositNum { get; set; }//缴款凭证编号
    }
}
