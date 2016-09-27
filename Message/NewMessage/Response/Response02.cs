using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Response
{
    /// <summary>
    /// 应缴资金查询返回信息
    /// </summary>
    public class Response02 : BaseResponse
    {
        private string depositID;        //缴款凭证编号

        public string DepositID
        {
            get { return depositID; }
            set { depositID = value;
            ValueDic["BusinessCode"] = value;
            }
        }
        private string depositAccount;    //缴款账号

        public string DepositAccount
        {
            get { return depositAccount; }
            set { depositAccount = value; ValueDic["DepositAccount"] = value; }
        }
        private string firmName;      //开发企业名称

        public string FirmName
        {
            get { return firmName; }
            set { firmName = value; ValueDic["FirmName"] = value; }
        }
        private string depositType;      //缴款类型

        public string DepositType
        {
            get { return depositType; }
            set { depositType = value; ValueDic["DepositType"] = value; }
        }
        private decimal? depositAmount;  //缴款金额

        public decimal? DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = value; ValueDic["DepositAmount"] = value.ToString(); }
        }
        private string purchaserName;  //购房人名称

        public string PurchaserName
        {
            get { return purchaserName; }
            set { purchaserName = value; ValueDic["PurchaserName"] = value; }
        }
        private string purchaserID;        //购房人证件

        public string PurchaserID
        {
            get { return purchaserID; }
            set { purchaserID = value; ValueDic["PurchaserID"] = value; }
        }
        private string projectCode;       //项目标识码

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; ValueDic["ProjectCode"] = value; }
        }

         public Response02()
        {
            SetStruct();
        }
        public Response02(string MessageInfo)
        {
            this.MessageInfo = MessageInfo;
            SetStruct();
            //StrToObject();
            SetValue();
        }
        public Response02(byte[] MessageInfo)
        {
            this.ByteMessageInfo = MessageInfo;
            this.MessageInfo = Encod.GetString(MessageInfo);
            SetStruct();
            //StrToObject();
            SetValue();
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

            OrderDic.Add(3, "ReturnCode");
            ValueDic.Add("ReturnCode", null);
            PakageLengthDic.Add("ReturnCode", 2);

            OrderDic.Add(4, "DepositID");
            ValueDic.Add("DepositID", null);
            PakageLengthDic.Add("DepositID", 10);

            OrderDic.Add(5, "DepositAccount");
            ValueDic.Add("DepositAccount", null);
            PakageLengthDic.Add("DepositAccount", 30);

            OrderDic.Add(6, "FirmName");
            ValueDic.Add("FirmName", null);
            PakageLengthDic.Add("FirmName", 100);

            OrderDic.Add(7, "DepositType");
            ValueDic.Add("DepositType", null);
            PakageLengthDic.Add("DepositType", 2);

            OrderDic.Add(8, "DepositAmount");
            ValueDic.Add("DepositAmount", null);
            PakageLengthDic.Add("DepositAmount", 18);

            OrderDic.Add(9, "PurchaserName");
            ValueDic.Add("PurchaserName", null);
            PakageLengthDic.Add("PurchaserName", 100);

            OrderDic.Add(10, "PurchaserID");
            ValueDic.Add("PurchaserID", null);
            PakageLengthDic.Add("PurchaserID", 20);

            OrderDic.Add(11, "ProjectCode");
            ValueDic.Add("ProjectCode", null);
            PakageLengthDic.Add("ProjectCode", 10);
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

        //public override void SetValue()
        //{
            //ValueDic["PackageLength"]  =this.PackageLength ;
            //ValueDic["BusinessCode"]   = this.BusinessCode;
            //ValueDic["ReturnCode"]     =this.ReturnCode;
            //ValueDic["DepositID"]      =this.DepositID;
            //ValueDic["DepositAccount"] = this.DepositAccount;
            //ValueDic["FirmName"]       =this.FirmName ;
            //ValueDic["DepositType"]    = this.DepositType; 
            //ValueDic["DepositAmount"]  = this.DepositAmount.ToString() ;
            //ValueDic["PurchaserName"]  = this.PurchaserName ;
            //ValueDic["PurchaserID"]    = this.PurchaserID ; 
            //ValueDic["ProjectCode"]    = this.ProjectCode; 
      //  }

        public override void SaveData()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 字符串转换为对象
        /// </summary>
        public override void SetValue()
        {
            if (MessageInfo != null && MessageInfo != "")
            {
                //this.PackageLength = MessageInfo.Substring(0, PakageLengthDic["PackageLength"]);
                this.PackageLength = Encod.GetString(ByteMessageInfo, 0, PakageLengthDic["PackageLength"]);
                //this.BusinessCode = MessageInfo.Substring(PakageLengthDic["PackageLength"], PakageLengthDic["BusinessCode"]);
                this.BusinessCode = Encod.GetString(ByteMessageInfo, PakageLengthDic["PackageLength"], PakageLengthDic["BusinessCode"]);
                this.ReturnCode = Encod.GetString(ByteMessageInfo,PakageLengthDic["PackageLength"] + PakageLengthDic["BusinessCode"], PakageLengthDic["ReturnCode"]);
                if ("00".Equals(ReturnCode))
                {
                    int start = PakageLengthDic["PackageLength"] + PakageLengthDic["BusinessCode"] + PakageLengthDic["ReturnCode"];
                    this.DepositID = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["DepositID"]);
                    start = start + PakageLengthDic["DepositID"];
                    this.DepositAccount = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["DepositAccount"]);
                    start = start + PakageLengthDic["DepositAccount"];
                    this.FirmName = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["FirmName"]);
                    start = start + PakageLengthDic["FirmName"];
                    this.DepositType = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["DepositType"]);
                    start = start + PakageLengthDic["DepositType"];
                    this.DepositAmount = decimal.Parse(Encod.GetString(ByteMessageInfo,start, PakageLengthDic["DepositAmount"]));
                    start = start + PakageLengthDic["DepositAmount"];
                    this.PurchaserName = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PurchaserName"]).Split(' ')[0];//多个购房人时为第一顺位购房人
                    start = start + PakageLengthDic["PurchaserName"];
                    this.PurchaserID = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PurchaserID"]);
                    start = start + PakageLengthDic["PurchaserID"];
                    this.ProjectCode = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["ProjectCode"]);
                }
            }
        }
    }
}
