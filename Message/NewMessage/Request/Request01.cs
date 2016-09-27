using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Request
{
    public class Request01 : BaseRequest
    {
        //public string PackageLength { get; set; }
        //public string BusinessCode { get; set; }
        //public string BankCode { get; set; }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value; ValueDic["FileName"] = value ;
              
            }
        }
        private decimal accountBalance;
        /// <summary>
        /// 账务余额
        /// </summary>
        public decimal AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value;
            ValueDic["AccountBalance"] = value.ToString();
           
            }
        }
        private string platformBalance;
        /// <summary>
        /// 平台余额
        /// </summary>
        public string PlatformBalance
        {
            get { return platformBalance; }
            set { platformBalance = value;
            ValueDic["PlatformBalance"] = value ;
           
            }
        }
        private string accoutCheckInstr;//对账说明

        public string AccoutCheckInstr
        {
            get { return accoutCheckInstr; }
            set { accoutCheckInstr = value;
            ValueDic["AccoutCheckInstr"] = value;
            }
        }

        public Request01()
        {
            SetStruct();
            SetValue();
        }
        public Request01(string MessageInfo)
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

            OrderDic.Add(5, "AccountBalance");
            ValueDic.Add("AccountBalance", null);
            PakageLengthDic.Add("AccountBalance", 18);

            OrderDic.Add(6, "PlatformBalance");
            ValueDic.Add("PlatformBalance", null);
            PakageLengthDic.Add("PlatformBalance", 18);

            OrderDic.Add(7, "AccoutCheckInstr");
            ValueDic.Add("AccoutCheckInstr", null);
            PakageLengthDic.Add("AccoutCheckInstr", 100);
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
