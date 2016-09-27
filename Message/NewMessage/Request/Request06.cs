using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 当日交易冲正
    /// </summary>
    public  class Request06 : BaseRequest
    {
        public Request06()
        {
            SetStruct();
        }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string paymentID;//付款凭证编号

        public string PaymentID
        {
            get { return paymentID; }
            set
            {
                paymentID = value; ValueDic["PaymentID"] = value;
               
            }
        }
        private string reverseSerialNum;//冲正编号

        public string ReverseSerialNum
        {
            get { return reverseSerialNum; }
            set
            {
                reverseSerialNum = value; ValueDic["ReverseSerialNum"] = value;
               
            }
        }
        private string reverseBank;//冲正银行

        public string ReverseBank
        {
            get { return reverseBank; }
            set
            {
                reverseBank = value; ValueDic["ReverseBank"] = value;
              
            }
        }
        private string bankSiteID;//银行网点号

        public string BankSiteID
        {
            get { return bankSiteID; }
            set
            {
                bankSiteID = value; ValueDic["BankSiteID"] = value;
                
            }
        }
        private string bankTellerID;//银行柜员号

        public string BankTellerID
        {
            get { return bankTellerID; }
            set
            {
                bankTellerID = value; ValueDic["BankTellerID"] = value;
                
            }
        }
        private string reverseInstr;//冲正说明

        public string ReverseInstr
        {
            get { return reverseInstr; }
            set { reverseInstr = value; ValueDic["ReverseInstr"] =value; }
        }
        private string reverseType;//冲正类型

        public string ReverseType
        {
            get { return reverseInstr; }
            set { reverseInstr = value; ValueDic["ReverseType"] = value; }
        }

        public override void SetStruct()
        {
            OrderDic = new Dictionary<int, string>();
            ValueDic = new Dictionary<string, string>();
            PakageLengthDic = new Dictionary<string, int>();
            //定义3个字典
            //OrderDic.Add(1, "PackageLength");
            //ValueDic.Add("PackageLength", null);
            //PakageLengthDic.Add("PackageLength", 6);

            OrderDic.Add(2, "BusinessCode");
            ValueDic.Add("BusinessCode", null);
            PakageLengthDic.Add("BusinessCode", 2);

            OrderDic.Add(3, "BankCode");
            ValueDic.Add("BankCode", null);
            PakageLengthDic.Add("BankCode", 2);

            OrderDic.Add(4, "PaymentID");
            ValueDic.Add("PaymentID", null);
            PakageLengthDic.Add("PaymentID", 10);

            OrderDic.Add(5, "ReverseSerialNum");
            ValueDic.Add("ReverseSerialNum", null);
            PakageLengthDic.Add("ReverseSerialNum", 20);

            OrderDic.Add(6, "ReverseBank");
            ValueDic.Add("ReverseBank", null);
            PakageLengthDic.Add("ReverseBank", 60);

            OrderDic.Add(7, "BankSiteID");
            ValueDic.Add("BankSiteID", null);
            PakageLengthDic.Add("BankSiteID", 10);

            OrderDic.Add(8, "BankTellerID");
            ValueDic.Add("BankTellerID", null);
            PakageLengthDic.Add("BankTellerID", 10);

            OrderDic.Add(9, "ReverseInstr");
            ValueDic.Add("ReverseInstr", null);
            PakageLengthDic.Add("ReverseInstr", 100);
            OrderDic.Add(10, "ReverseType");
            ValueDic.Add("ReverseType", null);
            PakageLengthDic.Add("ReverseType", 2);
            int pack = 0;
            foreach (KeyValuePair<string, int> temp in PakageLengthDic)
            {
                pack += temp.Value;
            }
            pack += 6;
            OrderDic.Add(1, "PackageLength");
            ValueDic.Add("PackageLength", pack.ToString());
            PakageLengthDic.Add("PackageLength", 6);
        }

        public override void SetValue()
        {
            //ValueDic["PackageLength"]=this.PackageLength ;
            //ValueDic["BusinessCode"]=this.BusinessCode ;
            //ValueDic["BankCode"]=this.BankCode;
            //ValueDic["PaymentID"]=this.PaymentID;
            //ValueDic["ReverseSerialNum"]=this.ReverseSerialNum;
            //ValueDic["ReverseBank"]=this.ReverseBank;
            //ValueDic["BankSiteID"]=this.BankSiteID;
            //ValueDic["BankTellerID"]=this.BankTellerID;
            //ValueDic["ReverseInstr"]=this.ReverseInstr;
            if (MessageInfo != null && MessageInfo != "")
            {
            }
        }

        public override void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
