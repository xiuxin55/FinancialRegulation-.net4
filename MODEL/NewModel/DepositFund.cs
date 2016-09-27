using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 监管资金缴存
    /// </summary>
   public class DepositFund
    {
        public string ID { get; set; }
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }//交易代码
        public string BankCode { get; set; }
        public string DepositNum { get; set; }//缴款凭证编号
        public decimal? DepositAmount { get; set; }//缴款金额
       
        public string  PurchaserName { get; set; }
        public string PurchaserID { get; set; }//购房人证件号
        public string  BankName { get; set; }//缴款银行名称
        public string BankSiteID { get; set; }//银行网点号
        public string  BankTellerID { get; set; }//银行柜员号
        public string  SerialNumber { get; set; }//银行流水号
        public string DepositInstr { get; set; }//缴款说明
        public DateTime? DepositTime { get; set; }//缴款时间
        public string DeSerialNumber { get; set; }//存款流水号（软件自动产生）
       
        public string DepositState{ get; set; }//缴款状态
       /// <summary>
       /// 资金缴存返回集
       /// </summary>
        public string FirmName { get; set; }//银开发企业名称
        public string DepositAccount { get; set; }//缴款账号
        public string DepositType { get; set; }//缴款类型
        public string ProjectCode { get; set; }//项目标识码
        public DateTime? CheckTime { get; set; }//应缴款确认时间

        public string ReverseInstr { get; set; }//冲正说明
        public DateTime? ReverseTime { get; set; }//冲正时间
    }
}
