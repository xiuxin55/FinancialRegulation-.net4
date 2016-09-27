using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;
//using Entity;
namespace FundsRegulatoryClient
{
    public class UserManageClient
    {
        private static UserManageSrv.UserManageSrv usermanagesrv;

        private static UserManageClient s_CurrentInstance = null;

        public static UserManageClient Current
        {
            get
            {
                if (s_CurrentInstance == null)
                {
                    s_CurrentInstance = new UserManageClient();
                }
                return s_CurrentInstance;
            }            
        }
        private UserManageClient()
        {
            usermanagesrv = new UserManageSrv.UserManageSrv();
            Common.CommonFunction.SetBaseWebReference(usermanagesrv);
        }
        //插入用户信息
        public string InsertUser(UserManageSrv.UserInfo ui)
        {
            return usermanagesrv.InsertUser(ui);
        }
        //得到所有用户信息
        public DataSet GetAllUser()
        {
            return usermanagesrv.GetAllUser();
        }
        /// <summary>
        /// 根据用户编号删除用户信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public string DeleteUserByID(string UserID)
        {
            return usermanagesrv.DeleteUserByID(UserID);
        }
        ////根据编号修改用户信息
        //public string UpdateUserByID(string UserCode, string UserPwd, string UserName, string Sex, string LinkTel, string Email, string Describe,string SSQ, string UserID)
        //{
        //    return usermanagesrv.UpdateUserByID(UserCode, UserPwd, UserName, Sex, LinkTel, Email, Describe,SSQ, UserID);
        //}

        //根据编号修改用户信息
        public string UpdateUserByID(UserManageSrv.UserInfo ui)
        {
            return usermanagesrv.UpdateUserByID(ui);
        }

        /// <summary>
        /// 根据用户编号修改用户状态
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        public string UpdataStateByID(string UserID, string State)
        {
            return usermanagesrv.UpdataStateByID(UserID, State);
        }


        /// <summary>
        /// 获取所有可用网点
        /// </summary>
        /// <returns></returns>
        public DataSet GetJG_Branches()
        {
            return usermanagesrv.GetJG_Branches();
        }
    }
}
