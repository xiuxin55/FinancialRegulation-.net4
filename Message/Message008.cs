using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 监管账户结息响应担保到银行
    /// </summary>
    [XmlRoot("Message008")]
    public class Message008:BaseMessageResponse
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
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }
        /// <summary>
        /// 结息账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 结息时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 利息金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }
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
