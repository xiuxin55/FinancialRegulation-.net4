using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 利息支付请求担保到银行
    /// </summary>
    [XmlRoot("Message014")]
    public class Message014:BaseMessageRequest
    {
        ///// <summary>
        ///// 交易代码
        ///// </summary>
        //public string BusinessCode { get; set; }
        ///// <summary>
        ///// 交易时间
        ///// </summary>
        //public string BusinessTime { get; set; }
        ///// <summary>
        ///// 交易流水号
        ///// </summary>
        //public string SerialNo { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public string CorpCode { get; set; }
        ///// <summary>
        ///// 协议编号
        ///// </summary>
        ////public string PactNo { get; set; }
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

        public override BaseMessageResponse GetReponseMessage()
        {
            Message114 responseMsg = new Message114();
            responseMsg.BusinessCode = "114";
            responseMsg.PactNo = PactNo;
            responseMsg.FormerNo = SerialNo;
            responseMsg.CorpCode = CorpCode;
            responseMsg.Interests = Interests;
            responseMsg.PaymentAccount = PaymentAccount;
            responseMsg.PayeeAccount = PayeeAccount;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            Message114 responseMsg = GetReponseMessage() as Message114;
            //responseMsg
            return responseMsg;
        }
    }
}
