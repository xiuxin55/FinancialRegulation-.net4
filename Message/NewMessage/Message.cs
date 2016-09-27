using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.NewMessage
{
    /// <summary>
    /// 消息的基类
    /// </summary>
    public abstract class Message
    {
        
        private string packageLength;

        public string PackageLength
        {
            get { return packageLength; }
            set { packageLength = value;
            ValueDic["PackageLength"] = value;
           
            }
        }

        private string businessCode;

        public string BusinessCode
        {
            get { return businessCode; }
            set { businessCode = value;
            ValueDic["BusinessCode"] = value;
            }
        }
        protected Encoding Encod = Encoding.GetEncoding("GBK");
        public string MessageInfo { get; set; }//消息字符串
        public byte[] ByteMessageInfo{ get; set; }//消息字符串
        public Dictionary<int, string> OrderDic { get; set; }
        public Dictionary<string, string> ValueDic { get; set; }
        public Dictionary<string, int> PakageLengthDic { get; set; }
        public abstract void SetStruct();//设置字典的结构
        public abstract void SetValue();//将字符串转换为对象
        public abstract bool SaveMessage(string WebsiteCode, string TellerCode);//参数网点编号，柜员编号
        public abstract void SaveData();
        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <returns></returns>
        public string ObjectToMessage()
        {
           MessageInfo="";
            for (int i = 1; i < OrderDic.Count+1; i++)
            {
                int length=PakageLengthDic[OrderDic[i]];//获取字段长度
                string str=ValueDic[OrderDic[i]];//字段的值
                if (str == null)
                {
                    str = "";
                }
                byte[] messagebyte = new byte[length];
                byte[] temp =Encod.GetBytes(str);
                for (int j= 0; j< length; j++)
                {
                    if (j < temp.Length)
                    {
                        messagebyte[j] = temp[j];
                    }
                    else
                    {
                        messagebyte[j] = 32;
                    }
                }
                //str=str.PadRight(length,' ');

                MessageInfo = MessageInfo + Encod.GetString(messagebyte);
            }
            
            return MessageInfo;
        }
       // public abstract void StrToObject();
    }
}
