using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 监管账户扣款 银行到担保
    /// </summary>
    [XmlRoot("Message109")]
    public class Message109:BaseMessageRequest
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
        /// 银行编号
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }
        /// <summary>
        /// 扣款账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 扣款时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 扣款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 扣款原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }
        ///// <summary>
        ///// 异常代码
        ///// </summary>
        //public string ExceptionCode { get; set; }
        ///// <summary>
        ///// 异常信息
        ///// </summary>
        //public string ExceptionMessage { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message009 responseMsg = new Message009();
            responseMsg.SerialNo = SerialNo;
            responseMsg.PactNo = PactNo;
            responseMsg.Account = Account;
            responseMsg.Time = Time;
            responseMsg.BusinessCode = "009";
            responseMsg.Money = Money;
            responseMsg.Reason = Reason;
            responseMsg.Balances = Balances;
            responseMsg.CRCCode = CRCCode;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_MessageSrv.JG_Chargeback jc = new FundsRegulatoryClient.JG_MessageSrv.JG_Chargeback();
            //jc.CB_BusinessCode = BusinessCode;
            //jc.CB_BusinessTime = DateTime.Parse(BusinessTime);
            //jc.CB_SerialNo = SerialNo;
            //jc.CB_BankCode = BankCode;
            //jc.CB_PactNo = PactNo;
            //jc.CB_Account = Account;
            //jc.CB_Time = DateTime.Parse(Time);
            //jc.CB_Money = Money;
            //jc.CB_Reason = Reason;
            //jc.CB_Balances = Balances;
            //BaseMessageResponse responseMsg = GetReponseMessage();
            ////GetReponseMessage();
            //// 校验信息
            //// 如果失败 
            //// responseMsg.ExceptionCode ="";
            //// responseMsg.ExceptionMessage="...";
            //if (FundsRegulatoryClient.JG_MessageClient.Current.ChargebackAdd(jc))
            //{
            //    responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);
            //    responseMsg.ExceptionCode = "01";
            //    responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //}
            //return responseMsg;
            throw new NotImplementedException();
        }
    }
}
