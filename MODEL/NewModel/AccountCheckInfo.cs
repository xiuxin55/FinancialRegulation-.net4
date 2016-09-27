using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 当日对账明细
    /// </summary>
     public class AccountCheckInfo
    {
        public string  PackageLength { get; set; }
        public string  BusinessCode { get; set; }
        public string  BankCode { get; set; }
        public string FileName { get; set; }//文件名
        public decimal  AccountBalance { get; set; }//账务余额
        public string  PlatformBalance { get; set; }//平台余额
        public string  AccoutCheckInstr{ get; set; }//对账说明
        public DateTime? AccoutCheckTime { get; set; }//对账时间
    }
}
