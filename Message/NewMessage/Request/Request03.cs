using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    public class Request03 : BaseRequest
    {
        public Request03()
        { SetStruct(); }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string depositID;//缴款凭证编号

        public string DepositID
        {
            get { return depositID; }
            set
            {
                depositID = value; ValueDic["DepositID"] = value;
               
            }
        }
        private decimal? depositAmount;//缴款金额

        public decimal? DepositAmount
        {
            get { return depositAmount; }
            set
            {
                depositAmount = value; ValueDic["DepositAmount"] = value.ToString();
               
            }
        }
        private string purchaserName;

        public string PurchaserName
        {
            get { return purchaserName; }
            set
            {
                purchaserName = value; ValueDic["PurchaserName"] = value;
               
            }
        }
        private string purchaserID;//购房人证件号

        public string PurchaserID
        {
            get { return purchaserID; }
            set
            {
                purchaserID = value; ValueDic["PurchaserID"] = value;
                
            }
        }
        private string bankName;//缴款银行名称

        public string BankName
        {
            get { return bankName; }
            set
            {
                bankName = value; ValueDic["BankName"] = value;
           
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
        private string serialNumber;//流水号

        public string SerialNumber
        {
            get { return serialNumber; }
            set
            {
                serialNumber = value; ValueDic["SerialNumber"] = value;
                
            }
        }
        private string depositInstr;//缴款说明

        public string DepositInstr
        {
            get { return depositInstr; }
            set { depositInstr = value; ValueDic["DepositInstr"] = value; }
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

            OrderDic.Add(4, "DepositID");
            ValueDic.Add("DepositID", null);
            PakageLengthDic.Add("DepositID", 10);

            OrderDic.Add(5, "DepositAmount");
            ValueDic.Add("DepositAmount", null);
            PakageLengthDic.Add("DepositAmount", 18);

            OrderDic.Add(6, "PurchaserName");
            ValueDic.Add("PurchaserName", null);
            PakageLengthDic.Add("PurchaserName", 100);

            OrderDic.Add(7, "PurchaserID");
            ValueDic.Add("PurchaserID", null);
            PakageLengthDic.Add("PurchaserID", 20);

            OrderDic.Add(8, "BankName");
            ValueDic.Add("BankName", null);
            PakageLengthDic.Add("BankName", 60);

            OrderDic.Add(9, "BankSiteID");
            ValueDic.Add("BankSiteID", null);
            PakageLengthDic.Add("BankSiteID", 10);

            OrderDic.Add(10, "BankTellerID");
            ValueDic.Add("BankTellerID", null);
            PakageLengthDic.Add("BankTellerID", 10);

            OrderDic.Add(11, "SerialNumber");
            ValueDic.Add("SerialNumber", null);
            PakageLengthDic.Add("SerialNumber", 20);

            OrderDic.Add(12, "DepositInstr");
            ValueDic.Add("DepositInstr", null);
            PakageLengthDic.Add("DepositInstr", 100);
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
            //ValueDic["PackageLength"]=this .PackageLength ;
            //ValueDic["BusinessCode"]=this.BusinessCode ;
            //ValueDic["BankCode"]=this.BankCode ;
            //ValueDic["DepositNum"]=this.DepositNum;
            //ValueDic["DepositAmount"]=this.DepositAmount.ToString();
            //ValueDic["PurchaserName"]=this.PurchaserName;
            //ValueDic["PurchaserID"]=this.PurchaserID;
            //ValueDic["BankName"]=this.BankName;
            //ValueDic["BankSiteID"]=this.BankSiteID;
            //ValueDic["BankTellerID"]=this.BankTellerID;
            //ValueDic["SerialNumber"]=this.SerialNumber ;
            //ValueDic["DepositInstr"]=this.DepositInstr;
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
