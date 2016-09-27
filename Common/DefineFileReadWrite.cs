#region 变更纪录
/*
    * 系统名称：档案管理系统


    * 著作权：
    * 业务名：定义文件的读操作
    * ****************************************************************
    * Modification History
    * 
    * Version      Date        Name          Reason for change
    * -----------  ----------  ------------  ------------------------
    * Ver.1.0      2008/12/27  001        新建作成
    * ****************************************************************
    */
#endregion

using System.IO;
using System.Text;
using System.Collections;
using System.Xml.XPath;
using System.Xml;
using System;

namespace Common
{
    public class DefineFileReadWrite
    {
        /// <summary>
        /// 根据指定的节点读取客户端配置文件信息
        /// </summary>
        /// <param name="nodePathName">节点名称</param>
        public static string GetConfigValue(string nodePathName)
        {
            try
            {
                //配置文件定位
                string configFile = Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory, "ClientConfig.xml");
                //配置内容的读取 
                ArrayList configValueLst = null;
                configValueLst = GetXmlString(
                     configFile, "Config/ClientPara/" + nodePathName);

                //定义内容的换行的处理
                string configValue = (string)configValueLst[0];
                //
                return configValue;
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 修改XML文件信息
        /// </summary>
        /// <param name="nodePathName">节点</param>
        /// <param name="strNewValue">修改的内容</param>
        /// <returns></returns>
        public static bool UpdateConfigValue(string nodePathName, string strNewValue)
        {
            try
            {
                if ((nodePathName.Trim() != "" && nodePathName.Trim() != null) && (strNewValue.Trim() != "" && strNewValue.Trim() != null))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(AppDomain.CurrentDomain.BaseDirectory + "ClientConfig.xml");
                    XmlNodeList Xnode = doc.SelectNodes("/Config/ClientPara/" + nodePathName);
                    foreach (XmlNode item in Xnode)
                    {
                        if (item.InnerText != strNewValue)
                        {
                            item.InnerText = strNewValue;
                        }                 
                    }

                    doc.Save(AppDomain.CurrentDomain.BaseDirectory + "ClientConfig.xml");//保存
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }









        public static string GetConfigSql(string nodePathName)
        {
            try
            {
                //配置文件定位
                string configFile = Path.Combine(
                     CommonData.GetInstance().ConfigPath, "SqlConfig.xml");
                //配置内容的读取 
                ArrayList configValueLst = null;
                configValueLst = GetXmlString(
                     configFile, "Config/ClientPara/" + nodePathName + "/sql");

                //定义内容的换行的处理
                string configValue = (string)configValueLst[0];
                //
                return configValue;
            }
            catch (System.Exception e)
            {

                return "";
            }
        }

        /// <summary>
        /// 根据指定的节点及节点值，写客户端配置文件信息
        /// </summary>
        /// <param name="nodePathName">节点名称</param>
        /// <param name="nodeValue">节点值</param>
        /// <returns >操作成功：true;操作失败:false</returns>
        public static bool WriteConfigValue(string nodePathName, string nodeValue)
        {
            try
            {
                //配置文件定位
                string configFile = "ClientConfig.xml";

                return WriteXmlString(configFile, "/Config/ClientPara/" + nodePathName, nodeValue);

            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 定义xml文件的写操作
        /// </summary>
        /// <param name="fileName">文件名称(包含路径)</param>
        /// <param name="nodePathName">节点名称</param>
        /// <param name="nodeValue">节点值</param>
        ///<returns >操作成功：true;操作失败:false</returns>
        public static bool WriteXmlString(string fileName, string nodePathName, string nodeValue)
        {
            System.Xml.XmlDocument doc = null;
            System.Xml.XmlTextReader reader = null;
            XmlTextWriter writer = null;
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                fileInfo.IsReadOnly = false;

                doc = new System.Xml.XmlDocument();
                reader = new System.Xml.XmlTextReader(fileName);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                doc.Load(reader);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodeList = null;
                nodeList = root.SelectNodes(nodePathName);
                foreach (XmlNode isbn in nodeList)
                {
                    isbn.InnerText = nodeValue;
                }
                reader.Close();
                reader = null;

                writer = new XmlTextWriter(fileName, null);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
                writer.Close();
                writer = null;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                        writer = null;
                    }
                    catch (System.Exception e1)
                    {
                        e1.ToString();
                    }
                }
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                        reader = null;
                    }
                    catch (System.Exception e1)
                    {
                        e1.ToString();
                    }
                }
                doc = null;
            }
        }

        /// <summary>
        /// 定义xml文件的读操作
        /// </summary>
        /// <param name="fileName">文件名称(包含路径)</param>
        /// <param name="nodePathName">节点名称</param>
        /// <returns>定义节点值</returns>
        public static ArrayList GetXmlString(string fileName, string nodePathName)
        {
            XPathDocument xPathdoc;
            XPathNavigator xPathNav;
            XPathNodeIterator xPathNodeIter;
            ArrayList xmlContentLst = new ArrayList();
            try
            {
                xPathdoc = new XPathDocument(fileName);
                xPathNav = xPathdoc.CreateNavigator();
                xPathNodeIter = xPathNav.Select(nodePathName);
                for (int i = 0; i < xPathNodeIter.Count; i++)
                {
                    xPathNodeIter.MoveNext();
                    xmlContentLst.Add(xPathNodeIter.Current.Value);
                }
            }
            catch (System.Exception e)
            {
                e.ToString();
                xPathNodeIter = null;
                xPathNav = null;
                xPathdoc = null;
            }
            xPathNodeIter = null;
            xPathNav = null;
            xPathdoc = null;
            return xmlContentLst;
        }

        public static string[] ReadXml(string fileName, string nodePathName)
        {
            XPathDocument document;
            //XPathNavigator navigator;
            XPathNodeIterator iterator;
            string[] strArray = null;
            try
            {
                document = new XPathDocument(fileName);
                iterator = document.CreateNavigator().Select(nodePathName);
                strArray = new string[iterator.Count];
                for (int i = 0; i < iterator.Count; i++)
                {
                    iterator.MoveNext();
                    strArray[i] = iterator.Current.Value;
                }
            }
            catch
            {
                iterator = null;
                //navigator = null;
                document = null;
                strArray = new string[0];
            }
            iterator = null;
            //navigator = null;
            document = null;
            return strArray;
        }

        public static bool WriteXml(string fileName, string nodePathName, string nodeValue)
        {
            XmlDocument document = null;
            XmlTextReader reader = null;
            XmlTextWriter w = null;
            bool flag;
            try
            {
                FileInfo info = new FileInfo(fileName);
                info.IsReadOnly = false;
                document = new XmlDocument();
                reader = new XmlTextReader(fileName);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                document.Load(reader);
                XmlElement documentElement = document.DocumentElement;
                XmlNodeList list = null;
                list = documentElement.SelectNodes(nodePathName);
                foreach (XmlNode node in list)
                {
                    node.InnerText = nodeValue;
                }
                reader.Close();
                reader = null;
                w = new XmlTextWriter(fileName, null);
                w.Formatting = Formatting.Indented;
                document.Save(w);
                w.Close();
                w = null;
                flag = true;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (w != null)
                {
                    try
                    {
                        w.Close();
                        w = null;
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        exception.ToString();
                    }
                }
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                        reader = null;
                    }
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                }
                document = null;
            }
            return flag;
        }
    }
}

