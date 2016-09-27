using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Message.MessageFactory;
using System.Net;
using System.Threading;
using Message.NewMessage.Response;
using Message.NewMessage.Request;

namespace Message
{
    public class MessageSender
    {
        public Encoding Encod { get; set; }
        public String RemoteIP { get; set; }
        public int RemotePort { get; set; }
        private Socket _socket;
        private byte[] buffer;
        private int len;
       
        public MessageSender()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[1024 * 512];
            Encod = Encoding.GetEncoding("GBK");
            //Encod = Encoding.Unicode;
        }

        public MessageSender(string remoteip, int port)
            : this()
        {
            RemoteIP = remoteip;
            RemotePort = port;
        }

        private const int OutTime = 30000;//通信时间超时 10秒
        private const int OutTimeConn = 10000;//连接时间超时  5秒

        public BaseResponse SendMessage(BaseRequest bmr,string WebsiteCode,string TellerCode)
        {
            
            TimeoutObject.Reset();
            BaseResponse result = null;
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(RemoteIP), RemotePort), delegate(IAsyncResult ar) { TimeoutObject.Set(); }, _socket);
            if (TimeoutObject.WaitOne(OutTimeConn, false))
            {
                _socket.ReceiveTimeout = OutTime;
                _socket.SendTimeout = OutTime;
                string str = bmr.ObjectToMessage();
                _socket.Send(Encod.GetBytes(str));
                len = _socket.Receive(buffer);
                
                if (len > 0)
                {
                    string strbuff = Encod.GetString(buffer);
                    switch (bmr.BusinessCode)
                    {
                        case "01": result = new Response01(buffer); break;
                        case "02": result = new Response02(buffer); break;
                        case "03": result = new Response03(buffer); break;
                        case "04": result = new Response04(buffer); break;
                        case "05": result = new Response05(buffer); break;
                        case "06": result = new Response06(buffer); break;
                        case "07": result = new Response07(buffer); break;
                        case "08": result = new Response08(buffer); break;
                        case "09": result = new Response09(buffer); break;
                        default: return null;
                    }
                    
                }
                bmr.SaveMessage(WebsiteCode, TellerCode);
                if (result != null)
                {
                    result.BankCode = bmr.BankCode;
                    result.SaveMessage(WebsiteCode, TellerCode);
                }
                return result;
            }
            else
            {
                if (_socket.Connected)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                }
                throw new Exception("所提供的服务器连接超时");
            }
        }

        /// <summary>
        /// 线程停止 用于连接
        /// </summary>
        private ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public BaseMessageResponse SendMessage(string remoteip, int remoteport, BaseMessageRequest bmr)
        {
            return null;
        }
        //public  bool SaveMessage(string MessageInfo, string WebsiteCode, string TellerCode)
        //{

        //    FundsRegulatoryClient.JG_MessageInfoClient Mclient = FundsRegulatoryClient.JG_MessageInfoClient.Instance;
        //    FundsRegulatoryClient.JG_MessageInfoSrv.MessageInfo mi =new FundsRegulatoryClient.JG_MessageInfoSrv.MessageInfo();
        //    mi.ID =Guid.NewGuid().ToString() ;
        //    mi.TellerCode =TellerCode;
        //    mi.WebsiteCode=WebsiteCode;
        //    mi.Content=MessageInfo;
        //    mi.MessageTime=DateTime.Now;
        //    mi.MessageDirect="2";//1 代表发送 2代表接收
        //    if(Mclient.Add(mi))
        //    {
        //        return true;
        //    }
        //    return false;
            
        //}
    }
}
