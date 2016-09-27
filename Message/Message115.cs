using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 利息支付确认 银行到担保
    /// </summary>
    [XmlRoot("Message115")]
    public class Message115:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }
        //public string BusinessTime { get; set; }
        //public string SerialNo { get; set; }


        /// <summary>
        /// 原交易流水号
        /// </summary>
        public string FormerNo { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public string CorpCode { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }
        /// <summary>
        /// 利息金额
        /// </summary>
        public decimal Interests { get; set; }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PaymentAccount { get; set; }

        /// <summary>
        /// 收款账户
        /// </summary>
        public string PayeeAccount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message015 responseMsg = new Message015();
            responseMsg.BusinessCode = "015";
            responseMsg.CorpCode = CorpCode;
            responseMsg.PactNo = PactNo;
            responseMsg.Interests = Interests;
            responseMsg.PaymentAccount = PaymentAccount;
            responseMsg.PayeeAccount = PayeeAccount;
            responseMsg.Balances = Balances;

            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
