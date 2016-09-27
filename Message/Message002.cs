using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient.RegulatorySrv;

namespace Message
{
    /// <summary>
    /// 协议确认 担保到银行
    /// </summary>
    [XmlRoot("Message002")]
    public class Message002:BaseMessageRequest
    {
        //public string BusinessCode { get; set; } //交易代码
        //public string BusinessTime { get; set; } //交易时间
        //public string SerialNo { get; set; }     //交易流水号10位流水号
        //public string PactNo { get; set; }       //协议编号
        public string PartyA { get; set; }       //协议甲方(监管机构)
        public string PartyB { get; set; }       //协议乙方(开发企业)
        public string CorpCode { get; set; }     //协议乙方（开发企业编号）
        public string PartyC { get; set; }       //协议丙方(监管银行)
        public string AccountA { get; set; }     //甲方账户
        public string AccountB { get; set; }     //乙方账户
        public string ItemName { get; set; }     //项目名称
        public string Site { get; set; }         //项目坐落
        public decimal Amount { get; set; }      //项目总金额
        public decimal FocusAmmont { get; set; } //重点监管金额

        public override BaseMessageResponse GetReponseMessage()
        {
            Message102 responseMsg = new Message102();
            responseMsg.BusinessCode = "102";
            responseMsg.PactNo = PactNo;
            responseMsg.PartyA = PartyA;
            responseMsg.PartyB = PartyB;
            responseMsg.PartyC = PartyC;
            responseMsg.AccountA = AccountA;
            responseMsg.AccountB = AccountB;
            responseMsg.ItemName = ItemName;
            responseMsg.Site = Site;
            responseMsg.Amount = Amount;
            responseMsg.FocusAmmont = FocusAmmont;
            return responseMsg;
        }
        /// <summary>
        /// 协议信息保存
        /// </summary>
        /// <returns></returns>
        public override BaseMessageResponse MeaasgeOperate() 
        {
            BaseMessageResponse responseMsg = GetReponseMessage();
            responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo().ToString();
            responseMsg.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);

            JG_SpvProtocol js = new JG_SpvProtocol();
            js.SP_XYBH = PactNo;
            js.SP_JGJG = PartyA;
            js.SP_CorpName = PartyB;
            js.SP_QYKHYH = PartyC;
            js.SP_JGJGZH = AccountA;
            js.SP_QYZH = AccountB;
            js.SP_ItemName = ItemName;
            js.SP_ItemSite = Site;
            js.SP_GCJSF = Amount;
            js.SP_ZDJGYSK = FocusAmmont;
            js.SP_CorpCode = CorpCode;
            if (FundsRegulatoryClient.RegulatoryClient.Current.ProtocolSave(js))
            {
                responseMsg.ExceptionCode = "01";
            }
            return responseMsg;
        }
    }
}
