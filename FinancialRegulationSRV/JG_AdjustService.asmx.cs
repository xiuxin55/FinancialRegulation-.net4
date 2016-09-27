using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using Model;

namespace WebService
{
    /// <summary>
    /// JG_AdjustService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_AdjustService : System.Web.Services.WebService
    {
        JG_AdjustDao daoHelp = JG_AdjustDao.Instance;

        [WebMethod(Description = "添加调账")]
        public bool Add(JG_AdjustInfo o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description = "更新调账")]
        public bool Update(JG_AdjustInfo o)
        {
            return daoHelp.Update(o);
        }

        [WebMethod(Description = "根据原存款流水号更新调账")]
        public bool UpdateJG_AdjustByCklsh(JG_AdjustInfo o)
        {
            return daoHelp.UpdateJG_AdjustByCklsh(o);
        }

        [WebMethod(Description = "删除调账")]
        public bool Delete(JG_AdjustInfo o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description = "查看所有调账")]
        public List<JG_AdjustInfo> Selects()
        {
            return daoHelp.Selects() as List<JG_AdjustInfo>;
        }
        [WebMethod(Description = "查看特定调账")]
        public List<JG_AdjustInfo> Select(JG_AdjustInfo o)
        {
            return daoHelp.Select(o) as List<JG_AdjustInfo>;
        }
        [WebMethod(Description = "获取所有调账数据")]
        public System.Data.DataTable GetJG_Adjust(int ProcessState)
        {
            return daoHelp.GetJG_Adjust(ProcessState);
        }


    }
}
