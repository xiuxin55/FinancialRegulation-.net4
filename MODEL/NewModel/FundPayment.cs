using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 监管资金支付
    /// </summary>
    public class FundPayment
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        public string PayID { get; set; }//ID
        public string PaymentID { get; set; }//付款凭证编号
        
        public decimal? PaymentAmount{ get; set; }//支付金额
        public string FirmName { get; set; }//企业名称
        public string FirmOperatorName { get; set; }//企业经办人
        public string FirmOperatorID { get; set; }//经办人证件号
        public string PaymentBank { get; set; }//支付银行
        public string BankSiteID { get; set; }//银行网点号
        public string BankTellerID { get; set; }//银行柜员号
        public string SerialNumber { get; set; }//系统流水号
        public string PaymentInstr { get; set; }//支付说明
        public DateTime? PaymentTime { get; set; }//支付时间
        public string BankSerialNumber { get; set; }//银行流水号
        /// <summary>
        /// 查询结果
        /// </summary>
        public string ReceiverAccount { get; set; }//收款人账号
        public string ReceiverName { get; set; }//收款人名称
        public string ReceiveBank { get; set; }//收款银行名称
        public string PayAccount { get; set; }//付款人账号
        public string PayName { get; set; }//付款人名称
        public string PayState { get; set; }//付款状态
        public string ProjectCode { get; set; }//项目标识码
        public DateTime? PaymentConfirmTime { get; set; }//支付确认时间

        public string ReverseInstr { get; set; }//冲正说明
        public DateTime? ReverseTime { get; set; }//冲正时间
        
    }
}
