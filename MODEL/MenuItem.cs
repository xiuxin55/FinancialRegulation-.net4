using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class MenuItem
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public int Layer { get; set; }
        public string Parent { get; set; }
        public string IsDetail { get; set; }
        public string InvokingConfig { get; set; }
        public string AssemblyName { get; set; }
        public string WindowName { get; set; }  
        public int Ordinal { get; set; }   
        public List<MenuItem> Children { get; set; }
    }
}
