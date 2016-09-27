using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_AdjustSrv;

namespace FundsRegulatoryClient
{
    public class JG_AdjustClient
    {
        private static JG_AdjustClient _currentInstance = null;
        private JG_AdjustSrv.JG_AdjustService jaSrv;

        public static JG_AdjustClient Current
        {
            get
            {
                if (_currentInstance == null)
                {
                    _currentInstance = new JG_AdjustClient();
                }
                return JG_AdjustClient._currentInstance;
            }
            set { JG_AdjustClient._currentInstance = value; }
        }

        public JG_AdjustClient()
        {
            jaSrv = new JG_AdjustSrv.JG_AdjustService();
            Common.CommonFunction.SetBaseWebReference(jaSrv);
        }


        public bool Add(JG_AdjustInfo o)
        {
            return jaSrv.Add(o);
        }
        public bool Update(JG_AdjustInfo o)
        {
            return jaSrv.Update(o);
        }

        /// <summary>
        /// 根据原存款流水号更新调账
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool UpdateJG_AdjustByCklsh(JG_AdjustInfo o)
        {
            return jaSrv.UpdateJG_AdjustByCklsh(o);
        }


        public bool Delete(JG_AdjustInfo o)
        {
            return jaSrv.Delete(o);
        }
        /// <summary>
        /// 获取所有调账
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable GetJG_Adjust(int state)
        {
            return jaSrv.GetJG_Adjust(state);
        }
        /// <summary>
        /// 获取已经调账
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetJG_AdjustO()
        {
            return GetJG_Adjust(1);
        }
        /// <summary>
        /// 获取未调账
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetJG_AdjustX()
        {
            return GetJG_Adjust(0);
        }
        /// <summary>
        /// 获取所有调账信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetJG_AdjustA()
        {
            return GetJG_Adjust(8);
        }

    }
}
