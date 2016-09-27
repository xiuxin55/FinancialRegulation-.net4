using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Common;
using Dao;

namespace OWS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Common.CommonData.GetInstance().ConfigPath = ConfigurationManager.AppSettings["CONPATH"];
            //Common.CommonData.GetInstance().DBPOOLS.Add("BAPOOL", Common.DBConnectionPool.GetDBConnectionPool(ConfigurationManager.ConnectionStrings["BADB"].ConnectionString));
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                Common.CommonData.GetInstance().DBPOOLS.Add(css.Name, Common.DBConnectionPool.GetDBConnectionPool(css.ConnectionString));
            }
            //Common.CommonData.GetInstance().InitSqls();
            
            //Common.CommonData.SetlshNo(CommonBiz.GetNumbers());
            //SocketServer.Start();
            //BaseCommon.CommonData.GetInstance().SetxmlDot();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //SocketServer.Stop();
        }
    }
}