using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class Bill
    {
        public string ProtocolNo { get; set; }
        public string ContractRecordNo { get; set; }
        public decimal Money { get; set; }
        public string FundsNature { get; set; }
        public DateTime Dtime { get; set; }

        public DateTime SDtime { get; set; }
        public DateTime EDtime { get; set; }
    }
}
