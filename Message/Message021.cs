using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient.JG_SpvProtocolSrv;
using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 销户 担保到银行
    /// </summary>
    [XmlRoot("Message002")]
    public class Message021 : BaseMessageRequest
    {
        ////交易代码	
        //public string BusinessCode { get; set; }
        ////交易时间	
        //public string BusinessTime { get; set; }
        ////交易流水号	
        //public string SerialNo { get; set; }

        //银行代码	
        public string BankCode { get; set; }
        //企业代码	
        public string CorpCode { get; set; }
        //企业名称	
        public string CorpName { get; set; }
        //账户名称	
        public string AccountName { get; set; }
        //账号	
        public string Account { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message121 responseMsg = new Message121();
            responseMsg.BusinessCode = "121";
            responseMsg.BankCode = BankCode;
            responseMsg.AccountName = AccountName;
            responseMsg.Account = Account;
            responseMsg.CorpName = CorpName;
            responseMsg.CorpCode = CorpCode;
            responseMsg.PactNo = PactNo;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            Message121 responseMsg = GetReponseMessage() as Message121;
            List<JG_SpvProtocol> jG_SpvProtocolLst = JG_SpvProtocolClient.Instance.GetProtocolByCondition(new JG_SpvProtocol() { SP_XYBH = PactNo });
            if (jG_SpvProtocolLst == null || jG_SpvProtocolLst.Count == 0)
            {
                responseMsg.ExceptionCode = "03";
                responseMsg.ExceptionMessage = "监管银行错误";
                responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
                responseMsg.BusinessTime = BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);
                return responseMsg;
            }
            if (jG_SpvProtocolLst[0].SP_CorpName != CorpName)
            {
                responseMsg.ExceptionCode = "02";
                responseMsg.ExceptionMessage = "企业名称错误";
                responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
                responseMsg.BusinessTime = BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);
                return responseMsg;
            }

            responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
            responseMsg.BusinessTime = BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);
            responseMsg.ExceptionCode = "01";
            return responseMsg;
        }
    }
}
