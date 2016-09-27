using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Message.NewMessage.Response;
using System.Reflection;

namespace Message.NewMessage.MessageFactory
{
    /// <summary>
    /// 解析返回信息
    /// </summary>
    class ResponeMesssage
    {
        /// <summary>
        /// 处理接收的信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static BaseResponse GetMessage(string str)
        {
            string bussinesscode=str.Substring(6, 2);
            string returncode = str.Substring(8, 2);
            switch (bussinesscode)
            {
                case "01": return new Response01(str);
                case "02": return new Response02(str);
                case "03": return new Response03(str);
                case "04": return new Response04(str);
                case "05": return new Response05(str);
                case "06": return new Response06(str);
                case "07": return new Response07(str);
                case "08": return new Response08(str);
                default: return null;
            }
        }
      
        /// <summary>
        /// 返回的结果
        /// </summary>
        /// <param name="code"></param>
        public T ReturnResult<T>(string str)
        {
            Type t = typeof(T);
            object obj = Activator.CreateInstance(t);
            PropertyInfo[] pi = t.GetProperties();
            PropertyInfo OrderDicP = t.GetProperty("OrderDic");
            PropertyInfo ValueDicP = t.GetProperty("ValueDic");
            PropertyInfo PakageLengthDicP = t.GetProperty("PakageLengthDic");
            Dictionary<int, string> OrderDic =(Dictionary<int, string>)OrderDicP.GetValue(obj,null);
            Dictionary<string, string> ValueDic = (Dictionary<string, string>)ValueDicP.GetValue(obj, null);
            Dictionary<string, int> PakageLengthDic = (Dictionary<string, int>)PakageLengthDicP.GetValue(obj, null);
            for (int i = 0; i < OrderDic.Count; i++)
            {
                int length = PakageLengthDic[OrderDic[i]];//获取字段长度
                ValueDic[OrderDic[i]] = str.Substring(0, length).Trim();
                str=str.Remove(0, length);
            }
            for (int i = 0; i < OrderDic.Count; i++)
            {
                PropertyInfo temp = t.GetProperty(OrderDic[i]);
                temp.SetValue(obj, ValueDic[OrderDic[i]], null);
            }
            return (T)obj;
        }
    }
}
