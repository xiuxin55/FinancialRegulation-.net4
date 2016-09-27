using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 监管资金支付
    /// </summary>
  public  class Request05 : BaseRequest
    {
      public Request05()
        {
            SetStruct();
        }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
      private string paymentID;//企业经办人
      /// <summary>
      /// 付款凭证编号
      /// </summary>
      public string PaymentID
      {
          get { return paymentID; }
          set
          {
              paymentID = value; ValueDic["PaymentID"] = value;

          }
      }
        private decimal? paymentAmount;//支付金额

        public decimal? PaymentAmount
        {
            get { return paymentAmount; }
            set
            {
                paymentAmount = value; ValueDic["PaymentAmount"] = value.ToString(); ;
               
            }
        }
        private string firmOperatorName;//企业经办人

        public string FirmOperatorName
        {
            get { return firmOperatorName; }
            set
            {
                firmOperatorName = value; ValueDic["FirmOperatorName"] =value;
               
            }
        }
        private string firmOperatorID;
      /// <summary>
      /// 企业经办人证件号
      /// </summary>
        public string FirmOperatorID
        {
            get { return firmOperatorID; }
            set
            {
                firmOperatorID = value; ValueDic["FirmOperatorID"] = value;
                
            }
        }
        private string paymentBank;//支付银行

        public string PaymentBank
        {
            get { return paymentBank; }
            set
            {
                paymentBank = value; ValueDic["PaymentBank"] = value;
                
            }
        }
        private string bankSiteID;//银行网点号

        public string BankSiteID
        {
            get { return bankSiteID; }
            set
            {
                bankSiteID = value; ValueDic["BankSiteID"] =value;
                
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
        private string paymentInstr;//支付说明

        public string PaymentInstr
        {
            get { return paymentInstr; }
            set { paymentInstr = value; ValueDic["PaymentInstr"] = value; }
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

            OrderDic.Add(5, "PaymentAmount");
            ValueDic.Add("PaymentAmount", null);
            PakageLengthDic.Add("PaymentAmount", 18);

            OrderDic.Add(6, "FirmOperatorName");
            ValueDic.Add("FirmOperatorName", null);
            PakageLengthDic.Add("FirmOperatorName", 30);

            OrderDic.Add(7, "FirmOperatorID");
            ValueDic.Add("FirmOperatorID", null);
            PakageLengthDic.Add("FirmOperatorID", 20);

            OrderDic.Add(8, "PaymentBank");
            ValueDic.Add("PaymentBank", null);
            PakageLengthDic.Add("PaymentBank", 60);

            OrderDic.Add(9, "BankSiteID");
            ValueDic.Add("BankSiteID", null);
            PakageLengthDic.Add("BankSiteID", 10);

            OrderDic.Add(10, "BankTellerID");
            ValueDic.Add("BankTellerID", null);
            PakageLengthDic.Add("BankTellerID", 10);

            OrderDic.Add(11, "SerialNumber");
            ValueDic.Add("SerialNumber", null);
            PakageLengthDic.Add("SerialNumber", 20);

            OrderDic.Add(12, "PaymentInstr");
            ValueDic.Add("PaymentInstr", null);
            PakageLengthDic.Add("PaymentInstr", 100);
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
            //ValueDic["BankCode"]=this.BankCode ;
            //ValueDic["PaymentAmount"] = this.PaymentAmount.ToString(); ;
            //ValueDic["FirmOperatorName"]=this.FirmOperatorName;
            //ValueDic["FirmOperatorID"]=this.FirmOperatorID;
            //ValueDic["PaymentBank"]=this.PaymentBank;
            //ValueDic["BankSiteID"]=this.BankSiteID;
            //ValueDic["BankTellerID"]=this.BankTellerID;
            //ValueDic["SerialNumber"]=this.SerialNumber;
            //ValueDic["PaymentInstr"]=this.PaymentInstr;
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
