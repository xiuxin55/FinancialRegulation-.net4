using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage.Response
{
   public  class Response09 : BaseResponse
    {
        public Response09()
        {
            SetStruct();
        }
        
        public Response09(string MessageInfo)
        {
            this.MessageInfo = MessageInfo;
            SetStruct();
            SetValue();
        }
        public Response09(byte[] MessageInfo)
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
        //    //ValueDic["PackageLength"]=this.PackageLength;
        //    //ValueDic["BusinessCode"] = this.BusinessCode;
        //    //ValueDic["ReturnCode"] = this.ReturnCode;
        //}
        public override void SaveData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 字符串转换为对象
        /// </summary>
        public override void SetValue()
        {
            if (MessageInfo != null&&MessageInfo !="")
            {
                this.PackageLength = Encod.GetString(ByteMessageInfo,0, PakageLengthDic["PackageLength"]);
                this.BusinessCode = Encod.GetString(ByteMessageInfo,PakageLengthDic["PackageLength"], PakageLengthDic["BusinessCode"]);
                this.ReturnCode = Encod.GetString(ByteMessageInfo,PakageLengthDic["PackageLength"] + PakageLengthDic["BusinessCode"], PakageLengthDic["ReturnCode"]);
            }
        }
    }
}
