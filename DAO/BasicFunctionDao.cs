using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dao
{
    public class BasicFunctionDao : BaseDao
    {
        public static object GetSerialNo()
        {
            return SqlMap.QueryForObject("GetSerialNo", null);
        }

        public static string GetErrorSerialNo()
        {
            return SqlMap.QueryForObject<string>("JG_GetErrorSerialNo", null);
        }
   
    }
}
