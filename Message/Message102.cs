using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 协议确认响应 银行到担保
    /// </summary>
    [XmlRoot("Message102")]
    public class Message102:BaseMessageResponse
    {
        //public string BusinessCode { get; set; }       //交易代码
        //public string BusinessTime { get; set; }       // 交易时间
        //public string SerialNo { get; set; }           //交易流水号
        //public string PactNo { get; set; }             //协议编号
        public string PartyA { get; set; }             //协议甲方
        public string PartyB { get; set; }             //协议乙方
        public string PartyC { get; set; }             //协议丙方
        public string AccountA { get; set; }           //甲方账户
        public string AccountB { get; set; }           //乙方账户
        public string ItemName { get; set; }           //项目名称
        public string Site { get; set; }               //项目坐落
        public decimal Amount { get; set; }            //项目总金额
        public decimal FocusAmmont { get; set; }       //重点监管金额
        //public string ExceptionCode { get; set; }      //异常代码
        //public string ExceptionMessage { get; set; }   //异常信息

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
