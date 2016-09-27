using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Message.MessageFactory
{
    public class SpvMessageFactory
    {
        public static BaseMessageRequest GetMessage(string xmlstr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            XmlNodeList nodelist = doc.GetElementsByTagName("BusinessCode");
            BaseMessageRequest requestmessage = null;
            if (nodelist.Count == 0 || nodelist == null)
            {
                return requestmessage;
                //日志
            }
            //XmlNode n = nodelist[0].SelectSingleNode("UserName");
            XmlNode node = nodelist[0];
            switch (node.InnerText)
            {
                case "002":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message002>(xmlstr, Encoding.Unicode);
                    break;
                case "003":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message003>(xmlstr, Encoding.Unicode);
                    break;
                case "010":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message010>(xmlstr, Encoding.Unicode);
                    break;
                case "013":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message013>(xmlstr, Encoding.Unicode);
                    break;
                case "014":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message014>(xmlstr, Encoding.Unicode);
                    break;
                case "017":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message017>(xmlstr, Encoding.Unicode);
                    break;
                case "019":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message019>(xmlstr, Encoding.Unicode);
                    break;
                case "098":
                    requestmessage = XmlSerializerTools.FromXmlStr<MessageSqlReturn098>(xmlstr, Encoding.Unicode);
                    break;
                default:
                    break;

            }
            return requestmessage;
        }
    }
}
