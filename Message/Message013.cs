using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 利息金额查询担保到银行
    /// </summary>
    [XmlRoot("Message013")]
    public class Message013:BaseMessageRequest
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
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }


        public override BaseMessageResponse GetReponseMessage()
        {
            Message113 responseMsg = new Message113();
            responseMsg.BusinessCode = "113";
            responseMsg.CorpCode = CorpCode;
            responseMsg.FormerNo = SerialNo;
            responseMsg.PactNo = PactNo;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            Message113 responseMsg = GetReponseMessage() as Message113;
            //responseMsg.Interests = JG_InterestRateClient.Instance.InterestInquire(PactNo); ;
            responseMsg.Interests = JG_InterestRateClient.Instance.InterestInquire(PactNo);
            responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
            responseMsg.BusinessTime = BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);
            responseMsg.ExceptionCode = "01";
            responseMsg.ExceptionMessage = "";
            return responseMsg;
        }
    }
}
