using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using MODEL.NewModel;
using System.IO;
using FinancialRegulationSRV.Tools;
using System.Collections.ObjectModel;
using System.Net;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// BillOperateSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BillOperateSrv : System.Web.Services.WebService
    {

         [WebMethod(Description = "返回今日对账信息")]
        public List<BillFileCheck> SelectsTodayBill(BillFileCheck bfc)
        {
            return BillOperateDao.SelectsTodayBill(bfc);
        }
         [WebMethod(Description = "返回利息对账信息")]
         public List<InterestBillCheck> SelectsInterestBill(InterestBillCheck bfc)
         {
             return BillOperateDao.SelectsInterestBill(bfc);
         }
         [WebMethod(Description = "生成对账单文件")]
         public bool ProduceBillFile(string[] bill, string filepath, string filename)
         {
             try
             {
                 if (filepath == null)
                 {
                     filepath = AppDomain.CurrentDomain.BaseDirectory + filename;
                 }
                 else
                 {
                     if (filepath[filepath.Length - 1] != '\\')
                     {
                         filepath = filepath + "\\";
                     }
                     filepath = filepath + filename;
                     filepath = AppDomain.CurrentDomain.BaseDirectory + filepath;
                 }

                 if (File.Exists(filepath))
                 {
                     File.Delete(filepath);
                 }
                 File.WriteAllLines(filepath, bill);
                 return true;
             }
             catch (Exception e)
             {
                 File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "log.txt", e.Message + ":" + e.StackTrace);
                 return false;
             }
         }
        
         /// <summary>
         /// 上传文件
         /// </summary>
         /// <param name="filename">文件名</param>
         /// <param name="serverPath">服务器地址</param>
         /// <returns>返回是否成功</returns>
        [WebMethod(Description = "上传文件")]
         //ftp的上传功能  
         public bool Upload(string userId, string pwd, string filepath,string filename, string ftpPath)
         {
             if (filepath == null)
             {
                 filepath = AppDomain.CurrentDomain.BaseDirectory + filename;
             }
             else
             {
                 if (filepath[filepath.Length - 1] != '\\')
                 {
                     filepath = filepath + "\\";
                 }
                 filepath = filepath+ filename;
                 filepath = AppDomain.CurrentDomain.BaseDirectory + filepath;
             }
             ftpPath = ftpPath.ToLower();
             if (!ftpPath.Contains("ftp"))
             {
                 ftpPath = "ftp://" + ftpPath;
             }
             if (ftpPath[ftpPath.Length - 1] != '/')
             {
                 ftpPath = ftpPath + "/";
             }
             try
             {
                 FileInfo fileInf = new FileInfo(filepath);
             FtpWebRequest reqFTP;
             // 根据uri创建FtpWebRequest对象   
             reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileInf.Name));
             // ftp用户名和密码  
             reqFTP.Credentials = new NetworkCredential(userId, pwd);

             reqFTP.UsePassive = false;
             // 默认为true，连接不会被关闭  
             // 在一个命令之后被执行  
             reqFTP.KeepAlive = false;
             // 指定执行什么命令  
             reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
             // 指定数据传输类型  
             reqFTP.UseBinary = true;
             // 上传文件时通知服务器文件的大小  
             reqFTP.ContentLength = fileInf.Length;
             // 缓冲大小设置为2kb  
             int buffLength = 2048;
             byte[] buff = new byte[buffLength];
             int contentLen;
             // 打开一个文件流 (System.IO.FileStream) 去读上传的文件  
            FileStream fs = fileInf.OpenRead();
             // 把上传的文件写入流  
             
                     Stream strm = reqFTP.GetRequestStream();
                     // 每次读文件流的2kb  
                     contentLen = fs.Read(buff, 0, buffLength);
                     // 流内容没有结束  
                     while (contentLen != 0)
                     {
                         // 把内容从file stream 写入 upload stream  
                         strm.Write(buff, 0, contentLen);
                         contentLen = fs.Read(buff, 0, buffLength);
                     }
                          // 关闭两个流  
                     strm.Close();
                     fs.Close();
                    return true;

                 }
                 catch (Exception ex)
                 {
                     
                     return false;
                 }

         }
    }
}
