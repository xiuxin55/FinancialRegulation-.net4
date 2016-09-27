using System;
using System.Text;
using System.Windows;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace FinancialRegulation.Tools
{
    public class HelpClass
    {
        #region 单例模式

        private static HelpClass _CurrentInstance = null;

        public static HelpClass Current
        {
            get
            {
                if (_CurrentInstance == null)
                {
                    _CurrentInstance = new HelpClass();
                }
                return _CurrentInstance;
            }
        }

        private HelpClass()
        {
            MsgDIC = new Dictionary<string, string>();
            MsgDIC.Add("00", "交易成功");
            MsgDIC.Add("01", "缴款书不存在");
            MsgDIC.Add("02", "缴款书已完成缴费");
            MsgDIC.Add("03", "付款凭证不存在");
            MsgDIC.Add("04", "付款凭证已完成支付");
            MsgDIC.Add("05", "原交易已经冲正");
            MsgDIC.Add("06", "原交易不存在，无法冲正");
            MsgDIC.Add("07", "对账已经初始化");
            MsgDIC.Add("08", "非当日缴交或支付，不允许冲正或退票");
            MsgDIC.Add("09", "尚未缴交或支付，无法冲正或退票");
            MsgDIC.Add("10", "缴交、支付、冲正、退票的金额与实际不一致");
            MsgDIC.Add("11", "对账文件不存在");
            MsgDIC.Add("12", "接口服务发生异常");
            MsgDIC.Add("13", "超过2天未支付，该支付款项已被冻结");
            MsgDIC.Add("14", "由于退票，支付已作废");
            MsgDIC.Add("15", "冲正类型错误");
        }
        #endregion 单例模式

        #region 预制数据
        /// <summary>
        /// 信息
        /// </summary>
        public PublicData ps;

        /// <summary>
        /// 获取一个新的GUID
        /// </summary>
        public string GUID
        {
            get { return Guid.NewGuid().ToString(); }
        }

        /// <summary>
        /// 获取全局的默认通信编码
        /// </summary>
        public Encoding EncodingX
        {
            get { return Encoding.Unicode; }
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        public string NowTime
        {
            get
            {
                return FundsRegulatoryClient.HelpClient.Instance.NowTime.ToString(Common.SysConst.BUSINESSTIMEFORMATE);
            }
        }
        
        /// <summary>
        /// 获取银行端的银行代码
        /// </summary>
        public string BankCode
        {
            get
            {
                //银行是前两位
                return SYSCONFIG.BankCode.Substring(0, 2);
            }
        }

        /// <summary>
        /// 获取当前银行端操作人
        /// </summary>
        public string Person
        {
            get
            {
                return Common.CommonData.GetInstance().LoginUserName;
            }
        }
        public string SysSerialNumber
        {
            get
            {
                string str = BankCode + NowTime.ToString().ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace(".", "").Substring(2);
                return str;
            }
        }
        /// <summary>
        /// 获取当前流水号
        /// </summary>
        public string ServiceNo
        {
            get
            {
                return BankCode + FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            }
        }

        /// <summary>
        /// 获取错误流水号
        /// </summary>
        public string GetErrorSerialNo
        {
            get
            {
                return PointCode + FundsRegulatoryClient.BasicFunctionClient.Current.GetErrorSerialNo();
            }
        }

        /// <summary>
        /// 获取当前网点编号 对应实体的BankCode
        /// </summary>
        public string PointCode
        {
            get
            {
                return (Common.CommonData.GetInstance().UserInfo as BaseClient.LoginSrv.UserInfo).Ssq;
            }
        }
        /// <summary>
        /// 获取银行名称
        /// </summary>
        public string BankName
        {
            get
            {
                return SYSCONFIG.BankName;
            }
        }
        /// <summary>
        /// 获取总行网点号
        /// </summary>
        public string MainWebSite
        {
            get
            {
                return SYSCONFIG.MainWebSite;
            }
        }
        /// <summary>
        /// 获取柜员号UserCode
        /// </summary>
        public string UserCode
        {
            get
            {
                return (Common.CommonData.GetInstance().UserInfo as BaseClient.LoginSrv.UserInfo).UserCode;
            }
        }
       
        /// <summary>
        /// CRC校验码 TODO:未实现
        /// </summary>
        public string CRCCode
        {
            get
            {
                return "CRCCODE";
            }
        }

        private FundsRegulatoryClient.SysConfigSrv.SysConfigInfo _sysConfig;

        /// <summary>
        /// 系统配置
        /// </summary>
        public FundsRegulatoryClient.SysConfigSrv.SysConfigInfo SYSCONFIG
        {
            get
            {
                if (_sysConfig == null) GETSYSTEMCONFIG(); //刷新系统配置对象
                return _sysConfig;
            }
            set { _sysConfig = value; }
        }

        public Dictionary<string,string> MsgDIC;

        #region 超时测试

        /// <summary>
        /// 线程停止 用于测试连接
        /// </summary>
        private ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        /// <summary>
        /// 连接超时设置
        /// </summary>
        /// <param name="remoteEndPoint">ip</param>
        /// <param name="timeoutMSec">超时时间</param>
        /// <returns></returns>
        public bool SocketConnect(string ip, int port, int timeout)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            bool is_ok = false;
            TimeoutObject.Reset();
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.BeginConnect(remoteEndPoint, delegate(IAsyncResult ar) { TimeoutObject.Set(); }, socket);
            //阻塞当前线程,使其等待异步连接,如果在指定时间内
            if (TimeoutObject.WaitOne(timeout, false))
            {
                is_ok = true;//连接正常
            }
            else
            {
                is_ok = false;//连接中断
            }
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            return is_ok;
        }

        /// <summary>
        /// 在线状态(超时检测) 
        /// </summary>

        public bool OneLineState
        {
            get
            {
                return SocketConnect(SYSCONFIG.IP, int.Parse(SYSCONFIG.Port), 2000);

            }
        }
        #endregion

        #endregion 预制数据

        #region 预制方法

        /// <summary>
        /// 刷新系统配置对象
        /// </summary>
        public void GETSYSTEMCONFIG()
        {
            _sysConfig = FundsRegulatoryClient.SysConfigClient.Instance.Selects()[0];
        }

        #region 对话框
        /// <summary>
        /// 全局显示消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="bit">成功失败</param>
        public void ShowMessage(string msg, bool bit)
        {
            MessageBoxImage icon = bit ? MessageBoxImage.Information : MessageBoxImage.Error;
            MessageBox.Show(msg, "系统提示", MessageBoxButton.OK, icon);
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="bit">成功失败</param>
        public void ShowMessage(bool bit)
        {
            MessageBoxImage icon = bit ? MessageBoxImage.Information : MessageBoxImage.Error;
            MessageBox.Show(bit ? "操作成功" : "操作失败", "系统提示", MessageBoxButton.OK, icon);
        }

        /// <summary>
        /// 询问消息
        /// </summary>
        /// <param name="msg">询问消息内容</param>
        /// <returns>点击OK与否</returns>
        public bool AskMessage(string msg)
        {
            return MessageBox.Show(msg, "系统提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }

        ///// <summary>
        ///// 提示对话框获取值
        ///// </summary>
        ///// <param name="o">输出值</param>
        ///// <returns>是否取到</returns>
        //public bool GetValueMessage(out object o)
        //{
        //    Page.MessageWindow mw = new Page.MessageWindow();
        //    mw.ShowDialog();
        //    o = mw.Result;
        //    return o != null;
        //}
        ///// <summary>
        ///// 提示对话框并获取值
        ///// </summary>
        ///// <param name="o">输出值</param>
        ///// <param name="title">窗体标题</param>
        ///// <returns>是否取到</returns>
        //public bool GetValueMessage(out object o, string title)
        //{
        //    Page.MessageWindow mw = new Page.MessageWindow();
        //    mw.Title = title;
        //    mw.ShowDialog();
        //    o = mw.Result;
        //    return o != null;
        //}
        #endregion
        /// <summary>
        /// 返回缴款类型
        /// </summary>
        /// <returns></returns>
        public  string GetMoneyType(string num)
        {
            switch (num)
            {
                case "10": return "首付款";
                case "20": return "分期款";
                case "30": return "一次性付款";
                case "40": return "商业贷款";
                case "50": return "公积金贷款";
                case "80": return "尾款";
                case "90": return "其他或未知";
                default: return null;
            }

        }
        #endregion 预制方法

    }
    /// <summary>
    /// 公共数据标志
    /// 规则:表字典->[表名]_[字段(首字母大写单个字)][标识小写]
    /// </summary>
    public struct PublicData
    {
        public const string BankCode = "07";//银行代码
        #region 通信公开数据
        /// <summary>
        /// 报文返回码
        /// </summary>
        public const string ResponseSuccess = "00";
        public const string DepositFail = "01";//缴款书不存在
        public const string DepositSuccess = "02";//缴款书已完成缴费
        public const string  PaymentFail= "03";//付款凭证不存在
        public const string PaymentSuccess = "04";//付款凭证已经完成支付
        public const string ReverseSucces = "05";//原交易已经冲正
        public const string ReverseFail = "06";//原交易不存在无法冲正
        #endregion
        #region 通信公开数据
        /// <summary>
        /// 交易代码
        /// </summary>
        
        public const string CheckBill = "01";//当日对账
        public const string QueryFundDeposit = "02";//缴存查询
        public const string FundDeposit = "03";//缴存
        public const string QueryFundPay = "04";//支付查询
        public const string FundPay = "05";//支付
        public const string ReverseFund = "06";//冲正
        public const string InterestRecord = "07";//利息补录
        public const string Refund = "08";//退票交易
        public const string UnknowBill = "09";//不明账款对账
        #endregion
        //public const string AdminBankWebSite="0";//总行网点号
        #region 冲正类型
        public const string ReverseDeposit = "01";//缴存类型
        public const string ReversePay = "02";//支付类型
        #endregion
        #region 交易的状态
        public const string DepositA = "已缴存";
        public const string DepositB = "未缴存";
        public const string PayA = "已支付";
        public const string PayB = "未支付";
        public const string ReverseA = "已冲正";
        public const string RefundA = "已退票";
        #endregion
        #region 调账有关
        /// <summary>
        /// 调账流程完成标志 (AdjustAccount lc Finish)
        /// </summary>
        public const string AdjustAccount_Lf = "1";

        /// <summary>
        /// 调账流程未完成 (AdjustAccount lc Apply)
        /// </summary>
        public const string AdjustAccount_La = "0";
        #endregion

        #region 存款有关
        /// <summary>
        /// 存款类别 红冲 (Deposit lb RedChong) 
        /// </summary>
        public const string Deposit_Lrc = "9";
        /// <summary>
        /// 存款类别 存款 (Deposit lb Fund )
        /// </summary>
        public const string Deposit_Lf = "1";
        /// <summary>
        /// 存款类别 调账 (Deposit lb AdjustAccount)
        /// </summary>
        public const string Deposit_Laa = "8";
        #endregion

        #region 支付有关
        /// <summary>
        /// 支付流程 没有通过  (Payment lc Not)
        /// </summary>
        public const string Payment_Ln = "0";
        /// <summary>
        /// 支付流程 通过   (Payment lc Yes)
        /// </summary>
        public const string Payment_Ly = "1";

        //0 重要 1非重要 2 利息 3 扣款 4调账
        /// <summary>
        /// 支付类别 重要 (Payment lb major)
        /// </summary>
        public const string Payment_lm = "0";

        /// <summary>
        /// 支付类别 非重要 (Payment lb not major)
        /// </summary>
        public const string Payment_lnm = "1";

        /// <summary>
        /// 支付类别 利息 (Payment lb accrual)
        /// </summary>
        public const string Payment_la = "2";

        /// <summary>
        /// 支付类别 扣款 (Payment lb withhold)
        /// </summary>
        public const string Payment_lw = "3";

        /// <summary>
        /// 支付类别 调账 (Payment lb AdjustAccount)
        /// </summary>
        public const string Payment_laa = "4";

        #endregion
        /// <summary>
        /// 银行网点 状态 (Branches State OPEN)
        /// </summary>
        public const string Branches_So = "1";

        /// <summary>
        /// 银行网点 状态 (Branches State CLOSE)
        /// </summary>
        public const string Branches_Sc = "0";
    }
}