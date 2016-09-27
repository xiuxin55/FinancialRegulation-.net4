using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 数据库要保存的字段
    /// </summary>
    public class MessageInfo
    {
        public string ID { get; set; }
        public string BankCode { get; set; }     //银行代码
        public string Content { get; set; }     //报文内容
        public string MessageDirect { get; set; }     //报文方向
        public DateTime? MessageTime { get; set; }         //时间
        public string WebsiteCode { get; set; } //网点号
        public string TellerCode { get; set; } //柜员号
    }
}
