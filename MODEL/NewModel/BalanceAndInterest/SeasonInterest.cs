using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel.BalanceAndInterest
{
    /// <summary>
    /// 季度结息
    /// </summary>
   public class SeasonInterest
    {
        public string ID { get; set; }
        public string SI_ID { get; set; }//唯一编号
        public string SI_AccountNum { get; set; }//账号
        public decimal? SI_Money { get; set; }//结息金额
        public DateTime? SI_Time { get; set; }//日期
        public string SI_Memo { get; set; }//备忘录
        public string SI_CertificateNum { get; set; }//补录凭证编号
        public string SI_BankTellerID { get; set; }//银行柜员号
        public string SI_State { get; set; }//状态
        public string SI_BankSerialNumber { get; set; }//银行流水号
       
       
    }
}
