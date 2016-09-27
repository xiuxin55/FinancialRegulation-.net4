using System;

namespace MODEL
{
    /// <summary>
    /// 监管账户管理表
    /// </summary>
    public class JG_AccountManageInfo
    {
        private string _am_id;
        /// <summary>
        /// ID
        /// </summary>
        public string AM_ID
        {
            get { return _am_id; }
            set { _am_id = value; }
        }
        private string _am_zhmc;
        /// <summary>
        /// 账户名称
        /// </summary>
        public string AM_zhmc
        {
            get { return _am_zhmc; }
            set { _am_zhmc = value; }
        }
       
        private string _am_corpname;
        /// <summary>
        /// 企业名称
        /// </summary>
        public string AM_CorpName
        {
            get { return _am_corpname; }
            set { _am_corpname = value; }
        }
        private string _am_itemname;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string AM_ItemName
        {
            get { return _am_itemname; }
            set { _am_itemname = value; }
        }
        private string aM_ProjectCode;
        /// <summary>
        /// 项目标识码
        /// </summary>
        public string AM_ProjectCode
        {
            get { return aM_ProjectCode; }
            set { aM_ProjectCode = value; }
        }
        private string _am_jgaccount;
        /// <summary>
        /// 账号
        /// </summary>
        public string AM_JgAccount
        {
            get { return _am_jgaccount; }
            set { _am_jgaccount = value; }
        }

        private DateTime? _am_createdate;
        /// <summary>
        /// 开户时间
        /// </summary>
        public DateTime? AM_CreateDate
        {
            get { return _am_createdate; }
            set { _am_createdate = value; }
        }
        private string _am_useflag;
        /// <summary>
        /// 使用标志 0:销户 1:正常
        /// </summary>
        public string AM_UseFlag
        {
            get { return _am_useflag; }
            set { _am_useflag = value; }
        }
        private string _am_person;
        /// <summary>
        /// 开户人
        /// </summary>
        public string AM_Person
        {
            get { return _am_person; }
            set { _am_person = value; }
        }
        private string _am_BankCode;
        /// <summary>
        /// 银行代码
        /// </summary>
        public string AM_BankCode
        {
            get { return _am_BankCode; }
            set { _am_BankCode = value; }
        }
       
   }
}
