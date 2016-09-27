using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 银行发送消息的基础类
    /// </summary>
    public abstract class BaseRequest:Message
    {
        private string bankCode;

        public string BankCode
        {
            get { return bankCode; }
            set { bankCode = value; ValueDic["BankCode"] = value; }
        }
        public override bool SaveMessage(string WebsiteCode, string TellerCode)
        {
            if (MessageInfo != null && MessageInfo != "")
            {
                FundsRegulatoryClient.JG_MessageInfoClient Mclient = FundsRegulatoryClient.JG_MessageInfoClient.Instance;
                FundsRegulatoryClient.JG_MessageInfoSrv.MessageInfo mi = new FundsRegulatoryClient.JG_MessageInfoSrv.MessageInfo();
                mi.ID = Guid.NewGuid().ToString();
                mi.TellerCode = TellerCode;
                mi.WebsiteCode = WebsiteCode;
                mi.Content = MessageInfo.Trim('\0');
                mi.BankCode = BankCode;
                mi.MessageTime = DateTime.Now;
                mi.MessageDirect = "1";//1 代表发送 2代表接收
                if (Mclient.Add(mi))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
       
    }
}
