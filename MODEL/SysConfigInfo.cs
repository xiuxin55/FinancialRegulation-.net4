using System;

namespace MODEL
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SysConfigInfo
    {
        private string _bankcode;
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankCode
        {
            get { return _bankcode; }
            set { _bankcode = value; }
        }
        private string _bankname;
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        private string _jgaccount;
        /// <summary>
        /// 监管账户
        /// </summary>
        public string JGAccount
        {
            get { return _jgaccount; }
            set { _jgaccount = value; }
        }
        private string _ip;
        /// <summary>
        /// 转发IP
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private string _port;
        /// <summary>
        /// 转发端口
        /// </summary>
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private DateTime? _payAccuralDate;
        /// <summary>
        /// 结息日期
        /// </summary>
        public DateTime? PayAccuralDate
        {
            get { return _payAccuralDate; }
            set { _payAccuralDate = value; }
        }
        private string _ftpip;
        /// <summary>
        /// 转发IP
        /// </summary>
        public string FtpIP
        {
            get { return _ftpip; }
            set { _ftpip = value; }
        }
        private string _ftppwd;
        /// <summary>
        /// ftp 密码
        /// </summary>
        public string FtpPwd
        {
            get { return _ftppwd; }
            set { _ftppwd = value; }
        }
        private string _ftpuser;
        /// <summary>
        /// ftp 账号
        /// </summary>
        public string FtpUser
        {
            get { return _ftpuser; }
            set { _ftpuser = value; }
        }
        private string _billfolder;
        /// <summary>
        /// 对账文件生成的位置
        /// </summary>
        public string BillFolder
        {
            get { return _billfolder; }
            set { _billfolder = value; }
        }
        private string _mainWebSite;
        /// <summary>
        /// 总行网点号
        /// </summary>
         public string MainWebSite
        {
            get { return _mainWebSite; }
            set { _mainWebSite = value; }
        }
        
   }
}
