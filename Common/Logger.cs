#region 变更纪录
/*
    * 系统名称：公房管理系统

    * 著作权：
    * 业务名：Log输出处理
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

namespace Common
{
    public class Logger
    {

        /// <summary>
        /// Log输出处理
        /// </summary>
        /// <param name="logType">Log输出等级</param>
        /// <param name="screenName">Log输出画面名称</param>
        /// <param name="message">Log输出内容</param>
        /// <returns>格式化后的Log输出时间</returns>
        public void LogWrite(LogLevel logLevel, string screenName, string message)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                if ((int)logLevel > (int)LogOutLevel)
                {
                    return;
                }

                string logfileName = GetLogFilePathName();
                if (logfileName == null || logfileName.Length == 0)
                {
                    return;
                }

                //Log内容变量的定义

                StringBuilder logContent = new StringBuilder();
                //输出时间
                logContent.Append(GetOutTime());
                //输出等级
                logContent.Append(",[" + (int)LogOutLevel + "]");
                //输出画面名称
                logContent.Append(",[" + screenName + "]");
                //输出Log具体内容
                logContent.Append(":" + message);
                //写Log文件操作
                sw = new System.IO.StreamWriter(logfileName, true,
                                    System.Text.Encoding.GetEncoding("gb2312"));
                sw.WriteLine(logContent);
                sw.Flush();
                sw.Close();
            }
            finally
            {
                if (sw != null)
                {
                    try
                    {
                        sw.Close();
                    }
                    catch (System.Exception e)
                    {
                        e.ToString();
                    }
                    try
                    {
                        sw.Dispose();
                    }
                    catch (System.Exception e)
                    {
                        e.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 获取Log输出lujing
        /// </summary>
        /// <returns>Log输出路径</returns>
        private string GetLogFilePathName()
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory();
                string logPath = Path.Combine(currentPath, "log");
                if (Directory.Exists(logPath) == false)
                {
                    Directory.CreateDirectory(logPath);
                }
                string logFileName = System.DateTime.Now.ToString("yyyMMdd") + ".LOG";
                return Path.Combine(logPath, logFileName);
            }
            catch (System.Exception e)
            {
                e.ToString();
                return "";
            }
        }
        //Log输出等级定义
        public enum LogLevel
        {
            Anomaly = -1,//异常
            Attention = 0,//警告
            Normal = 1,//通常
            Debug = 5 //调试
        }
        public const LogLevel LogOutLevel = LogLevel.Debug;

        /// <summary>
        /// Web端Log输出处理
        /// </summary>
        /// <param name="logType">Log输出等级</param>
        /// <param name="screenName">Log输出画面名称</param>
        /// <param name="message">Log输出内容</param>
        /// <returns>格式化后的Log输出时间</returns>
        public void WebLogWrite(LogLevel logLevel, string screenName, string message)
        {
            string logfileName = GetWebLogFilePathName();
            if (logfileName == null || logfileName.Length == 0)
            {
                return;
            }
            //写Log处理
            WriteLogFile(logLevel, screenName, message, logfileName);
        }


        /// <summary>
        /// Log输出处理
        /// </summary>
        /// <param name="logType">Log输出等级</param>
        /// <param name="screenName">Log输出画面名称</param>
        /// <param name="message">Log输出内容</param>
        /// <returns>格式化后的Log输出时间</returns>
        public void ClientLogWrite(LogLevel logLevel, string screenName, string message)
        {
            string logfileName = GetClientLogFilePathName();
            if (logfileName == null || logfileName.Length == 0)
            {
                return;
            }
            //写Log处理
            WriteLogFile(logLevel, screenName, message, logfileName);
        }

        /// <summary>
        /// 写文件处理

        /// </summary>
        /// <param name="logType">Log输出等级</param>
        /// <param name="screenName">Log输出画面名称</param>
        /// <param name="message">Log输出内容</param>
        /// <param name="logFilePath"></param>
        private void WriteLogFile(LogLevel logLevel, string screenName, string message, string logFilePath)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                if ((int)logLevel > (int)LogOutLevel)
                {
                    return;
                }

                //Log内容变量的定义

                StringBuilder logContent = new StringBuilder();
                //输出时间
                logContent.Append(GetOutTime());
                //输出等级
                logContent.Append(",[" + (int)logLevel + "]");
                //输出画面名称
                logContent.Append(",[" + screenName + "]");
                //输出Log具体内容
                logContent.Append(":" + message);
                //写Log文件操作
                sw = new System.IO.StreamWriter(logFilePath, true,
                                    System.Text.Encoding.GetEncoding("gb2312"));
                sw.WriteLine(logContent);
                sw.Flush();
                sw.Close();
            }
            finally
            {
                if (sw != null)
                {
                    try
                    {
                        sw.Close();
                    }
                    catch (System.Exception e)
                    {
                        e.ToString();
                    }
                    try
                    {
                        sw.Dispose();
                    }
                    catch (System.Exception e)
                    {
                        e.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 获取客户端Log输出路径
        /// </summary>
        /// <returns>Log输出路径</returns>
        private string GetClientLogFilePathName()
        {
            try
            {
                //string currentPath = Directory.GetCurrentDirectory();
                string logPath = "log/";
                logPath = System.IO.Path.Combine(CommonData.GetInstance().getCurrentDir(), logPath);
                if (Directory.Exists(logPath) == false)
                {
                    Directory.CreateDirectory(logPath);
                }
                string logFileName = System.DateTime.Now.ToString("yyyMMdd") + ".LOG";
                return Path.Combine(logPath, logFileName);
            }
            catch (System.Exception e)
            {
                e.ToString();
                return "";
            }
        }

        /// <summary>
        /// 获取Web端Log输出路径
        /// </summary>
        /// <returns>Log输出路径</returns>
        private string GetWebLogFilePathName()
        {
            try
            {
                string logPath = "log/";
                logPath = System.IO.Path.Combine(CommonData.GetInstance().getWebLogPath(), logPath);
                if (Directory.Exists(logPath) == false)
                {
                    Directory.CreateDirectory(logPath);
                }
                string logFileName = System.DateTime.Now.ToString("yyyMMdd") + ".LOG";
                return Path.Combine(logPath, logFileName);
            }
            catch (System.Exception e)
            {
                e.ToString();
                return "";
            }
        }

        /// <summary>
        /// 格式化Log输出时间
        /// </summary>
        /// <returns>格式化后的Log输出时间</returns>
        private string GetOutTime()
        {
            return System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff");
        }
    }
}

