using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Message.MessageFactory
{
    public class BankMessageFactory
    {
        public static BaseMessageRequest GetMessage(string xmlstr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            XmlNodeList nodelist = doc.GetElementsByTagName("BusinessCode");
            BaseMessageRequest requestmessage=null;
            if (nodelist.Count == 0 || nodelist == null)
            {
                return requestmessage;
                //日志
            }
            //XmlNode n = nodelist[0].SelectSingleNode("UserName");
            XmlNode node = nodelist[0];
            switch (node.InnerText)
            {
                case "101":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message101>(xmlstr, Encoding.Unicode);
                    break;
                case "104":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message104>(xmlstr, Encoding.Unicode);
                    break;
                case "105":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message105>(xmlstr, Encoding.Unicode);
                    break;
                case "106":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message106>(xmlstr, Encoding.Unicode);
                    break;
                case "107":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message107>(xmlstr, Encoding.Unicode);
                    break;
                case "108":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message108>(xmlstr, Encoding.Unicode);
                    break;
                case "109":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message109>(xmlstr, Encoding.Unicode);
                    break;
                case "111":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message111>(xmlstr, Encoding.Unicode);
                    break;
                case "112":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message112>(xmlstr, Encoding.Unicode);
                    break;
                case "115":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message115>(xmlstr, Encoding.Unicode);
                    break;
                case "116":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message116>(xmlstr, Encoding.Unicode);
                    break;
                case "118":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message118>(xmlstr, Encoding.Unicode);
                    break;
                case "120":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message120>(xmlstr, Encoding.Unicode);
                    break;
                case "199":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message199>(xmlstr, Encoding.Unicode);
                    break;
                case "130":
                    requestmessage = XmlSerializerTools.FromXmlStr<Message130>(xmlstr, Encoding.Unicode);
                    break;
                default:
                    break;
            }
            return requestmessage;
        }
    }
}
