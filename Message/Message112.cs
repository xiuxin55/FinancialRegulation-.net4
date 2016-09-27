using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 不明账款补录银行到担保
    /// </summary>
    [XmlRoot("Message112")]
    public class Message112:BaseMessageRequest
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
        /// 原流水号
        /// </summary>
        public string FormerNo { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CorpCode { get; set; }
        /// <summary>
        /// 合同备案号
        /// </summary>
        public string ContractRecordNo { get; set; }
        /// <summary>
        /// 存款人
        /// </summary>
        public string Depositor { get; set; }
        /// <summary>
        /// 存款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 资金性质
        /// </summary>
        public string NatureOfFunding { get; set; }
        /// <summary>
        /// 存款银行
        /// </summary>
        public string FromBbank { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            //throw new NotImplementedException();
            Message012 responseMsg = new Message012();
            responseMsg.PactNo = PactNo;
            responseMsg.CorpCode = CorpCode;
            responseMsg.ContractRecordNo = ContractRecordNo;
            responseMsg.Depositor = Depositor;
            responseMsg.Money = Money;
            responseMsg.NatureOfFunding = NatureOfFunding;
            responseMsg.FromBbank = FromBbank;
            responseMsg.Balances = Balances;
            responseMsg.CRCCode = CRCCode;
            responseMsg.BusinessCode = "012";
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            throw new NotImplementedException();
            //FundsRegulatoryClient.JG_MessageSrv.JG_DepositInfo de =new FundsRegulatoryClient.JG_MessageSrv.JG_DepositInfo ();
            //de._DE_xybh = PactNo;
            //de._DE_qybh = ContractRecordNo;
            //de._DE_ckr = Depositor;
            //de._DE_ckje = Money;
            //de._DE_ckxz = NatureOfFunding;
            //de._DE_dwbh = FromBbank;
            //de._DE_zhye = Balances;
            //de._DE_cklsh = FormerNo;
            //BaseMessageResponse responseMsg = GetReponseMessage();
            ////GetReponseMessage();
            //// 校验信息
            //// 如果失败 
            //// responseMsg.ExceptionCode ="";
            //// responseMsg.ExceptionMessage="...";
            //if (FundsRegulatoryClient.JG_MessageClient.Current.UpdateDepositForUnknownMakeUp(de))
            //{
            //    responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);
            //    responseMsg.ExceptionCode = "01";
            //    responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //}
            //return responseMsg;
        }
    }
}
