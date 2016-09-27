using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 开户响应 担保到银行
    /// </summary>
    [XmlRoot("Message001")]
    public class Message001:BaseMessageResponse
    {
        //public string BusinessCode { get; set; }     //交易代码
        //public string BusinessTime { get; set; }     //交易时间
        //public string SerialNo { get; set; }         //交易流水号
        public string BankCode { get; set; }         //银行代码
        public string CorpCode { get; set; }         //企业代码
        public string CorpName { get; set; }         //企业名称
        public string AccountName { get; set; }      //账户名称
        public string Account { get; set; }          //账号
        //public string ExceptionCode { get; set; }    //01正常，02企业名称错误，03监管银行错误
        //public string ExceptionMessage { get; set; } //异常信息

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
