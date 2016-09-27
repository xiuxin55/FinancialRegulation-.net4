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
    /// LoginSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LoginSrv : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        ///
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [WebMethod]
        public List<UserInfo> CheckUserInfo(UserInfo ui)
        {
            return LoginDao.CheckUserInfo(ui) as List<UserInfo>;

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [WebMethod]
        public int UpdateLogin(UserInfo ui)
        {
            return LoginDao.UpdateLogin(ui);
        }
    }
}
