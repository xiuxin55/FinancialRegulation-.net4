using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 异常信息响应 担保到银行
    /// </summary>
    [XmlRoot("Message099")]
    public class Message099 : BaseMessageResponse
    {
        /// <summary>
        /// 错误编号
        /// </summary>
        public string ErrorCode { get; set; }
        ///// <summary>
        ///// 错误信息
        ///// </summary>
        //public string ErrorMsg { get; set; }
        /// <summary>
        /// 银行编号
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 网点编号
        /// </summary>
        public string PointCode { get; set; }


        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
