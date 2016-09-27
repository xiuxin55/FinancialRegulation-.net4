using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MODEL;


namespace FinancialRegulationSRV
{
    /// <summary>
    /// RegulatorySrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class RegulatorySrv : System.Web.Services.WebService
    {

        /// <summary>
        /// 支付请求 010
        /// </summary>
        /// <param name="JG_PaymentInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public bool PaymentRequest(JG_PaymentInfo JG_PaymentInfo)
        {
            return Dao.RegulatoryDao.insertPaymentInfo(JG_PaymentInfo);
        }
       /// <summary>
       /// 协议确认保存
       /// </summary>
       /// <param name="jG_SpvProtocol"></param>
       /// <returns></returns>
        [WebMethod]
        public bool ProtocolSave(JG_SpvProtocol jG_SpvProtocol)
        {
            return Dao.RegulatoryDao.ProtocolSave(jG_SpvProtocol);
        }

        /// <summary>
        /// 插入报文信息 
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AddJG_MessageInfo(JG_MessageInfo mi)
        {
            return Dao.RegulatoryDao.AddJG_MessageInfo(mi);
        }

        /// <summary>
        /// 账户变更 
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ChangeProtocol(JG_SpvProtocol JG_SpvProtocol)
        {
            return Dao.RegulatoryDao.ChangeProtocol(JG_SpvProtocol);
        }

        /// <summary>
        /// 执行SQL语句 
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet DoSqlRetrun(string sqlStr, string UserCode, string UserPwd)
        {
           return Dao.RegulatoryDao.DoSqlRetrun(sqlStr,UserCode,UserPwd);
        }
    }
}
