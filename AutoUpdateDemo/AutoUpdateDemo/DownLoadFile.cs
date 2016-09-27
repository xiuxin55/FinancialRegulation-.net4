using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Security.AccessControl;

namespace AutoUpdate
{
    /// <summary>
    /// 
    /// </summary>
    public class DownLoadFile
    {
        public DownLoadFile()
        {
            
        }
        public bool DownLoad(string strUrlFilePath, string strLocalPath)
        {
            //创建WebClient实例
            WebClient client = new WebClient();
            try
            {
                WebRequest myWebRequest = WebRequest.Create(strUrlFilePath);
                client.DownloadFile(strUrlFilePath, strLocalPath);
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }        
    }
}
