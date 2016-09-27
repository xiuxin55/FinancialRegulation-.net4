using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient.RegulatorySrv;

namespace Message
{
    /// <summary>
    /// 账户变更 担保到银行
    /// </summary>
    [XmlRoot("Message003")]
    public class Message003:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }      //交易代码
        //public string BusinessTime { get; set; }      //交易时间
        //public string SerialNo { get; set; }          //交易流水号
        //public string PactNo { get; set; }            //协议编号
        public string ContractRecordNo { get; set; }  //协议甲方
        public string CorpCode { get; set; }          //协议乙方
        public string Depositor { get; set; }         //协议丙方
        public string AccountA { get; set; }          //甲方账户
        public string AccountB { get; set; }          //乙方账户
        public string ItemName { get; set; }          //项目名称
        public string Site { get; set; }              //项目坐落
        public decimal Amount { get; set; }           //项目总金额
        public decimal FocusAmmont { get; set; }      //重点监管金额

        public override BaseMessageResponse GetReponseMessage()
        {
            //throw new NotImplementedException();
            Message103 responseMsg = new Message103();
            responseMsg.PactNo = PactNo;
            responseMsg.PartyA = ContractRecordNo;
            responseMsg.PartyB = CorpCode;
            responseMsg.PartyC = Depositor;
            responseMsg.AccountA = AccountA;
            responseMsg.AccountB = AccountB;
            responseMsg.ItemName = ItemName;
            responseMsg.Site = Site;
            responseMsg.Amount = Amount;
            responseMsg.FocusAmmont = FocusAmmont;
            responseMsg.BusinessCode = "103";

            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //throw new NotImplementedException();
            JG_SpvProtocol jspInfo = new JG_SpvProtocol();
            jspInfo.SP_XYBH = PactNo;
            jspInfo.SP_JGJG = ContractRecordNo;
            jspInfo.SP_CorpCode = CorpCode;
            jspInfo.SP_QYKHYH = Depositor;
            jspInfo.SP_ItemName = ItemName;
            jspInfo.SP_ItemSite = Site;
            jspInfo.SP_GCJSF = Amount;
            jspInfo.SP_ZDJGYSK = FocusAmmont;
            jspInfo.SP_JGJGZH = AccountA;
            jspInfo.SP_QYZH = AccountB;

            BaseMessageResponse responseMsg = GetReponseMessage();
            responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSTIMEFORMATE);
            responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo().ToString();
            if (FundsRegulatoryClient.RegulatoryClient.Current.ChangeProtocol(jspInfo))
            {
                responseMsg.BusinessTime = DateTime.Now.ToString();
                responseMsg.ExceptionCode = "01";
            }
            

            return responseMsg;
        }
    }
}
