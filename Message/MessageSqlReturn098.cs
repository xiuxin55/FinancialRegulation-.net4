using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data;

namespace Message
{
    /// <summary>
    /// 发送sql报文
    /// </summary>
    [XmlRoot("Message098")]
    public class MessageSqlReturn098 : BaseMessageRequest
    {
        public string sql { get; set; }
        public string UserCode { get; set; }
        public string UserPwd { get; set; }

        MessageSqlReturn198 msg198 = null;
        public override BaseMessageResponse GetReponseMessage()
        {
            msg198 = new MessageSqlReturn198();
            msg198.BusinessCode = "198";
            return msg198;
        }
        public override BaseMessageResponse MeaasgeOperate()
        {
            DataSet ds = new DataSet();
            BaseMessageResponse msgResponse = GetReponseMessage();
            msgResponse.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSTIMEFORMATE);
            msgResponse.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            ds = FundsRegulatoryClient.RegulatoryClient.Current.DoSqlRetrun(sql,UserCode,UserPwd);
            if (ds.Tables[0].Rows[0]["Code"].ToString() != "00")
            {
                msgResponse.ExceptionCode = ds.Tables[0].Rows[0]["Code"].ToString();
                msgResponse.ExceptionMessage = ds.Tables[0].Rows[0]["Msg"].ToString();
            }
            else
            {
                msg198.dsResult = ds;
                msgResponse.ExceptionCode = "01";
            }
            return msgResponse;
        }
    }
}
