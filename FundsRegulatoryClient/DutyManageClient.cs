using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;

namespace FundsRegulatoryClient
{
    public class DutyManageClient
    {
        private static DutyManageSrv.DutyManageSrv dutymanagesrv;
        private static DutyManageClient s_CurrentInstance = null;
        public static DutyManageClient Current
        {
            get
            {
                if(s_CurrentInstance==null)
                {
                    s_CurrentInstance=new DutyManageClient();
                }
                return s_CurrentInstance;
            }
        }
        private DutyManageClient()
        {
            dutymanagesrv=new DutyManageSrv.DutyManageSrv();
            Common.CommonFunction.SetBaseWebReference(dutymanagesrv);
        }

        /// <summary>
        /// 插入职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public string InsertDuty(FundsRegulatoryClient.DutyManageSrv.Duty duty)
        {
            return dutymanagesrv.InsertDuty(duty);
        }

        /// <summary>
        /// 得到所有的职责
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDuty()
        {
            return dutymanagesrv.GetAllDuty();
        }


        /// <summary>
        /// 根据编号删除指定职责
        /// </summary>
        /// <param name="DutyID">编号</param>
        /// <returns></returns>
        public string DeleteDutyByID(string DutyID)
        {
            return dutymanagesrv.DeleteDutyByID(DutyID);
        }

        /// <summary>
        /// 修改职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public string UpdateDuty(FundsRegulatoryClient.DutyManageSrv.Duty duty)
        {
            return dutymanagesrv.UpdateDuty(duty);
        }
    }
}
