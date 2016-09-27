using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 利息补录
    /// </summary>
    public class InterestRecord
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        public string DepositNum { get; set; }//缴款凭证编号
        public decimal? InterestAmount { get; set; }//利息金额
        public string ProjectCode { get; set; }//项目标识码
        public string RecordInstr { get; set; }//补录说明
        public DateTime? RecordTime { get; set; }//补录时间
        public string InterestRate { get; set; }//利率
        public string SettleFlag { get; set; }//标记是否已经补录
    }
}
