using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// BaseManagerSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BaseManagerSrv : System.Web.Services.WebService
    {
        /// <summary>
        /// 得到当前时间
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession=true)]        
        public DateTime GetNowTime()
        {
            return DateTime.Now;
        }
        /// <summary>
        /// 正则表达式匹配字符串格式
        /// </summary>
        /// <param name="formatString">匹配格式</param>
        /// <param name="CheckCont">字符串</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool CheckFormat(string formatString, string CheckCont)
        {
            Regex r = new Regex(formatString);
            Match m = r.Match(CheckCont);
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
