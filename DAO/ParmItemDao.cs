using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;

namespace Dao
{
    public class ParmItemDao:BaseDao
    {

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static IList<ParmItem> SelectTheParmItem(ParmItem p)
        {
            return SqlMap.QueryForList<ParmItem>("SelectTheParmItem", p);
        }
    }
}
