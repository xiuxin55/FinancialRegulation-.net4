using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class BillFile
    {
        /// <summary>
        /// 协议编号
        /// </summary>
        public string PactNo { get; set; }
        /// <summary>
        /// 银行编号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        public BillFileType AccountType { get; set; }
    }

    public enum BillFileType
    {
        /// <summary>
        /// 开发商账户
        /// </summary>
        DeveloperAccount = 1,
        /// <summary>
        /// 担保账户
        /// </summary>
        GuaranteeAccount = 2
    }
}
