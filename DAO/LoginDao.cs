using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dao;
using MODEL;

namespace Dao
{
    public class LoginDao : BaseDao
    {
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static IList<UserInfo> CheckUserInfo(UserInfo ui)
        {
            IList<UserInfo> temp=SqlMap.QueryForList<UserInfo>("CheckUserInfo", ui);
            return temp;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int UpdateLogin(UserInfo ui)
        {
            return SqlMap.Update("UpdateLogin", ui);
        }
    }
}
