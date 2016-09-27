using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using MODEL;
using Dao;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// DutyManageSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DutyManageSrv : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 插入职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public string InsertDuty(Duty duty)
        {
            return DutyBiz.InsertDuty(duty);
        }

        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 得到所有的职责
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDuty()
        {
            return DutyBiz.GetAllDuty();
        }
        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 根据编号删除指定职责
        /// </summary>
        /// <param name="DutyID">编号</param>
        /// <returns></returns>
        public string DeleteDutyByID(string DutyID)
        {
            return DutyBiz.DeleteDutyByID(DutyID);
        }
        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 修改职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public string UpdateDuty(Duty duty)
        {
            return DutyBiz.UpdateDuty(duty);
        }
    }
}
