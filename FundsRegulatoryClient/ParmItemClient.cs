using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.ParmItemSrv;

namespace FundsRegulatoryClient
{
    public class ParmItemClient
    {
        private static ParmItemSrv.ParmItemSrv psrv;
        public ParmItemClient()
        {
            psrv = new ParmItemSrv.ParmItemSrv();
            Common.CommonFunction.SetBaseWebReference(psrv);
        }

        private static ParmItemClient _ParmItemClient;

        public static ParmItemClient Current
        {
            get
            {
                if (_ParmItemClient == null)
                {
                    _ParmItemClient = new ParmItemClient();
                }
                return ParmItemClient._ParmItemClient;
            }
        }

        /// <summary>
        /// 按条件获取
        /// </summary>
        /// 
        /// <returns></returns>
        public List<ParmItem> SelectTheParmItem(ParmItem p)
        {
            return new List<ParmItem>(psrv.SelectTheParmItem(p));
        }
    }
}
