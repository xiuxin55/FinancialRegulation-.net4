using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class JG_MessageInfo
    {
        public Guid _MI_Id { get; set; }
        public string _MI_xybh { get; set; }     //协议编号
        public string _MI_Bwlsh { get; set; }    //报文流水号
        public string _MI_Jydm { get; set; }     //监管代码
        public string _MI_DzTime { get; set; }   //交易时间
        public string _MI_Bwnr { get; set; }     //报文内容
        public string _MI_Bwfx { get; set; }     //报文方向
    }
}
