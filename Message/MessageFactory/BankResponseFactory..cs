using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Message.MessageFactory
{
    public class BankResponseFactory
    {
        public static BaseMessageResponse GetResponseMessage(string xmlstr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            XmlNodeList nodelist = doc.GetElementsByTagName("BusinessCode");
            BaseMessageResponse responsemessage = null;
            if (nodelist.Count == 0 || nodelist == null)
            {
                return responsemessage;
                //日志
            }
            //XmlNode n = nodelist[0].SelectSingleNode("UserName");
            XmlNode node = nodelist[0];
            switch (node.InnerText)
            {
                case "102":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message102>(xmlstr, Encoding.Unicode);
                    break;
                case "103":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message103>(xmlstr, Encoding.Unicode);
                    break;
                case "110":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message110>(xmlstr, Encoding.Unicode);
                    break;
                case "113":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message113>(xmlstr, Encoding.Unicode);
                    break;
                case "114":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message114>(xmlstr, Encoding.Unicode);
                    break;
                case "117":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message117>(xmlstr, Encoding.Unicode);
                    break;
                case "119":
                    responsemessage = XmlSerializerTools.FromXmlStr<Message119>(xmlstr, Encoding.Unicode);
                    break;
                case "198":
                    responsemessage = XmlSerializerTools.FromXmlStr<MessageSqlReturn198>(xmlstr, Encoding.Unicode);
                    break;
                default:
                    break;

            }
            return responsemessage;
        }
    }
}
