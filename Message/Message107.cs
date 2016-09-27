using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 资金归集  银行到担保
    /// </summary>
    [XmlRoot("Message107")]
    public class Message107 : BaseMessageRequest
    {
        //public string BusinessCode { get; set; }    //交易代码
        //public string BusinessTime { get; set; }    //交易时间
        //public string SerialNo { get; set; }        //交易流水号
        //public string PactNo { get; set; }           //协议编号
        public string PaymentAccount { get; set; }  //付款账户  
        public string Payer { get; set; }           //付款人
        public string PayeeAccount { get; set; }    //收款账户
        public string Payee { get; set; }           //收款人
        public decimal Money { get; set; }          //交易金额
        public decimal Balances1 { get; set; }      //付款账户余额
        public decimal Balances2 { get; set; }      //收款账户余额
        public string BankNo { get; set; }          //银行编号
        //public string Ckxz {get;set; }             //存款性质

        public override BaseMessageResponse GetReponseMessage()
        {
            Message007 responseMsg = new Message007();
            responseMsg.BusinessCode = "007";
            responseMsg.PactNo = PactNo;
            responseMsg.PaymentAccount = PaymentAccount;
            responseMsg.Payer = Payer;
            responseMsg.PayeeAccount = PayeeAccount;
            responseMsg.Payee = Payee;
            responseMsg.Money = Money;
            responseMsg.Balances1 = Balances1;
            responseMsg.Balances2 = Balances2;
            responseMsg.BankNo = BankNo;
            //responseMsg.Ckxz = Ckxz;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo jacInfo = null;
            //jacInfo = new FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo();
            //jacInfo.AC_cklsh = SerialNo;
            //jacInfo.AC_xybh = PactNo;
            //jacInfo.AC_fkfzh = PaymentAccount;
            //jacInfo.AC_fkr = Payer;
            //jacInfo.AC_skfzh = PayeeAccount;
            //jacInfo.AC_skr = Payee;
            //jacInfo.AC_ckje = Money;
            //jacInfo.AC_fkzhye = Balances1;
            //jacInfo.AC_skzhye = Balances2;
            //jacInfo.AC_cksj = Convert.ToDateTime(BusinessTime);
            //jacInfo.AC_ckxz = "0";

            //BaseMessageResponse bmr = GetReponseMessage();
            //if (JG_AmountCollectClient.Current.AddAmountCollectInfo(jacInfo))
            //{
            //    bmr.BusinessTime = DateTime.Now.ToString();
            //    bmr.ExceptionCode = "01";
            //}
            //return bmr;
            throw new NotImplementedException();
        }
    }
}
