using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    public class Request09 : BaseRequest
    {
        public Request09()
        {
            SetStruct();
            SetValue();
        }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value;
            ValueDic["FileName"] = value;
            }
        }
        private decimal? allAmount;//总额

        public decimal? AllAmount
        {
            get { return allAmount; }
            set { allAmount = value;
            ValueDic["AllAmount"] = value.ToString();
            }
        }
        private int recordCount;//登记数量

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value;
            ValueDic["RecordCount"] = value.ToString();
            }
        }
        private string instruction;//说明

        public string Instruction
        {
            get { return instruction; }
            set { instruction = value;
            ValueDic["Instruction"] = value;
            }
        }
      
        public Request09(string MessageInfo)
        {
            this.MessageInfo = MessageInfo;
            //SetStruct();
            //SetValue();
        }
        public override void SetStruct()
        {
            OrderDic = new Dictionary<int, string>();
            ValueDic = new Dictionary<string, string>();
            PakageLengthDic = new Dictionary<string, int>();
            //定义3个字典
            //OrderDic.Add(1, "PackageLength");
            //ValueDic.Add("PackageLength",null);
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

            OrderDic.Add(5, "AllAmount");
            ValueDic.Add("AllAmount", null);
            PakageLengthDic.Add("AllAmount", 18);

            OrderDic.Add(6, "RecordCount");
            ValueDic.Add("RecordCount", null);
            PakageLengthDic.Add("RecordCount", 10);

            OrderDic.Add(7, "Instruction");
            ValueDic.Add("Instruction", null);
            PakageLengthDic.Add("Instruction", 100);
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
            ////ValueDic["BankCode"]=this.BankCode ;
            //ValueDic["FileName"] = this.FileName;
            //ValueDic["AccountBalance"] = this.AccountBalance.ToString();
            //ValueDic["PlatformBalance"] = this.PlatformBalance;
            //ValueDic["AccoutCheckInstr"] = this.AccoutCheckInstr;
            if (MessageInfo != null && MessageInfo != "")
            {
                ;
            }
        }

        public override void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
