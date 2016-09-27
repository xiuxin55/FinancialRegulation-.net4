using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    /// <summary>
    /// 对账信息
    /// </summary>
    public class BillFile
    {
        public string PackageLength { get; set; }
        public string BusinessCode { get; set; }
        public string BankCode { get; set; }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value; 
              
            }
        }
        private decimal accountBalance;

        public decimal AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value;
           
            }
        }
        private string platformBalance;

        public string PlatformBalance
        {
            get { return platformBalance; }
            set { platformBalance = value;
           
           
            }
        }
        private string accoutCheckInstr;//对账说明

        public string AccoutCheckInstr
        {
            get { return accoutCheckInstr; }
            set { accoutCheckInstr = value;
            }
        }
    }
}
