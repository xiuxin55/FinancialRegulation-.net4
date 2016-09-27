using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    public class UnknowBill
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string UB_BankCode { get; set; }
        //public string FileName  { get; set; }
        //public decimal? AllAmount { get; set; }//总额
        //public int RecordCount { get; set; }//登记数量
        //public string  Instruction { get; set; }//说明
        public string UB_ID { get; set; }
        public string UB_FirmName { get; set; }//开发商名字
        public string UB_ManageAccount { get; set; }//监管账户
        public decimal? UB_Money { get; set; }//金额
        public DateTime? UB_Time { get; set; }//到账时间
        public string UB_PayerName { get; set; }//付款人名称
        public string UB_PayerAccount { get; set; }//付款账户
        public string UB_Type { get; set; }//不明账款类型
        public string UB_BankSerialNum { get; set; }//银行流水号
        public string UB_SerialNum { get; set; }//系统流水号
        public string UB_BankSiteID { get; set; }//网点号
        public string UB_BankTellerID { get; set; }//柜员号
        public string UB_Remark { get; set; }//说明
        public string UB_State { get; set; }//状态
        public string UB_LinkStr { get; set; }//记录的字符串
            
    }
}
