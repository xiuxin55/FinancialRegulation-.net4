using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;

namespace FinancialRegulation.ViewModel
{
    interface ISearch
    {
        DelegateCommand SearchCommand { get; set; }
        void SearchExecute();
    }
}
