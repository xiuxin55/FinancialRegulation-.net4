using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 应缴资金查询
    /// </summary>
    public class Request04 : BaseRequest
    {
        public Request04()
        {
            SetStruct();
        }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string paymentNum;//付款凭证编号

        public string PaymentNum
        {
            get { return paymentNum; }
            set { paymentNum = value; ValueDic["PaymentNum"] = value; }
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

            OrderDic.Add(4, "PaymentNum");
            ValueDic.Add("PaymentNum", null);
            PakageLengthDic.Add("PaymentNum", 10);
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
            //ValueDic["PackageLength"] = this.PackageLength; ;
            //ValueDic["BusinessCode"]=this.BusinessCode;
            //ValueDic["BankCode"]=this.BankCode;
            //ValueDic["PaymentNum"]=this.PaymentNum;
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
