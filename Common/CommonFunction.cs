using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace Common
{
    public class CommonFunction
    {
        // Methods
        public static DataColumn AddColumn(string colName, string colType, string isDefault, bool isNull)
        {
            DataColumn column = new DataColumn(colName, Type.GetType(colType));
            column.DefaultValue = isDefault;
            column.AllowDBNull = isNull;
            return column;
        }

        public static bool AlphaNum(string strAlphaNum)
        {
            if ((strAlphaNum == null) || (strAlphaNum.Trim().Length == 0))
            {
                return false;
            }
            strAlphaNum = strAlphaNum.Trim();
            string str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < strAlphaNum.Length; i++)
            {
                string str2 = strAlphaNum.Substring(i, 1);
                if (str.IndexOf(str2) < 0)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool CheckNum(string strNum)
        {
            if ((strNum == null) || (strNum.Trim().Length == 0))
            {
                return false;
            }
            strNum = strNum.Trim();
            string str = "1234567890";
            for (int i = 0; i < strNum.Length; i++)
            {
                string str2 = strNum.Substring(i, 1);
                if (str.IndexOf(str2) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string CheckStringToDecimal(string strDecimal)
        {
            try
            {
                return Convert.ToDecimal(strDecimal).ToString();
            }
            catch
            {
                return " ";
            }
        }

        public static void CopyToDataRow(DataRow rowInit, DataRow row)
        {
            if (((rowInit != null) && (row != null)) && ((rowInit.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Deleted)))
            {
                DataTable table = row.Table;
                int count = rowInit.Table.Columns.Count;
                int num2 = table.Columns.Count;
                if (num2 == count)
                {
                    string columnName = "";
                    for (int i = 0; i < num2; i++)
                    {
                        columnName = table.Columns[i].ColumnName;
                        row[columnName] = rowInit[columnName];
                    }
                }
            }
        }

        public static string CreateSaveSql(DataTable pTable, string[] pCols, string psDesTable)
        {
            DataTable table = new DataView(pTable, "", "", DataViewRowState.CurrentRows).ToTable("SaveTable", false, pCols);
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            StringBuilder builder4 = new StringBuilder();
            int num = 0;
            builder.Append("Insert into " + psDesTable + "(");
            builder2.Append("values(");
            foreach (DataColumn column in table.Columns)
            {
                builder.Append(column.ColumnName);
                builder.Append(",");
                if ((column.DataType.Name.ToUpper() == "STRING") || (column.DataType.Name.ToUpper() == "DATETIME"))
                {
                    builder2.Append("'{");
                    builder2.Append(num.ToString());
                    builder2.Append("}',");
                }
                else
                {
                    builder2.Append("{");
                    builder2.Append(num.ToString());
                    builder2.Append("},");
                }
                num++;
            }
            builder.Remove(builder.Length - 1, 1);
            builder2.Remove(builder2.Length - 1, 1);
            builder.Append(")");
            builder2.Append(");");
            foreach (DataRow row in table.Rows)
            {
                builder3.Append(builder.ToString());
                builder3.AppendFormat(builder2.ToString(), row.ItemArray);
                builder4.AppendLine(builder3.ToString());
                builder3.Length = 0;
            }
            return builder4.Replace("\r", "").ToString();
        }

        public static ArrayList DatatableChangeCol(DataTable tblInit, DataTable tbl)
        {
            ArrayList list = new ArrayList();
            int num = 0;
            DataRow row = null;
            int count = tblInit.Columns.Count;
            foreach (DataRow row2 in tbl.Rows)
            {
                row = tblInit.Rows[num];
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToString(row[i]) != Convert.ToString(row2[i]))
                    {
                        string columnName = tblInit.Columns[i].ColumnName;
                        list.Add(columnName);
                    }
                }
                num++;
            }
            return list;
        }

        public static string FormatNumberFormat(object psPrecision)
        {
            try
            {
                Convert.ToInt32(psPrecision);
            }
            catch
            {
                return "{0:f8}";
            }
            return ("{0:f" + Convert.ToInt16(psPrecision) + "}");
        }

        private static string getint(char c)
        {
            switch (c)
            {
                case '0':
                    return "零";

                case '1':
                    return "壹";

                case '2':
                    return "贰";

                case '3':
                    return "叁";

                case '4':
                    return "肆";

                case '5':
                    return "伍";

                case '6':
                    return "陆";

                case '7':
                    return "柒";

                case '8':
                    return "捌";

                case '9':
                    return "玖";
            }
            return "";
        }

        private static string getupper(string str, string strDW)
        {
            if (str == "0000")
            {
                return "";
            }
            string str2 = "";
            string str3 = getint(str[0]);
            string str4 = getint(str[1]);
            string str5 = getint(str[2]);
            string str6 = getint(str[3]);
            if (str3 != "零")
            {
                str2 = str2 + str3 + "仟";
            }
            else
            {
                str2 = str2 + str3;
            }
            if (str4 != "零")
            {
                str2 = str2 + str4 + "佰";
            }
            else if (str3 != "零")
            {
                str2 = str2 + str4;
            }
            if (str5 != "零")
            {
                str2 = str2 + str5 + "拾";
            }
            else if (str4 != "零")
            {
                str2 = str2 + str5;
            }
            if (str6 != "零")
            {
                str2 = str2 + str6;
            }
            if (str2[0] == 0x96f6)
            {
                str2 = str2.Substring(1);
            }
            if (str2[str2.Length - 1] == 0x96f6)
            {
                str2 = str2.Substring(0, str2.Length - 1);
            }
            return (str2 + strDW);
        }

        public static string IfDataRowHasChanges(DataRow rowInit, DataRow row)
        {
            if (((row == null) && (rowInit != null)) || ((row != null) && (rowInit == null)))
            {
                return "HasChanges";
            }
            int count = rowInit.Table.Columns.Count;
            if (row.Table.Columns.Count != count)
            {
                return "HasChanges";
            }
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToString(rowInit[i]) != Convert.ToString(row[i]))
                {
                    return "HasChanges";
                }
            }
            return "";
        }

        public static string IfDataSetHasChanges(DataSet dsInit, DataSet ds)
        {
            string str = "";
            if (((ds == null) && (dsInit != null)) || ((ds != null) && (dsInit == null)))
            {
                return "HasChanges";
            }
            int count = dsInit.Tables.Count;
            int num2 = ds.Tables.Count;
            if (count != num2)
            {
                return "HasChanges";
            }
            int num3 = 0;
            DataTable tblInit = null;
            foreach (DataTable table2 in ds.Tables)
            {
                tblInit = dsInit.Tables[num3];
                str = IfDataTableHasChanges(tblInit, table2);
                if (str != "")
                {
                    return str;
                }
                num3++;
            }
            return str;
        }

        public static bool IfDataTableHasChanges(DataTable tbl)
        {
            if (tbl == null)
            {
                return false;
            }
            if (tbl.Rows.Count < 1)
            {
                return false;
            }
            foreach (DataRow row in tbl.Rows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    return true;
                }
            }
            return false;
        }

        public static string IfDataTableHasChanges(DataTable tblInit, DataTable tbl)
        {
            string str = "";
            if (((tbl == null) && (tblInit != null)) || ((tbl != null) && (tblInit == null)))
            {
                return "HasChanges";
            }
            int count = tblInit.Columns.Count;
            int num2 = tbl.Columns.Count;
            if (count != num2)
            {
                return "HasChanges";
            }
            int num3 = tblInit.Rows.Count;
            num2 = tbl.Rows.Count;
            if (num3 != num2)
            {
                return "HasChanges";
            }
            int num4 = 0;
            DataRow row = null;
            foreach (DataRow row2 in tbl.Rows)
            {
                row = tblInit.Rows[num4];
                if (row2.RowState == DataRowState.Deleted)
                {
                    return "HasChanges";
                }
                if (str != "")
                {
                    return str;
                }
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToString(row[i]) != Convert.ToString(row2[i]))
                    {
                        str = "HasChanges";
                        break;
                    }
                }
                num4++;
            }
            return str;
        }

        public static bool IsFloat(string psStr)
        {
            double num;
            return double.TryParse(psStr, NumberStyles.Float, (IFormatProvider)NumberFormatInfo.InvariantInfo, out num);
        }

        public static double NullToDouble(object doubleObj)
        {
            if (doubleObj == null)
            {
                return 0.0;
            }
            try
            {
                return double.Parse(doubleObj.ToString().Trim());
            }
            catch (Exception exception)
            {
                exception.ToString();
                return 0.0;
            }
        }

        public static string NullToString(object strObj)
        {
            if (strObj == null)
            {
                return "";
            }
            return strObj.ToString();
        }

        public static string ToUpper(decimal d)
        {
            int num;
            if (d == 0M)
            {
                return "零元整";
            }
            string str = d.ToString("####.00");
            if (str.Length > 15)
            {
                return "";
            }
            str = new string('0', 15 - str.Length) + str;
            string str2 = str.Substring(0, 4);
            string str3 = str.Substring(4, 4);
            string str4 = str.Substring(8, 4);
            string str5 = str.Substring(13, 2);
            string str6 = "";
            string str7 = "";
            string str8 = "";
            str6 = getupper(str2, "亿");
            str7 = getupper(str3, "万");
            str8 = getupper(str4, "元");
            string str9 = "";
            string str10 = "";
            if ((str[3] == '0') || (str[4] == '0'))
            {
                str9 = "零";
            }
            if ((str[7] == '0') || (str[8] == '0'))
            {
                str10 = "零";
            }
            string str11 = str6 + str9 + str7 + str10 + str8;
            for (num = 0; num < str11.Length; num++)
            {
                if (str11[num] != 0x96f6)
                {
                    str11 = str11.Substring(num);
                    break;
                }
            }
            for (num = str11.Length - 1; num > -1; num--)
            {
                if (str11[num] != 0x96f6)
                {
                    str11 = str11.Substring(0, num + 1);
                    break;
                }
            }
            if (str11[str11.Length - 1] != '元')
            {
                str11 = str11 + "元";
            }
            if (str11 == "零零元")
            {
                str11 = "";
            }
            if (str5 == "00")
            {
                str11 = str11 + "整";
            }
            else
            {
                string str12 = "";
                str12 = getint(str5[0]);
                if (str12 == "零")
                {
                    str11 = str11 + str12;
                }
                else
                {
                    str11 = str11 + str12 + "角";
                }
                str12 = getint(str5[1]);
                if (str12 == "零")
                {
                    str11 = str11 + "整";
                }
                else
                {
                    str11 = str11 + str12 + "分";
                }
            }
            if (str11[0] == 0x96f6)
            {
                str11 = str11.Substring(1);
            }
            return str11;
        }

        public static void SetBaseWebReference(string referenceType, System.Web.Services.Protocols.SoapHttpClientProtocol objservice)
        {
            string baseUrl = CommonData.GetInstance().GetWebReferenceUrl(referenceType);
            objservice.Url = baseUrl + objservice.Url.Substring(objservice.Url.LastIndexOf('/'));
        }

        public static void SetBaseWebReference(System.Web.Services.Protocols.SoapHttpClientProtocol objservice)
        {

            string baseUrl = CommonData.GetInstance().GetWebReferenceUrl();
            //MessageBox.Show(baseUrl);
            //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            objservice.Url = baseUrl + objservice.Url.Substring(objservice.Url.LastIndexOf('/'));
            //MessageBox.Show(objservice.Url);
        }

        public static void SetBaseWebReference(object webService)
        {
            if (webService is System.Web.Services.Protocols.SoapHttpClientProtocol)
            {
                System.Web.Services.Protocols.SoapHttpClientProtocol objservice = webService as System.Web.Services.Protocols.SoapHttpClientProtocol;
                string baseUrl = CommonData.GetInstance().GetWebReferenceUrl();
                //MessageBox.Show(baseUrl);
                //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
                objservice.Url = baseUrl + objservice.Url.Substring(objservice.Url.LastIndexOf('/'));
                //MessageBox.Show(objservice.Url);
            }
            else
            {
                return;
            }

        }

        //获取简体中文字符串拼音首字母

        public static string getSpells(string input)
        {
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += getSpell(input.Substring(i, 1));
            }
            return reVal;
        }

        //获取一个简体中文字的拼音首字母
        private static string getSpell(string cn)
        {
            byte[] arrCN = System.Text.Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return System.Text.Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
        }

        public static string XMLDocumentToString(ref   XmlDocument doc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);

            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();

            return xmlString;
        }
        /// <summary>
        /// 正则表达式匹配字符串格式
        /// </summary>
        /// <param name="formatString">匹配格式</param>
        /// <param name="CheckCont">字符串</param>
        /// <returns></returns>
        public static bool CheckFormat(string formatString, string CheckCont)
        {
            Regex r = new Regex(formatString);
            Match m = r.Match(CheckCont);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 将xmldocuement 转换为对应的字符串
        /// </summary>
        /// <param name="doc">xml对象</param>
        /// <returns></returns>
        public static string XMLtostring(ref XmlDocument doc)
        {
            string XMLstring = "";
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xmlwrite = new XmlTextWriter(ms, null);
            xmlwrite.Formatting = Formatting.Indented;
            doc.Save(xmlwrite);

            StreamReader smread = new StreamReader(ms, System.Text.Encoding.UTF8);
            smread.BaseStream.Seek(0, SeekOrigin.Begin);
            XMLstring = smread.ReadToEnd();
            smread.Close();
            ms.Close();
            return XMLstring;

        }

        /// <summary>
        /// 将一个条目的XMl转换为对应的扩展属性表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable XMltotable(string XML)
        {
            DataTable dtProperty = new DataTable();
            DataColumn dcname = new DataColumn("PropertyName", System.Type.GetType("System.String"));
            DataColumn dcvalue = new DataColumn("PropertyValue", System.Type.GetType("System.String"));
            dtProperty.Columns.Add(dcname);
            dtProperty.Columns.Add(dcvalue);
            if (!String.IsNullOrEmpty(XML))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XML);
                XmlNodeList rootnode = xmldoc.SelectSingleNode("Property").ChildNodes;
                foreach (XmlNode node in rootnode)
                {
                    DataRow dr = dtProperty.NewRow();
                    XmlElement ele = (XmlElement)node;
                    dr[dcname] = ele.Name.ToString();// ("Notename");
                    dr[dcvalue] = ele.InnerText;
                    dtProperty.Rows.Add(dr);
                }
            }
            return dtProperty;
        }


        /// <summary>
        /// 将电子档案的信息XML 转换为dataset
        /// </summary>
        /// <param name="XML"></param>
        /// <returns></returns>
        public static DataTable XMLtoDatatable(string XML)
        {
            DataTable dt = new DataTable();
            System.IO.StringReader StrStream = null;
            XmlTextReader Xmlrdr = null;
            StrStream = new System.IO.StringReader(XML);
            Xmlrdr = new XmlTextReader(StrStream);
            dt.ReadXml(Xmlrdr);
            return dt;
        }

        public static DataTable ListToTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                //throw new Exception("需转换的集合为空");
                return new DataTable();
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();
            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
        public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
        {
            object[] lastValues;
            DataTable newTable;
            DataRow[] orderedRows;

            if (FieldNames == null || FieldNames.Length == 0)
                throw new ArgumentNullException("FieldNames");

            lastValues = new object[FieldNames.Length];
            newTable = new DataTable();

            foreach (string fieldName in FieldNames)
                newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);

            orderedRows = SourceTable.Select("", string.Join(", ", FieldNames));

            foreach (DataRow row in orderedRows)
            {
                if (!fieldValuesAreEqual(lastValues, row, FieldNames))
                {
                    newTable.Rows.Add(createRowClone(row, newTable.NewRow(), FieldNames));

                    setLastValues(lastValues, row, FieldNames);
                }
            }

            return newTable;
        }

        public static bool fieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
        {
            bool areEqual = true;

            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }

        public static DataRow createRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            foreach (string field in fieldNames)
                newRow[field] = sourceRow[field];

            return newRow;
        }

        public static void setLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
                lastValues[i] = sourceRow[fieldNames[i]];
        }

        /// <summary>
        /// 压缩二进制数据
        /// </summary>
        /// <param name="data">二进制数据</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream();
            Stream zipStream = null;
            zipStream = new GZipStream(ms, CompressionMode.Compress, true);
            zipStream.Write(data, 0, data.Length);
            zipStream.Close();
            ms.Position = 0;
            byte[] compressed_data = new byte[ms.Length];
            ms.Read(compressed_data, 0, int.Parse(ms.Length.ToString()));
            return compressed_data;
        }


        /// <summary>
        /// 解压缩二进制数据
        /// </summary>
        /// <param name="data">二进制数据</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            try
            {
                MemoryStream ms = new MemoryStream(data);
                Stream zipStream = null;
                zipStream = new GZipStream(ms, CompressionMode.Decompress);
                byte[] dc_data = null;
                dc_data = EtractBytesFormStream(zipStream, data.Length);
                return dc_data;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从压缩数据流中提取二进制数据
        /// </summary>
        /// <param name="zipStream">压缩数据流</param>
        /// <param name="dataBlock">数据流块长度</param>
        /// <returns></returns>
        public static byte[] EtractBytesFormStream(Stream zipStream, int dataBlock)
        {
            try
            {
                byte[] data = null;
                int totalBytesRead = 0;
                while (true)
                {
                    Array.Resize(ref data, totalBytesRead + dataBlock + 1);
                    int bytesRead = zipStream.Read(data, totalBytesRead, dataBlock);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    totalBytesRead += bytesRead;
                }
                Array.Resize(ref data, totalBytesRead);
                return data;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 在图片的底部增加水印图片
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        public static Image BuildWatermark(Image imgPhoto)
        {
            //以下(代码)从一个指定文件创建了一个Image 对象，然后为它的 Width 和 Height定义变量。 
            //这些长度待会被用来建立一个以24 bits 每像素的格式作为颜色数据的Bitmap对象。 
            //Image imgPhoto = Image.FromFile(rSrcImgPath);
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;


            //这个代码载入水印图片，水印图片已经被保存为一个BMP文件，以绿色(A=0,R=0,G=255,B=0)作为背景颜色。 
            //再一次，会为它的Width 和Height定义一个变量。 
            Bitmap bmWaterMark = new Bitmap(320, 40);

            //生成水印图片
            Bitmap bmOKWaterMark = GenerateObliqueWaterImg(bmWaterMark);
            Image imgWatermark = bmOKWaterMark;

            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;





            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            //这个代码以100%它的原始大小绘制imgPhoto 到Graphics 对象的(x=0,y=0)位置。 
            //以后所有的绘图都将发生在原来照片的顶部。 
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.DrawImage(
            imgPhoto,
            new Rectangle(0, 0, phWidth, phHeight),
            0,
            0,
            phWidth,
            phHeight,
            GraphicsUnit.Pixel);



            //根据前面修改后的照片创建一个Bitmap。把这个Bitmap载入到一个新的Graphic对象。 
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grWatermark = Graphics.FromImage(bmWatermark);


            //通过定义一个ImageAttributes 对象并设置它的两个属性，我们就是实现了两个颜色的处理，以达到半透明的水印效果。 
            //处理水印图象的第一步是把背景图案变为透明的(Alpha=0, R=0, G=0, B=0)。我们使用一个Colormap 和定义一个RemapTable来做这个。 
            //就像前面展示的，我的水印被定义为100%绿色背景，我们将搜到这个颜色，然后取代为透明。 
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            //第二个颜色处理用来改变水印的不透明性。 
            //通过应用包含提供了坐标的RGBA空间的5x5矩阵来做这个。 
            //通过设定第三行、第三列为0.3f我们就达到了一个不透明的水平。结果是水印会轻微地显示在图象底下一些。 
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = { 
　　                new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f}, 
　　                new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f}, 
　　                new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f}, 
　　                new float[] {0.0f, 0.0f, 0.0f, 0.3f, 0.0f}, 
　　                new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f} 
　　                };
            ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //随着两个颜色处理加入到imageAttributes 对象，我们现在就能在照片右手边上绘制水印了。 
            //我们会偏离10像素到底部，10像素到左边。 
            int markWidth;
            int markHeight;
            //mark比原来的图宽 
            if (phWidth <= wmWidth)
            {
                markWidth = phWidth - 10;
                markHeight = (markWidth * wmHeight) / wmWidth;
            }
            else if (phHeight <= wmHeight)
            {
                markHeight = phHeight - 10;
                markWidth = (markHeight * wmWidth) / wmHeight;
            }
            else
            {
                markWidth = wmWidth;
                markHeight = wmHeight;
            }
            //int xPosOfWm = ((phWidth - markWidth) - 10);
            //int yPosOfWm = 10;






            for (int x = 0; x < phWidth; )
            {


                for (int y = 0; y < phHeight; )
                {


                    grWatermark.DrawImage(imgWatermark,
                                            new Rectangle(x, y, markWidth, markHeight),
                                            0,
                                            0,
                                            wmWidth,
                                            wmHeight,
                                            GraphicsUnit.Pixel,
                                            imageAttributes);
                    y = y + markHeight + 100;

                }
                x = x + markWidth + 100;
            }

            //最后的步骤将是使用新的Bitmap取代原来的Image。 销毁两个Graphic对象，然后把Image 保存到文件系统。 
            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();
            imgWatermark.Dispose();

            return imgPhoto;
            //imgPhoto.Save(rDstImgPath, ImageFormat.Jpeg);
            //imgPhoto.Dispose();
            //imgWatermark.Dispose();
        }

        /// <summary>
        /// 生成倾斜的水印图片
        /// </summary>
        /// <param name="b">档案图片</param>
        /// <returns></returns>
        private static Bitmap GenerateObliqueWaterImg(Bitmap b)
        {
            if (b == null)
            {
                return null;
            }

            Graphics g = Graphics.FromImage(b);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // 作为演示，我们用Arial字体，大小为32，红色。
            FontFamily fm = new FontFamily("Arial");
            Font font = new Font(fm, 28, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush sb = new SolidBrush(Color.Black);
            string txt = System.DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);

            //string vsUserName = "王二";
            string vsUserName = Common.CommonData.GetInstance().LoginUserID;

            g.DrawString(vsUserName, font, sb, new PointF(0, 3));

            g.DrawString(txt, font, sb, new PointF(90, 3));


            g.Dispose();


            return KiRotate(b, -30f, Color.Transparent);


        }

        /// <summary>
        /// 倾斜水印图片
        /// </summary>
        /// <param name="bmp">图片</param>
        /// <param name="angle">倾斜角度</param>
        /// <param name="bkColor">背景色</param>
        /// <returns></returns>
        public static Bitmap KiRotate(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;

            PixelFormat pf;

            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return dst;
        }
    }
}
