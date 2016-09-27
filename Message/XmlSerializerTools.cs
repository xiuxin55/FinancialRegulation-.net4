using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Message
{
    public class XmlSerializerTools
    {
        private static Dictionary<string, XmlSerializer> XmlSerializerDic = new Dictionary<string, XmlSerializer>();
        private static Dictionary<string, string> SerializerStr = new Dictionary<string, string>();

        public static T FromXmlStr<T>(string XMLStr, Encoding encoding)
        {
            if (string.IsNullOrEmpty(XMLStr))
                throw new ArgumentNullException("XMLText is NULL");
            if (encoding == null)
                throw new ArgumentNullException("Encoding is NULL");
            string typename = typeof(T).Name;
            if (!XmlSerializerDic.Keys.Contains(typename))
            {
                XmlSerializerDic.Add(typename, new XmlSerializer(typeof(T)));
            }
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(XMLStr)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    return (T)XmlSerializerDic[typename].Deserialize(sr);
                }
            }
        }
        /// <summary>
        /// 将str转换成对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XMLStr"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T StrToObj<T>(string Str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(Str))
                throw new ArgumentNullException("XMLText is NULL");
            if (encoding == null)
                throw new ArgumentNullException("Encoding is NULL");
            Type t = typeof(T);
            string typename = typeof(T).Name;
            if (!SerializerStr.Keys.Contains(typename))
            {
                SerializerStr.Add(typename, "");
            }
            PropertyInfo[] pi = t.GetProperties();
            object obj = Activator.CreateInstance(t);
            FieldInfo[] myFieldInfo = t.GetFields();//获得对象信息每个字段的长度
            string InfoLength;
            if (myFieldInfo != null)
            {
                for (int i = 0; i < myFieldInfo.Length; i++)
                {
                    InfoLength=myFieldInfo[i].GetValue(obj).ToString();
                    break;
                }
            }
            for (int i = 0; i < pi.Length; i++)
            {
                Type tt = pi[i].PropertyType;

                switch (tt.Name)
                {
                    case "String":
                       // string seck=Str.Substring(0,int.Parse
                        pi[i].SetValue(obj, Str.Split('|')[i], null);
                        break;
                    case "Int32":
                        pi[i].SetValue(obj, int.Parse(Str.Split('|')[i]), null);
                        break;
                    case "Decimal":
                        pi[i].SetValue(obj, int.Parse(Str.Split('|')[i]), null);
                        break;   
                    default: break;
                }

            }
            return (T)obj;
        }
        /// <summary>
        /// 将对象转换为对应字符串格式
        /// </summary>
        public static String ToStr(object obj, Encoding encoding)
        {

            return null;
        }
        private static void ModelToXML2(Stream stream, object obj, Encoding encoding)
        {
            if (obj == null)
                throw new ArgumentNullException("o");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            //XmlSerializer serializer = new XmlSerializer(obj.GetType());
            string typename = obj.GetType().Name;
            if (!XmlSerializerDic.Keys.Contains(typename))
            {
                SerializerStr.Add(typename, "");
            }
            //switch(typename){
            //    case "Message004"
        }
        public static String ToXmlStr(object obj, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ModelToXML(stream, obj, encoding);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static void ModelToXML(Stream stream, object obj, Encoding encoding)
        {
            if (obj == null)
                throw new ArgumentNullException("o");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            //XmlSerializer serializer = new XmlSerializer(obj.GetType());
            string typename = obj.GetType().Name;
            if (!XmlSerializerDic.Keys.Contains(typename))
            {
                XmlSerializerDic.Add(typename, new XmlSerializer(obj.GetType()));
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = encoding;
            settings.IndentChars = " ";
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                XmlSerializerDic[typename].Serialize(writer, obj);
                writer.Close();
            }
        }
    }
}
