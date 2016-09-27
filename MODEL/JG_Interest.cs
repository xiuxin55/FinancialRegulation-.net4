using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class JG_Interest
    {
        public string IT_ID { get; set; }
        public DateTime IT_Date { get; set; }
        public string IT_ProtocolNo { get; set; }
        public decimal IT_Amount { get; set; }
        public decimal IT_InterestRate { get; set; }
        public decimal IT_Interest { get; set; }
        public string IT_SettleFlag { get; set; }
    }
}
