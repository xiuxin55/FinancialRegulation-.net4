using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class ParmItem
    {
        public string PI_SETCODE { get; set; }
        public string PI_ITEMCODE { get; set; }
        public string PI_ITEMNAME { get; set; }
        public string PI_COLORVALUE { get; set; }
        public int? PI_ITEMVALUE { get; set; }
        public string PI_PARENTSETCODE { get; set; }
        public bool IsChecked { get; set; }
    }
}
