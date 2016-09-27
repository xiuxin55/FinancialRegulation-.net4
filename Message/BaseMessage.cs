using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    [XmlRoot("Root")]
    public abstract class BaseMessage
    {
        public string BusinessCode { get; set; }     //交易代码
        public string BusinessTime { get; set; }     //交易时间
        public string SerialNo { get; set; }         //交易流水号

        public abstract bool SaveMessage(string xmlmessage);
    }
}
