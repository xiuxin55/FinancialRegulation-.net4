using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FinancialRegulation.Tools;

namespace FinancialRegulation.ViewModel
{
    public abstract class BaseVM<T> : Microsoft.Practices.Prism.ViewModel.NotificationObject where T : new()
    {
        public BaseVM()
        {
          //  Init();//加载内置对象
            LoadCommand();//加载命令
            LoadData();//加载数据
        }

        #region 预制对象

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <typeparam name="T">接收报文类型</typeparam>
        /// <param name="request">请求</param>
        /// <returns>返回报文</returns>
        public R SendMessage<R>(Message.NewMessage.Request.BaseRequest request,string WebsiteCode,string TellerCode) where R : Message.NewMessage.Response.BaseResponse
        {
            if (request == null) throw new Exception("Request 为空,无法发送");
            Message.MessageSender Sender = new Message.MessageSender(VMHelp.SYSCONFIG.IP, int.Parse(VMHelp.SYSCONFIG.Port));
            return Sender.SendMessage(request, WebsiteCode, TellerCode) as R;
        }

        /// <summary>
        /// 线程停止 用于测试连接
        /// </summary>
        private ManualResetEvent TimeoutObject = new ManualResetEvent(false);


        /// <summary>
        /// 发送错误信息
        /// </summary>
        /// <param name="ex">错误信息</param>
        public void SendExcetpion(Exception ex)
        {
            try
            {
                Common.Logger lg = new Common.Logger();
                lg.LogWrite(Common.Logger.LogLevel.Debug, "", ex.ToString());

                string errorID = VMHelp.GetErrorSerialNo;
                VMHelp.ShowMessage(string.Format("抱歉，系统发生错误，请及时与系统管理员进行联系！\n错误信息:{0}\n", ex.Message), false);
                //note:2013年11月12日15:49:05  显示编号不好看改掉显示错误信息了.
                //VMHelp.ShowMessage(string.Format("抱歉，系统发生错误，请及时与系统管理员进行联系！\n错误信息:{0}\n", errorID), false);
                //Message.Message199 msg = new Message.Message199();
                //msg.ErrorCode = errorID;
                //msg.BankCode = VMHelp.BankCode;
                //msg.PointCode = VMHelp.PointCode;
                //msg.BusinessCode = "199";
                //msg.BusinessTime = VMHelp.NowTime;
                //msg.ErrorMsg = ex.Message + "\n" + ex.StackTrace;
                //BGworker.RunWorkerAsync(msg);
                //BGworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            }
            catch
            {
                //TODO: 发送错误: 发送错误失败应该记录日志
                // throw error; //如果在发送过程中出现错误则直接抛出
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        /// <summary>
        /// 关闭对象
        /// </summary>
        public Action windowClose;
        public Action windowOK;
        private HelpClass _vmHelp;

        /// <summary>
        /// ViewModel帮助
        /// </summary>
        public HelpClass VMHelp
        {
            get
            {
                if (_vmHelp == null) _vmHelp = HelpClass.Current;
                return _vmHelp;
            }
            set { _vmHelp = value; }
        }

        private T currentObj;

        /// <summary>
        /// 当前对象
        /// </summary>
        public T CurrentObj
        {
            get
            {
                if (currentObj == null) currentObj = new T();
                return currentObj;
            }
            set
            {
                currentObj = value;
                RaisePropertyChanged("CurrentObj");
            }
        }

        #endregion 预制对象

        #region 构造初始

        /// <summary>
        /// 加载命令
        /// </summary>
        public abstract void LoadCommand();

        /// <summary>
        /// 加载数据
        /// </summary>
        public virtual void LoadData()
        {
        }

        #endregion 构造初始

        #region 内置

        /// <summary>
        /// 内置初始化
        /// </summary>
        private void Init()
        {
            BGworker = new BackgroundWorker();
            BGworker.DoWork += (o, e) =>
            {
                Message.Message199 msg = e.Argument as Message.Message199;
                Message.MessageSender Sender = new Message.MessageSender(VMHelp.SYSCONFIG.IP, int.Parse(VMHelp.SYSCONFIG.Port));
              //  Message.Message009 response = Sender.SendMessage(msg) as Message.Message009;
            };
            BGworker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    //TODO:如果发送错误信息出现错误的时候 这个应该记录日志 
                }
            };
        }

        /// <summary>
        /// 异步对象用于发送错误消息
        /// </summary>
        private BackgroundWorker BGworker;


        #endregion 内置
    }
}