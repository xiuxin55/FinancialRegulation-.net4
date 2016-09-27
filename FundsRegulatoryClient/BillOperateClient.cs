using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.BillOperateSrv;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows;
namespace FundsRegulatoryClient
{
    public class BillOperateClient : BaseClient<BillOperateSrv.BillOperateSrv>
    {
        //private BillOperateSrv.BillOperateSrv bos;

        private static BillOperateClient current = null;
        public static BillOperateClient Current
        {
            get
            {
                if (current == null)
                {
                    current = new BillOperateClient();
                }
                return current;
            }
        }
        private BillOperateClient()
        {
            //bos = new BillOperateSrv.BillOperateSrv();
            //Common.CommonFunction.SetBaseWebReference(bos);
        }

        //public BillFile[] Bill2Server(DateTime searchDate, List<BillFile> billFiles)
        //{
        //    BillFile[] bfs = billFiles.ToArray();
        //    return bos.Bill2Server(searchDate, bfs);
        //}


        /// <summary>
        ///今日 对账单
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public ObservableCollection<BillFileCheck> SelectsTodayBill(BillFileCheck bill)
        {
            ObservableCollection<BillFileCheck> temp = new ObservableCollection<BillFileCheck>();
            service.SelectsTodayBill(bill).ToList<BillFileCheck>().ForEach(p => temp.Add(p));
            return temp;
        }
        /// <summary>
        //利息 对账单
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public ObservableCollection<InterestBillCheck> SelectsInterestBill(InterestBillCheck bill)
        {
            ObservableCollection<InterestBillCheck> temp = new ObservableCollection<InterestBillCheck>();
            service.SelectsInterestBill(bill).ToList<InterestBillCheck>().ForEach(p => temp.Add(p));
            return temp;
        }

        /// <summary>
        /// 生成账单文件
        /// </summary>
        /// <param name="bfclist"></param>
        public bool ProduceBillFile(List<string> bill,string filepath,string filename)
        {
            //if (filepath == null)
            //{
            //    filepath = AppDomain.CurrentDomain.BaseDirectory + filename;
            //}
            //else
            //{
            //    filename = filepath + filename;
            //}
            //try
            //{
            //    File.WriteAllLines(filename, bill);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

            return service.ProduceBillFile(bill.ToArray<string>(), filepath, filename);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="serverPath">服务器地址</param>
        /// <returns>返回是否成功</returns>
        public bool UpLoadFile(string filename,string filepath, string serverPath, string username, string password)
        {
            //string fileUrl = filename;
            //WebClient wc = new WebClient();
            //wc.Credentials = null;
            //wc.Credentials = new System.Net.NetworkCredential(username, password);
            //try
            //{
            //    wc.UploadFile(serverPath +"/"+ System.IO.Path.GetFileName(fileUrl), fileUrl);

            //}
            //catch (Exception ee)
            //{
            //    //Debug.WriteLine(ee.Message);
            //    return false;
            //}
            //finally
            //{
            //    wc.Dispose();
            //}
            //return true; 
            return UploadState = service.Upload(username, password, filepath, filename, serverPath);
         //   return Upload(username, password,filename,serverPath);
          //return  bos.UpLoadFile(filename, serverPath, username, password);
        }
        ////ftp的上传功能  
        //private bool Upload(string userId, string pwd, string filename, string ftpPath)
        //{
        //    ftpPath=ftpPath.ToLower();
        //    if (!ftpPath.Contains("ftp"))
        //    {
        //        ftpPath = "ftp://" + ftpPath;
        //    }
        //    if (ftpPath[ftpPath.Length - 1] != '/')
        //    {
        //        ftpPath = ftpPath + "/";
        //    }
        //    FileInfo fileInf = new FileInfo(filename);
        //    FtpWebRequest reqFTP;
        //    // 根据uri创建FtpWebRequest对象   
        //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileInf.Name));
        //    // ftp用户名和密码  
        //    reqFTP.Credentials = new NetworkCredential(userId, pwd);

        //    reqFTP.UsePassive = false;
        //    // 默认为true，连接不会被关闭  
        //    // 在一个命令之后被执行  
        //    reqFTP.KeepAlive = false;
        //    // 指定执行什么命令  
        //    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
        //    // 指定数据传输类型  
        //    reqFTP.UseBinary = true;
        //    // 上传文件时通知服务器文件的大小  
        //    reqFTP.ContentLength = fileInf.Length;
        //    // 缓冲大小设置为2kb  
        //    int buffLength = 2048;
        //    byte[] buff = new byte[buffLength];
        //    int contentLen;
        //    // 打开一个文件流 (System.IO.FileStream) 去读上传的文件  
           
        //        // 把上传的文件写入流  
        //            reqFTP.BeginGetRequestStream(new AsyncCallback(delegate(IAsyncResult ar) {
        //                FileStream fs = fileInf.OpenRead();
        //                try
        //                {
        //                    FtpWebRequest AsyReqFTP = (FtpWebRequest)ar.AsyncState;

        //                    Stream strm = AsyReqFTP.EndGetRequestStream(ar);
        //                    // 每次读文件流的2kb  
        //                    contentLen = fs.Read(buff, 0, buffLength);
        //                    // 流内容没有结束  
        //                    while (contentLen != 0)
        //                    {
        //                        // 把内容从file stream 写入 upload stream  
        //                        strm.Write(buff, 0, contentLen);
        //                        contentLen = fs.Read(buff, 0, buffLength);
        //                    }
        //                    strm.Close();
        //                    fs.Close();
        //                    UploadState = true;
        //                    ShowMessage("文件上传成功", true);

        //                }
        //                catch (Exception ex)
        //                {
        //                    fs.Close();
        //                    UploadState = false;
        //                    ShowMessage("文件上传失败", false);
        //                }
        //        }), reqFTP);
                
        //        // 关闭两个流  
        //        return true;
                
           
        //}
        public bool UploadState { get; set; }
     
    }
}
