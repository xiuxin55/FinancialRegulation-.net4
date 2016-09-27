using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace FundsRegulatoryClient
{
    public class CommonManagerClient
    {
        private static CommonManagerSrv.CommonManagerSrv commonmanagersrv;
        private static CommonManagerClient s_CurInstance = null;
        public static CommonManagerClient Current
        {
            get 
            {
                if (s_CurInstance == null)
                {
                    s_CurInstance = new CommonManagerClient();
                }
                return s_CurInstance;
            }
        }
        private CommonManagerClient()
        {
            commonmanagersrv = new FundsRegulatoryClient.CommonManagerSrv.CommonManagerSrv();
            Common.CommonFunction.SetBaseWebReference(commonmanagersrv);
        }

        /// <summary>
        /// 根据编号获得相应子项
        /// </summary>
        /// <param name="SetCode">编号</param>
        /// <returns></returns>
        public DataSet GetItemsBySetCode(string[] SetCode)
        {
            return commonmanagersrv.GetItemsBySetCode(SetCode);
        }
        /// <summary>
        /// 获得档案流水号
        /// </summary>
        /// <returns></returns>
        public string GetSerialNo()
        {
            return commonmanagersrv.GetSerialNo();
        }
        /// <summary>
        /// 获得清单编号流水号
        /// </summary>
        /// <returns></returns>
        public string GetListNumber()
        {
            return commonmanagersrv.GetListNumber();
        }
        /// <summary>
        /// 获得业务利用流水号
        /// </summary>
        /// <returns></returns>
        public string GetBusiCode()
        {
            return commonmanagersrv.GetBusiCode();
        }
        /// <summary>
        /// 根据参数编号活的参数值
        /// </summary>
        /// <param name="ParmCode">参数编号</param>
        /// <returns></returns>
        public string GetSysParaValue(string ParmCode)
        {
            return commonmanagersrv.GetSysParaValue(ParmCode);
        }
    }
}
