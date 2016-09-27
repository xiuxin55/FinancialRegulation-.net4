using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 开户 银行到担保
    /// </summary>
    [XmlRoot("Message101")]
    public class Message101:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }    //交易代码
        //public string BusinessTime { get; set; }    //交易时间
        //public string SerialNo { get; set; }        //交易流水号(银行代码加8位流水号)
        public string BankCode { get; set; }        //银行代码两位
        public string CorpCode { get; set; }        //企业代码
        public string CorpName { get; set; }        //企业名称
        public string AccountName { get; set; }     //账户名称
        public string Account { get; set; }         //账号

        public override BaseMessageResponse GetReponseMessage()
        {
            Message001 responseMsg = new Message001();
            responseMsg.Account = Account;
            responseMsg.AccountName = AccountName;
            responseMsg.BankCode = BankCode;
            responseMsg.BusinessCode = "001";
            responseMsg.CorpCode = CorpCode;
            responseMsg.CorpName = CorpName;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo am = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
            //am._AM_ID = Guid.NewGuid();
            //am._AM_BankName = BankCode;
            //am._AM_CorpName = CorpName;
            //am._AM_CorpCode = CorpCode;
            //am._AM_JgAccount = Account;
            //am._AM_zhmc = AccountName;
            //am._AM_CreateDate = DateTime.Parse(BusinessTime);
            //BaseMessageResponse responseMsg = GetReponseMessage();
            ////GetReponseMessage();
            //// 校验信息
            //// 如果失败 
            //// responseMsg.ExceptionCode ="";
            //// responseMsg.ExceptionMessage="...";
            //if (JG_AccountManageClient.Current.AddAccountManage(am))
            //{
            //    responseMsg.BusinessTime = DateTime.Now.ToString("");
            //    responseMsg.ExceptionCode = "01";
            //}
            //return responseMsg;
            throw new NotImplementedException();
        }
    }
}
