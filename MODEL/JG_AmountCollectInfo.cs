using System;

namespace MODEL
{
    /// <summary>
    /// JG_AmountCollect
    /// </summary>
    public class JG_AmountCollectInfo
    {
        private string _ac_id;
        /// <summary>
        /// 归集ID
        /// </summary>
        public string AC_ID
        {
            get { return _ac_id; }
            set { _ac_id = value; }
        }
        private string _ac_xybh;
        /// <summary>
        /// 协议编号
        /// </summary>
        public string AC_xybh
        {
            get { return _ac_xybh; }
            set { _ac_xybh = value; }
        }
        private string _ac_cklsh;
        /// <summary>
        /// 存款流水号
        /// </summary>
        public string AC_cklsh
        {
            get { return _ac_cklsh; }
            set { _ac_cklsh = value; }
        }
        private string _ac_skfzh;
        /// <summary>
        /// 收款方账户
        /// </summary>
        public string AC_skfzh
        {
            get { return _ac_skfzh; }
            set { _ac_skfzh = value; }
        }
        private string _ac_fkfzh;
        /// <summary>
        /// 付款方账户(来自于哪个账户)
        /// </summary>
        public string AC_fkfzh
        {
            get { return _ac_fkfzh; }
            set { _ac_fkfzh = value; }
        }
        private string _ac_yhmc;
        /// <summary>
        /// 银行名称
        /// </summary>
        public string AC_yhmc
        {
            get { return _ac_yhmc; }
            set { _ac_yhmc = value; }
        }
        private decimal _ac_ckje;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal AC_ckje
        {
            get { return _ac_ckje; }
            set { _ac_ckje = value; }
        }
        private DateTime _ac_cksj;
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AC_cksj
        {
            get { return _ac_cksj; }
            set { _ac_cksj = value; }
        }
        private decimal _ac_fkfye;
        /// <summary>
        /// 付款账户余额
        /// </summary>
        public decimal AC_fkfye
        {
            get { return _ac_fkfye; }
            set { _ac_fkfye = value; }
        }
        private decimal _ac_skfye;
        /// <summary>
        /// 收款账户余额
        /// </summary>
        public decimal AC_skfye
        {
            get { return _ac_skfye; }
            set { _ac_skfye = value; }
        }

        private string _ac_BankCode;
        /// <summary>
        /// 银行代码
        /// </summary>
        public string AC_BankCode
        {
            get { return _ac_BankCode; }
            set { _ac_BankCode = value; }
        }

   }
}
