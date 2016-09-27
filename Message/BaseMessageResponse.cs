using System;
using System.Collections.Generic;
using System.Text;
using FundsRegulatoryClient.RegulatorySrv;
using System.Xml;

namespace Message
{
    public abstract class BaseMessageResponse : BaseMessage
    {
        public string PactNo { get; set; }
        public string ExceptionCode { get; set; }
        public string ExceptionMessage { get; set; }
        private JG_MessageInfo mi;
        public override bool SaveMessage(string xmlmessage)
        {
            if (xmlmessage == null || xmlmessage.Length == 0)
                return false;
            mi = new JG_MessageInfo();
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xmlmessage);
            mi._MI_Id = Guid.NewGuid();
            //mi._MI_Jydm = doc.GetElementsByTagName("BusinessCode")[0].InnerText;
            //mi._MI_DzTime = doc.GetElementsByTagName("BusinessTime")[0].InnerText;
            //mi._MI_Bwlsh = doc.GetElementsByTagName("SerialNo")[0].InnerText;

            mi._MI_Jydm = BusinessCode;
            mi._MI_DzTime = BusinessTime;
            mi._MI_Bwlsh = SerialNo;

            //mi._MI_xybh = doc.GetElementsByTagName("PactNo")[0].InnerText;
            mi._MI_xybh = PactNo;
            mi._MI_Bwnr = xmlmessage;
            mi._MI_Bwfx = BusinessCode.Substring(0, 1);

            return FundsRegulatoryClient.RegulatoryClient.Current.AddJG_MessageInfo(mi);
        }
        public abstract bool MeaasgeOperate();
    }
}
