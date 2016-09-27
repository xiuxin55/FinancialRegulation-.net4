using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class JG_InterestRateInfo
    {
        public string ID { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime SetDate { get; set; }
        public string Remark { get; set; }
        public string Flag { get; set; }
    }
}
