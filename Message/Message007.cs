using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 资金归集响应 报文方向 担保到银行
    /// </summary>
    [XmlRoot("Message007")]
    public class Message007:BaseMessageResponse
    {
        //public string BusinessCode { get; set; }    //交易代码
        //public string BusinessTime { get; set; }    //交易时间
        //public string SerialNo { get; set; }        //交易流水号
        public string FormerNo { get; set; }        //原流水号
        //public string PactNo { get; set; }          //协议编号
        public string PaymentAccount { get; set; }  //付款账户
        public string Payer { get; set; }           //付款人
        public string PayeeAccount { get; set; }    //收款账户
        public string Payee { get; set; }           //收款人
        public decimal Money { get; set; }          //交易金额
        public decimal Balances1 { get; set; }      //付款账户余额
        public decimal Balances2 { get; set; }      //收款账户余额
        public string BankNo { get; set; }          //银行编号
        //public string Ckxz { get; set; }            //存款性质
        //public string ExceptionCode { get; set; }      //异常代码
        //public string ExceptionMessage { get; set; }   //异常信息

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
