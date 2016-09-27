using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 支付请求确认银行到担保
    /// </summary>
    [XmlRoot("Message111")]
    public class Message111:BaseMessageRequest
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
        /// 原交易流水号
        /// </summary>
        public string FormerNo { get; set; }
        /// <summary>
        /// 交易银行
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PaymentAccount { get; set; }
        /// <summary>
        /// 支取人
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// 支取账户
        /// </summary>
        public string PayeeAccount { get; set; }
        /// <summary>
        /// 支取金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }


        public override BaseMessageResponse GetReponseMessage()
        {
            Message011 responseMsg = new Message011();
            responseMsg.BusinessCode = "011";
            responseMsg.FormerNo = FormerNo;
            responseMsg.BankCode = BankCode;
            responseMsg.PactNo = PactNo;
            responseMsg.PaymentAccount = PaymentAccount;
            responseMsg.Payee = Payee;
            responseMsg.PayeeAccount = PayeeAccount;
            responseMsg.Money = Money;
            responseMsg.Balances = Balances;
            responseMsg.CRCCode = CRCCode;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_MessageSrv.JG_PaymentInfo jp = new FundsRegulatoryClient.JG_MessageSrv.JG_PaymentInfo();
            //jp.PA_zfqrlsh = BusinessCode;
            //jp.PA_yhzfrq = DateTime.Parse(BusinessTime);
            //jp.PA_zfqrlsh = SerialNo;
            //jp.PA_zfqqlsh = FormerNo;
            //jp.PA_fkBank = BankCode;
            //jp.PA_xybh = PactNo;
            //jp.PA_skfzh = PaymentAccount;
            //jp.PA_sqr = Payee;
            //jp.PA_fkfzh = PayeeAccount;
            //jp.PA_zfje = Money;
            //jp.PA_zhye = Balances;
            //BaseMessageResponse responseMsg = GetReponseMessage();

            //FundsRegulatoryClient.JG_MessageSrv.JG_PaymentInfo[] jps = FundsRegulatoryClient.JG_MessageClient.Current.PaymentApplyInfoByConditionGet(jp);
            //if (jps.Length == 0)
            //{

            //}
            //else
            //{
            //    if (Money == jps[0].PA_zfje)
            //    {
            //        //GetReponseMessage();
            //        // 校验信息
            //        // 如果失败 
            //        // responseMsg.ExceptionCode ="";
            //        // responseMsg.ExceptionMessage="...";
            //        if (FundsRegulatoryClient.JG_MessageClient.Current.PaymentCompleteUpdate(jp))
            //        {
            //            responseMsg.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.CurrentTimeServer().ToString(Common.SysConst.BUSINESSDATEFORMATE);
            //            responseMsg.ExceptionCode = "01";
            //            responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //        }
            //    }
            //}

            //return responseMsg;
            throw new NotImplementedException();
        }
    }
}
