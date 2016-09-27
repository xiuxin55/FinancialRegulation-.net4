using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 退票交易
    /// </summary>
    public class Request08:BaseRequest
    {
        public Request08()
        {
            SetStruct();
        }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string paymentID;//支付凭证编号

        public string PaymentID
        {
            get { return paymentID; }
            set
            {
                paymentID = value; ValueDic["PaymentID"] = value;
                
            }
        }
        private decimal? refundAmount;//退票金额

        public decimal? RefundAmount
        {
            get { return refundAmount; }
            set
            {
                refundAmount = value; ValueDic["RefundAmount"] =value.ToString();
                
            }
        }
        private string refundInstr;//退票说明

        public string RefundInstr
        {
            get { return refundInstr; }
            set { refundInstr = value; ValueDic["RefundInstr"] = value; }
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

            OrderDic.Add(5, "RefundAmount");
            ValueDic.Add("RefundAmount", null);
            PakageLengthDic.Add("RefundAmount", 18);

            OrderDic.Add(6, "RefundInstr");
            ValueDic.Add("RefundInstr", null);
            PakageLengthDic.Add("RefundInstr", 100);
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
            //ValueDic["BusinessCode"]=this.BusinessCode;
            //ValueDic["BankCode"]=this.BankCode;
            //ValueDic["PaymentID"]=this.PaymentID;
            //ValueDic["RefundAmount"]=this.RefundAmount.ToString() ;
            //ValueDic["RefundInstr"]=this.RefundInstr;
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
