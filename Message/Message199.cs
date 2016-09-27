using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 异常信息 担保到银行
    /// </summary>
    [XmlRoot("Message199")]
    public class Message199 : BaseMessageRequest
    {
        //public string BusinessCode { get; set; }
        //public string BusinessTime { get; set; }
        //public string SerialNo { get; set; }

        /// <summary>
        /// 错误编号
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 银行编号
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 网点编号
        /// </summary>
        public string PointCode { get; set; }
        ///// <summary>
        ///// 返回错误编号
        ///// </summary>
        //public string ExceptionCode { get; set; }
        ///// <summary>
        ///// 返回错误信息
        ///// </summary>
        //public string ExceptionMsg { get; set; }


        public override BaseMessageResponse GetReponseMessage()
        {
            Message099 responseMsg = new Message099();
            responseMsg.BusinessCode = "099";
            responseMsg.ErrorCode = ErrorCode;
            //responseMsg.ErroMsg = ErroMsg;
            responseMsg.BankCode = BankCode;
            responseMsg.PointCode = PointCode;

            return responseMsg;
        }


        public override BaseMessageResponse MeaasgeOperate()
        {

            //JG_ErrorMsgInfo jemInfo = new JG_ErrorMsgInfo();
            //jemInfo.EM_Id = Guid.NewGuid().ToString();
            //jemInfo.EM_ErrorCode = ErrorCode;
            //jemInfo.EM_ErrorMsg = ErrorMsg;
            //jemInfo.EM_BankCode = BankCode;
            //jemInfo.EM_PointCode = PointCode;
            //jemInfo.EM_Time = BusinessTime;


            //BaseMessageResponse responseMsg = GetReponseMessage();
            //responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);
            //responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();

            //if (FundsRegulatoryClient.JG_ErrorMsgClient.Current.AddErrorMsgInfo(jemInfo))
            //{
            //    responseMsg.ExceptionCode = "01";
            //}

            //return responseMsg;
            throw new NotImplementedException();
        }
    }
}
