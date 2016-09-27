using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 存款红冲响应 担保到银行
    /// </summary>
    [XmlRoot("Message006")]
    public class Message006:BaseMessageResponse
    {
        //public string BusinessCode { get; set; }       //交易代码
        //public string BusinessTime { get; set; }       //交易时间
        //public string SerialNo { get; set; }           //交易流水号
        public string BankCode { get; set; }           //交易银行
        //public string PactNo { get; set; }             //协议编号
        public string CorpCode { get; set; }           //企业名称
        public string DepositNo { get; set; }          //存款流水号
        public decimal Money { get; set; }             //存款金额
        public string NatureOfFunding { get; set; }    //资金性质
        public decimal Balances { get; set; }          //账户余额
        //public string ExceptionCode { get; set; }      //异常代码
        //public string ExceptionMessage { get; set; }   //异常信息

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
