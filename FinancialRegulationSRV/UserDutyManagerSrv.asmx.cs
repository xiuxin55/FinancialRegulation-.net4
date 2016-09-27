using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Dao;
using MODEL;
namespace FinancialRegulationSRV
{
    /// <summary>
    /// UserDutyManagerSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UserDutyManagerSrv : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 根据用户编号得到用户职责信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public DataSet GetUserDutyByID(string UserID)
        {
            return UserDutyBiz.GetUserDutyByID(UserID);
        }
        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 分配职责
        /// </summary>
        /// <returns></returns>
        public string LicendToUser(UserDuty[] userdutys)
        {
            return UserDutyBiz.LicendToUser(userdutys);
        }
        [WebMethod(EnableSession = true)]
        /// <summary>
        /// 根据编号移除用户职责
        /// </summary>
        /// <param name="UserDutyIDs">编号</param>
        /// <returns></returns>
        public string RemoveDuty(string[] UserDutyIDs)
        {
            return UserDutyBiz.RemoveDuty(UserDutyIDs);
        }
    }
}
