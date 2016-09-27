using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Response
{
    /// <summary>
    /// 应付资金查询返回的信息
    /// </summary>
    public class Response04 : BaseResponse
    {
        private string paymentID;//付款凭证编号

        public string PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; ValueDic["PaymentID"] = value; }
        }
        private decimal? paymentAmount;//应支付金额

        public decimal? PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; ValueDic["PaymentAmount"] = value.ToString(); }
        }
        private string receiverAccount;//收款人账号

        public string ReceiverAccount
        {
            get { return receiverAccount; }
            set { receiverAccount = value; ValueDic["ReceiverAccount"] = value; }
        }
        private string receiverName;//收款人名称

        public string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; ValueDic["ReceiverName"] = value; }
        }
        private string receiverBankName;//收款银行名称

        public string ReceiverBankName
        {
            get { return receiverBankName; }
            set { receiverBankName = value; ValueDic["ReceiverBankName"] = value; }
        }
        private string payerAccount;//付款人账号即监管账号

        public string PayerAccount
        {
            get { return payerAccount; }
            set { payerAccount = value; ValueDic["PayerAccount"] = value; }
        }
        private string payerName; //付款人名称

        public string PayerName
        {
            get { return payerName; }
            set { payerName = value; ValueDic["PayerName"] = value; }
          
        }
        private string payBank;//付款银行

        public string PayBank
        {
            get { return payBank; }
            set { payBank = value; ValueDic["PayBank"] = value; }
            
        }
        private string paymentInstr;//支付说明

        public string PaymentInstr
        {
            get { return paymentInstr; }
            set
            {
                paymentInstr = value;
                ValueDic["PaymentInstr"] = value;
            }
           
        }
        private string projectID;//项目标识码

        public string ProjectID
        {
            get { return projectID; }
            set { projectID = value;  ValueDic["ProjectID"]       = value;}
        }

         public Response04()
        {
            SetStruct();
        }
        public Response04(string MessageInfo)
        {
            this.MessageInfo = MessageInfo;
            SetStruct();
           
            SetValue();
        }

        public Response04(byte[] MessageInfo)
        {
            this.ByteMessageInfo = MessageInfo;
            this.MessageInfo = Encod.GetString(MessageInfo);
            SetStruct();

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

            OrderDic.Add(4, "PaymentID");
            ValueDic.Add("PaymentID", null);
            PakageLengthDic.Add("PaymentID", 10);

            OrderDic.Add(5, "PaymentAmount");
            ValueDic.Add("PaymentAmount", null);
            PakageLengthDic.Add("PaymentAmount", 18);

            OrderDic.Add(6, "ReceiverAccount");
            ValueDic.Add("ReceiverAccount", null);
            PakageLengthDic.Add("ReceiverAccount", 30);

            OrderDic.Add(7, "ReceiverName");
            ValueDic.Add("ReceiverName", null);
            PakageLengthDic.Add("ReceiverName", 100);

            OrderDic.Add(8, "ReceiverBankName");
            ValueDic.Add("ReceiverBankName", null);
            PakageLengthDic.Add("ReceiverBankName", 60);

            OrderDic.Add(9, "PayerAccount");
            ValueDic.Add("PayerAccount", null);
            PakageLengthDic.Add("PayerAccount", 30);

            OrderDic.Add(10, "PayerName");
            ValueDic.Add("PayerName", null);
            PakageLengthDic.Add("PayerName", 100);

            OrderDic.Add(11, "PayBank");
            ValueDic.Add("PayBank", null);
            PakageLengthDic.Add("PayBank", 60);

            OrderDic.Add(12, "PaymentInstr");
            ValueDic.Add("PaymentInstr", null);
            PakageLengthDic.Add("PaymentInstr", 100);

            OrderDic.Add(13, "ProjectID");
            ValueDic.Add("ProjectID", null);
            PakageLengthDic.Add("ProjectID", 10);
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
            //ValueDic["BusinessCode"]   =this.BusinessCode ; 
            //ValueDic["ReturnCode"]     =this.ReturnCode   ;
            //ValueDic["PaymentID"]      =this.PaymentID  ;     
            //ValueDic["PaymentAmount"]  =this.PaymentAmount.ToString()  ; 
            //ValueDic["ReceiverAccount"]=this.ReceiverAccount ;
            //ValueDic["ReceiverName"]   =this.ReceiverName    ;
            //ValueDic["ReceiverBankName"] =this.ReceiverBankName;
            //ValueDic["PayerAccount"]    =this.PayerAccount ;   
            //ValueDic["PayerName"]       =this.PayerName     ;  
            //ValueDic["PayBank"]         =this.PayBank      ;
            //ValueDic["PaymentInstr"]    = this.PaymentInstr;
            //ValueDic["ProjectID"]       = this.ProjectID;   
       // }
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
                this.PackageLength = Encod.GetString(ByteMessageInfo,0, PakageLengthDic["PackageLength"]);
                this.BusinessCode = Encod.GetString(ByteMessageInfo,PakageLengthDic["PackageLength"], PakageLengthDic["BusinessCode"]);
                this.ReturnCode = Encod.GetString(ByteMessageInfo,PakageLengthDic["PackageLength"] + PakageLengthDic["BusinessCode"], PakageLengthDic["ReturnCode"]);
                if ("00".Equals(ReturnCode))
                {
                    int start = PakageLengthDic["PackageLength"] + PakageLengthDic["BusinessCode"] + PakageLengthDic["ReturnCode"];
                    this.PaymentID = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PaymentID"]);
                    start = start + PakageLengthDic["PaymentID"];
                    this.PaymentAmount = decimal.Parse(Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PaymentAmount"]));
                    start = start + PakageLengthDic["PaymentAmount"];
                    this.ReceiverAccount = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["ReceiverAccount"]);
                    start = start + PakageLengthDic["ReceiverAccount"];
                    this.ReceiverName = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["ReceiverName"]);
                    start = start + PakageLengthDic["ReceiverName"];
                    this.ReceiverBankName = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["ReceiverBankName"]);
                    start = start + PakageLengthDic["ReceiverBankName"];
                    this.PayerAccount = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PayerAccount"]);
                    start = start + PakageLengthDic["PayerAccount"];
                    this.PayerName = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PayerName"]);
                    start = start + PakageLengthDic["PayerName"];
                    this.PayBank = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PayBank"]);
                    start = start + PakageLengthDic["PayBank"];
                    this.PaymentInstr = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["PaymentInstr"]);
                    start = start + PakageLengthDic["PaymentInstr"];
                    this.ProjectID = Encod.GetString(ByteMessageInfo,start, PakageLengthDic["ProjectID"]);
                }
            }   
        }       
    }
}
