using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 存款红冲 银行到担保
    /// </summary>
    [XmlRoot("Message106")]
    public class Message106:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }     //交易代码
        //public string BusinessTime { get; set; }     //交易时间
        //public string SerialNo { get; set; }         //交易流水号
        public string BankCode { get; set; }         //交易银行
        //public string PactNo { get; set; }           //协议编号
        public string CorpCode { get; set; }         //企业名称
        public string DepositNo { get; set; }        //存款流水号
        public decimal Money { get; set; }           //存款金额
        public string NatureOfFunding { get; set; }  //资金性质
        public decimal Balances { get; set; }        //账户余额

        public override BaseMessageResponse GetReponseMessage()
        {
            //throw new NotImplementedException();
            Message006 responseMsg = new Message006();
            responseMsg.BankCode = BankCode;
            responseMsg.PactNo = PactNo;
            responseMsg.CorpCode = CorpCode;
            responseMsg.DepositNo = DepositNo;
            responseMsg.Money = Money;
            responseMsg.NatureOfFunding = NatureOfFunding;
            responseMsg.Balances = Balances;
            responseMsg.BusinessCode = "006";
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //throw new NotImplementedException();
            //FundsRegulatoryClient.JG_MessageSrv.JG_DepositInfo de = new FundsRegulatoryClient.JG_MessageSrv.JG_DepositInfo();
            //de._DE_dwbh = BankCode;
            //de._DE_xybh = PactNo;
            //de._DE_cklsh = DepositNo;
            //de._DE_ckje = Money;
            //de._DE_ckxz = NatureOfFunding;
            //de._DE_zhye = Balances;
            //BaseMessageResponse responseMsg = GetReponseMessage();
            ////GetReponseMessage();
            //// 校验信息
            //// 如果失败 
            //// responseMsg.ExceptionCode ="";
            //// responseMsg.ExceptionMessage="...";
            //if (FundsRegulatoryClient.JG_MessageClient.Current.UpdateDepositForHongChong(de))
            //{
            //    responseMsg.BusinessTime = DateTime.Now.ToString("");
            //    responseMsg.ExceptionCode = "01";
            //    responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //}
            //return responseMsg;
            throw new NotImplementedException();
        }
    }    
}
