using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialRegulation.Page.Other
{
    public class BillCheckWindowVm
    {
        private string billInstruction = "";
        /// <summary>
        /// 对账说明
        /// </summary>
        public string BillInstruction
        {
            get { return billInstruction; }
            set
            {
                billInstruction = value;

            }
        }
        private decimal? accountBalance;
        /// <summary>
        /// 对账说明
        /// </summary>
        public decimal? AccountBalance
        {
            get { return accountBalance; }
            set
            {
                accountBalance = value;

            }
        }
    }
}
