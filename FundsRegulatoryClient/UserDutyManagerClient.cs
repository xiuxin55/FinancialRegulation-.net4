using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FundsRegulatoryClient
{
    public class UserDutyManagerClient
    {
        private static UserDutyManagerSrv.UserDutyManagerSrv userdutymanagersrv;

        private static UserDutyManagerClient s_CurrentInstant = null;

        public static UserDutyManagerClient Current
        {
            get 
            {
                if (s_CurrentInstant == null)
                {
                    s_CurrentInstant = new UserDutyManagerClient();
                }
                return s_CurrentInstant;
            }
        }

        private UserDutyManagerClient()
        {
            userdutymanagersrv = new UserDutyManagerSrv.UserDutyManagerSrv();
            Common.CommonFunction.SetBaseWebReference(userdutymanagersrv);
        }

        /// <summary>
        /// 根据用户编号得到用户职责信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public DataSet GetUserDutyByID(string UserID)
        {
            return userdutymanagersrv.GetUserDutyByID(UserID);
        }
        
        /// <summary>
        /// 分配职责
        /// </summary>
        /// <returns></returns>
        public string LicendToUser(UserDutyManagerSrv.UserDuty[] userdutys)
        {
            return userdutymanagersrv.LicendToUser(userdutys);
        }

        /// <summary>
        /// 根据编号移除用户职责
        /// </summary>
        /// <param name="UserDutyIDs">编号</param>
        /// <returns></returns>
        public string RemoveDuty(string[] UserDutyIDs)
        {
            return userdutymanagersrv.RemoveDuty(UserDutyIDs);
        }
    }
}
