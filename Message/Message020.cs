using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 调账完成确认 担保到银行
    /// </summary>
    [XmlRoot("Message020")]
    public class Message020:BaseMessageResponse
    {
        //public string BusinessCode { get; set; }
        //public string BusinessTime { get; set; }
        //public string SerialNo { get; set; }
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 合同备案号
        /// </summary>
        public string ContractRecordNo { get; set; }
        /// <summary>
        /// 存款流水号
        /// </summary>
        public string DepositNo { get; set; }
        /// <summary>
        /// 存款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 资金性质
        /// </summary>
        public string NatureOfFunding { get; set; }
        /// <summary>
        /// 存款银行
        /// </summary>
        public string FromBbank { get; set; }
        /// <summary>
        /// 存款人
        /// </summary>
        public string Depositor { get; set; }
        /// <summary>
        /// 退款账号
        /// </summary>
        public string ReceiveAccount { get; set; }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PaymentAccount { get; set; }
        /// <summary>
        /// 退款账户余额
        /// </summary>
        public decimal RABalances { get; set; }
        /// <summary>
        /// 付款账户余额
        /// </summary>
        public decimal PABalances { get; set; }
        //public string ExceptionCode { get; set; }
        //public string ExceptionMessage { get; set; }

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
