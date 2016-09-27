using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 不明账款缴存 银行到担保
    /// </summary>
    [XmlRoot("Message105")]
    public class Message105:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }      //交易代码
        //public string BusinessTime { get; set; }      //交易时间
        //public string SerialNo { get; set; }          //交易流水号
        //public string PactNo { get; set; }            //协议编号
        public string CorpCode { get; set; }          //企业名称
        public decimal Money { get; set; }            //存款金额
        public string NatureOfFunding { get; set; }   //资金性质(1非贷款2商业贷款、3公积金贷款)
        public string FromBbank { get; set; }         //存款银行
        public decimal Balances { get; set; }         //账户余额
        public string CRCCode { get; set; }           //CRC校验码

        public override BaseMessageResponse GetReponseMessage()
        {
            //throw new NotImplementedException();
            Message005 responseMsg = new Message005();
            responseMsg.PactNo = PactNo;
            responseMsg.CorpCode = CorpCode;
            responseMsg.Money = Money;
            responseMsg.NatureOfFunding = NatureOfFunding;
            responseMsg.FromBbank = FromBbank;
            responseMsg.Balances = Balances;
            responseMsg.CRCCode = CRCCode;
            responseMsg.BusinessCode = "005";
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            throw new NotImplementedException();
            //FundsRegulatoryClient.JG_DepositSrv.JG_DepositInfo de = new FundsRegulatoryClient.JG_DepositSrv.JG_DepositInfo();
            //de._DE_xybh = PactNo;
            //de._DE_ckje = Money;
            //de._DE_ckxz = NatureOfFunding;
            //de._DE_dwbh = FromBbank;
            //de._DE_zhye = Balances;
            //BaseMessageResponse responseMsg = GetReponseMessage();
            ////GetReponseMessage();
            //// 校验信息
            //// 如果失败 
            //// responseMsg.ExceptionCode ="";
            //// responseMsg.ExceptionMessage="...";
            //if (FundsRegulatoryClient.JG_DepositClient.Current.InsertDeposit(de))
            //{
            //    responseMsg.BusinessTime = DateTime.Now.ToString("");
            //    responseMsg.ExceptionCode = "01";
            //    responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //}
            //return responseMsg;
        }
    }
}
