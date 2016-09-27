using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialRegulation.Page.Accrual
{
    public class DateSelectWindowVm
    {
        private DateTime? _dtBegin ;
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? DtBegin
        {
            get { return _dtBegin; }
            set { _dtBegin = value; }
        }
        private DateTime? _dtEnd;
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? DtEnd
        {
            get { return _dtEnd; }
            set { _dtEnd = value; }
        }
    }
}
