using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundsRegulatoryClient
{
    public class HelpClient:BaseClient<HelpSrv.HelpService>
    {
        private static HelpClient _instance;
        /// <summary>
        /// 获取 [帮助] 操作对象实例
        /// </summary>
        public static HelpClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HelpClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 服务器当前时间
        /// </summary>
        public DateTime NowTime
        {
            get
            {
                return service.GetNowTime();
            }
        }
    }
}
