using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 资金缴存 银行到担保
    /// </summary>
    [XmlRoot("Message104")]
    public class Message104:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }      //交易代码
        //public string BusinessTime { get; set; }      //交易时间
        //public string SerialNo { get; set; }          //交易流水号
        //public string PactNo { get; set; }            //协议编号
        public string ContractRecordNo { get; set; }  //合同备案号
        public string CorpCode { get; set; }          //企业名称
        public string Depositor { get; set; }         //存款人
        public decimal Money { get; set; }            //存款金额
        public string NatureOfFunding { get; set; }   //资金性质
        public string FromBbank { get; set; }         //存款银行
        public decimal Balances { get; set; }         //账户余额
        public string CRCCode { get; set; }           //CRC校验码

        public override BaseMessageResponse GetReponseMessage()
        {
            Message004 responseMsg = new Message004();
            responseMsg.BusinessCode = "004";
            responseMsg.PactNo = PactNo;
            responseMsg.ContractRecordNo = this.ContractRecordNo;
            responseMsg.CorpCode = CorpCode;
            responseMsg.Depositor = Depositor;
            responseMsg.Money = Money;
            responseMsg.NatureOfFunding = NatureOfFunding;
            responseMsg.FromBbank = FromBbank;
            responseMsg.Balances = Balances;
            responseMsg.CRCCode = CRCCode;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_DepositSrv.JG_DepositInfo dep = null;
            //dep = new FundsRegulatoryClient.JG_DepositSrv.JG_DepositInfo();
            //dep._DE_ckje = Money;
            //dep._DE_cklb = "1";
            //dep._DE_cklsh = SerialNo;
            //dep._DE_ckr = Depositor;
            //dep._DE_ckrq = DateTime.Parse(BusinessTime);
            //dep._DE_ckxz = NatureOfFunding;
            //dep._DE_dwbh = FromBbank;
            //dep._DE_qybh = ContractRecordNo;
            //dep._DE_xybh = PactNo;
            ////数据校验
            ////...
            //BaseMessageResponse bmr = GetReponseMessage();
            //if (JG_DepositClient.Current.InsertDeposit(dep))
            //{
            //    bmr.ExceptionCode = "01";
            //}

            //return bmr;
            throw new NotImplementedException();
        }
    }
}
