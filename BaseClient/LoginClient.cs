using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseClient.LoginSrv;
using Common;

namespace BaseClient
{
    public class LoginClient
    {
        private static LoginSrv.LoginSrv lgrv;
        SysConfigSrv.SysConfigService scsrv;

        //Common.Logger lg;
        public LoginClient()
        {
            //lg = new Logger();
                
            
            lgrv = new LoginSrv.LoginSrv();
            scsrv = new SysConfigSrv.SysConfigService();
            //lg.LogWrite(Logger.LogLevel.Debug, "", lgrv.Url.ToString());
            Common.CommonFunction.SetBaseWebReference(lgrv);
            Common.CommonFunction.SetBaseWebReference(scsrv);
            //lg.LogWrite(Logger.LogLevel.Debug, "", lgrv.Url.ToString());
        }

        private static LoginClient _LoginClient;

        public static LoginClient Current
        {
            get
            {
                if (_LoginClient == null)
                {
                    _LoginClient = new LoginClient();
                }
                return LoginClient._LoginClient;
            }
        }

        /// <summary>
        /// 按条件获取
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> CheckUserInfo(UserInfo ui)
        {
            List<UserInfo> userInfo = new List<UserInfo>(lgrv.CheckUserInfo(ui));
            if (userInfo != null && userInfo.Count != 0)
            {
                Common.CommonData.GetInstance().UserInfo = userInfo[0];
                Common.CommonData.GetInstance().LoginUserCode = userInfo[0].UserCode;
                Common.CommonData.GetInstance().LoginUserName = userInfo[0].UserName;
                Common.CommonData.GetInstance().SSQ = userInfo[0].Ssq;
            }
            Common.CommonData.Instance.SysConfig = scsrv.Selects()[0];
            return userInfo;        
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UpdateLogin(UserInfo ui)
        {
            return lgrv.UpdateLogin(ui);
        }
    }
}
