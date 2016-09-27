using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
//using Entity;
using Dao;
using MODEL;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// UserManageSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UserManageSrv : System.Web.Services.WebService
    {
        //插入用户
        //[WebMethod(EnableSession=true)]
        //public string InsertUser(string UserID, string UserCode, string UserPwd, string UserName, string Sex, string LinkTel, string Email, string State, string Describe,string SSQ)
        //{
        //    return UserBiz.InsertUser(UserID,UserCode,UserPwd,UserName,Sex,LinkTel,Email,State,Describe,SSQ);
        //}

        [WebMethod(EnableSession = true)]
        public string InsertUser(UserInfo ui)
        {
            return UserBiz.InsertUser(ui);
        }

        //得到所有用户信息
        [WebMethod(EnableSession = true)]
        public DataSet GetAllUser()
        {
            return UserBiz.GetAllUser();
        }
        /// <summary>
        /// 根据用户编号删除用户信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string DeleteUserByID(string UserID)
        {
            return UserBiz.DeleteUserByID(UserID);
        }
        // 根据编号修改用户信息
        //[WebMethod(EnableSession = true)]
        //public string UpdateUserByID(UserInfo ui)
        //{
        //    return UserBiz.UpdateUserByID(ui.UserCode, ui.UserPwd, ui.UserName, ui.Sex, ui.LinkTel, ui.Email, ui.Describe, ui.Ssq, ui.UserId);
        //}


        [WebMethod(EnableSession = true)]
        public string UpdateUserByID(UserInfo ui)
        {
            return UserBiz.UpdateUserByID(ui);
        }

        /// <summary>
        /// 根据用户编号修改用户状态
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string UpdataStateByID(string UserID, string State)
        {
            return UserBiz.UpdataStateByID(UserID, State);
        }

        /// <summary>
        /// 获取所有可用网点
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public DataSet GetJG_Branches()
        {
            return UserBiz.GetJG_Branches();
        }
    }
}
