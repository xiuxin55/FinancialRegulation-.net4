using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseClient.BaseManageSrv;

namespace BaseClient
{
    public class MenuClient
    {
        private BaseManageSrv.BaseManageSrv bmsrv;
        private static MenuClient menuClient;
        public static MenuClient Current
        {
            get
            {
                if (null == menuClient)
                {
                    menuClient = new MenuClient();
                }
                return menuClient;
            }
        }

        private MenuClient()
        {
            bmsrv = new BaseManageSrv.BaseManageSrv();
            Common.CommonFunction.SetBaseWebReference(bmsrv);
        }

        public List<MenuItem> GetMenu()
        {
            return bmsrv.GetMenu().ToList<MenuItem>();
        }
        public List<MenuItem> GetMenuItems()
        {
            return bmsrv.GetMenuItems().ToList<MenuItem>();
        }
        public bool AddMenuItem(MenuItem mi, out string e)
        {
            return bmsrv.AddMenuItem(mi, out e);
        }
        public bool DeleteMenuItem(MenuItem mi, out string e)
        {
            return bmsrv.DeleteMenuItem(mi, out e);
        }

        public bool ModMenuItem(MenuItem mi, out string e)
        {
            return bmsrv.ModMenuItem(mi, out e);
        }
    }
}
