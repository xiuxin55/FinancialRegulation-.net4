using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportManage
{
    public interface IExcelReport
    {
        bool ExcelPrint();
        bool ExcelSave();
        bool ExcelSaveAs();
    }
}
