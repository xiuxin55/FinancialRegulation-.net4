using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    /// <summary>
    /// 利息补录
    /// </summary>
    public class Request07:BaseRequest
    {
        public Request07()
        {
            SetStruct();
        }
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string fileName;//文件名

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value; ValueDic["FileName"] = value;
            }
        }
        private decimal? platInterestAmount;//平台利息

        public decimal? PlatInterestAmount
        {
            get { return platInterestAmount; }
            set
            {
                platInterestAmount = value; ValueDic["PlatInterestAmount"] = value.ToString();
              
            }
        }
        private decimal? realInterestAmount;//实际利息

        public decimal? RealInterestAmount
        {
            get { return realInterestAmount; }
            set
            {
                realInterestAmount = value; ValueDic["RealInterestAmount"] = value.ToString();

            }
        }
        
        private int recordCount;//登记数量

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; ValueDic["RecordCount"] = value.ToString(); }
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

            OrderDic.Add(4, "FileName");
            ValueDic.Add("FileName", null);
            PakageLengthDic.Add("FileName", 20);

            OrderDic.Add(5, "RealInterestAmount");
            ValueDic.Add("RealInterestAmount", null);
            PakageLengthDic.Add("RealInterestAmount", 18);

            OrderDic.Add(6, "PlatInterestAmount");
            ValueDic.Add("PlatInterestAmount", null);
            PakageLengthDic.Add("PlatInterestAmount", 18);

            OrderDic.Add(7, "RecordCount");
            ValueDic.Add("RecordCount", null);
            PakageLengthDic.Add("RecordCount", 10);
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
            //ValueDic["DepositNum"]=this.DepositNum ;
            //ValueDic["InterestAmount"]=this.InterestAmount.ToString();
            //ValueDic["ProjectCode"]=this.ProjectCode ;
            //ValueDic["RecordInstr"]=this.RecordInstr ;
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
