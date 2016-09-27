using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 支付请求响应银行到担保
    /// </summary>
    [XmlRoot("Message110")]
    public class Message110:BaseMessageResponse
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
        /// 原交易流水号
        /// </summary>
        public string FormerNo { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }

        /// <summary>
        /// 付款账户
        /// </summary>
        public string PayAccount { get; set; }
        /// <summary>
        /// 支取人
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// 支取账户
        /// </summary>
        public string PayeeAccount { get; set; }
        /// <summary>
        /// 支取金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }
        ///// <summary>
        ///// 异常代码
        ///// </summary>
        //public string ExceptionCode { get; set; }
        ///// <summary>
        ///// 异常信息
        ///// </summary>
        //public string ExceptionMessage { get; set; }

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
