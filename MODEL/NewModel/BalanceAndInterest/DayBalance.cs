using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel.BalanceAndInterest
{
    public class DayBalance
    {
        public string ID { get; set; }
        public string DB_ID { get; set; }
        public string DB_AccountNum { get; set; }//账号
        public decimal? DB_Interest { get; set; }//利息
        public decimal? DB_Balance { get; set; }//余额
        public DateTime? DB_Time { get; set; }
        public decimal? DB_InterestRate { get; set; }//利率
        
    }
}
