using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Dao;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// CommonManagerSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class CommonManagerSrv : System.Web.Services.WebService
    {

        [WebMethod]
        /// <summary>
        /// 根据编号获得相应子项
        /// </summary>
        /// <param name="SetCode">编号</param>
        /// <returns></returns>
        public DataSet GetItemsBySetCode(string[] SetCode)
        {
            return CommonBiz.GetItemsBySetCode(SetCode);
        }

        public static DataSet GetNumbers()
        {
            return CommonBiz.GetNumbers();
        }
        [WebMethod]
        public string GetSerialNo()
        {
            return DateTime.Now.ToString("yyyyMMdd") + Common.CommonData.GetSerialNo(DateTime.Now).ToString().PadLeft(4, '0');
        }
        [WebMethod]
        public string GetListNumber()
        {
            return DateTime.Now.ToString("yyyyMMdd") + Common.CommonData.GetListNumber(DateTime.Now).ToString().PadLeft(4, '0');
        }
        [WebMethod]
        public string GetBusiCode()
        {
            return DateTime.Now.ToString("yyyyMMdd") + Common.CommonData.GetBusiCode(DateTime.Now).ToString().PadLeft(4, '0');
        }

        [WebMethod]
        public string ViewBusiCode()
        {
            return DateTime.Now.ToString("yyyyMMdd") + Common.CommonData.GetBusiCode().ToString().PadLeft(4, '0');
        }

        [WebMethod]
        /// <summary>
        /// 根据参数编号活的参数值
        /// </summary>
        /// <param name="ParmCode">参数编号</param>
        /// <returns></returns>
        public string GetSysParaValue(string ParmCode)
        {
            return CommonBiz.GetSysParaValue(ParmCode);
        }
    }
}
