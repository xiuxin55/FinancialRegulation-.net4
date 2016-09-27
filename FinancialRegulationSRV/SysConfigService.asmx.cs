using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using MODEL;
using System.IO;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// SysConfigService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class SysConfigService : System.Web.Services.WebService
    {
        SysConfigDao daoHelp =  SysConfigDao.Instance;

        [WebMethod(Description="更新[系统配置]")]
        public bool Update(SysConfigInfo o)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + o.BillFolder;
            DirectoryInfo di = new DirectoryInfo(filepath);
            if (!di.Exists) { return false; }
            return daoHelp.Update(o);
        }
        [WebMethod(Description="查看所有[系统配置]")]
        public List<SysConfigInfo> Selects()
        {
            return daoHelp.Selects() as List<SysConfigInfo>;
        }
    }
}
