using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Message.MessageFactory
{
    public class SpvResponseFactory
    {
        public static BaseMessageResponse GetResponseMessage(string xmlstr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            XmlNodeList nodelist = doc.GetElementsByTagName("BusinessCode");
            BaseMessageResponse responsetmessage = null;
            if (nodelist.Count == 0 || nodelist == null)
            {
                return responsetmessage;
                //日志
            }
            //XmlNode n = nodelist[0].SelectSingleNode("UserName");
            XmlNode node = nodelist[0];
            switch (node.InnerText)
            {
                case "001":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message001>(xmlstr, Encoding.Unicode);
                    break;
                case "004":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message004>(xmlstr, Encoding.Unicode);
                    break;
                case "005":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message005>(xmlstr, Encoding.Unicode);
                    break;
                case "006":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message006>(xmlstr, Encoding.Unicode);
                    break;
                case "007":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message007>(xmlstr, Encoding.Unicode);
                    break;
                case "008":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message008>(xmlstr, Encoding.Unicode);
                    break;
                case "009":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message009>(xmlstr, Encoding.Unicode);
                    break;
                case "011":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message011>(xmlstr, Encoding.Unicode);
                    break;
                case "012":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message012>(xmlstr, Encoding.Unicode);
                    break;
                case "015":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message015>(xmlstr, Encoding.Unicode);
                    break;
                case "016":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message016>(xmlstr, Encoding.Unicode);
                    break;
                case "018":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message018>(xmlstr, Encoding.Unicode);
                    break;
                case "020":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message020>(xmlstr, Encoding.Unicode);
                    break;
                case "030":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message030>(xmlstr, Encoding.Unicode);
                    break;
                case "099":
                    responsetmessage = XmlSerializerTools.FromXmlStr<Message099>(xmlstr, Encoding.Unicode);
                    break;
                default:
                    break;

            }
            return responsetmessage;
        }
    }
}
