using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 利息金额响应银行到担保
    /// </summary>
    [XmlRoot("Message113")]
    public class Message113:BaseMessageResponse
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
        /// 原流水号
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
