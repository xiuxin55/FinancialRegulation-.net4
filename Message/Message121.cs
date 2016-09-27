using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 销户 银行到担保
    /// </summary>
    [XmlRoot("Message121")]
    public class Message121 : BaseMessageResponse
    {
        //交易代码	BusinessCode
        //交易时间	BusinessTime
        //交易流水号	SerialNo

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
        ////异常代码	
        //public string ExceptionCode { get; set; }
        ////异常信息	
        //public string ExceptionMessage { get; set; }

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
