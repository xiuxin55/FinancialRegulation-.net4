using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL;
using Dao;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// BaseManageSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BaseManageSrv : System.Web.Services.WebService
    {

        [WebMethod]
        public List<MenuItem> GetMenu()
        {
            return MenuDao.GetMenu();
        }

        [WebMethod]
        public List<MenuItem> GetMenuItems()
        {
            return MenuDao.GetMenuItems();
        }

        [WebMethod]
        public bool AddMenuItem(MenuItem mi,out string e)
        {
            return MenuDao.AddMenuItem(mi, out e);
        }
        [WebMethod]
        public bool DeleteMenuItem(MenuItem mi, out string e)
        {
            return MenuDao.DeleteMenuItem(mi, out e);
        }
        [WebMethod]
        public bool ModMenuItem(MenuItem mi, out string e)
        {
            return MenuDao.ModMenuItem(mi, out e);
        }
    }
}
