using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;

namespace Dao
{
    public class MenuDao : BaseDao
    {
        public static List<MenuItem> GetMenu()
        {
            return SqlMap.QueryForList<MenuItem>("GetMenu", null).ToList<MenuItem>();
        }

        public static List<MenuItem> GetMenuItems()
        {
            return SqlMap.QueryForList<MenuItem>("GetMenuItem", null).ToList<MenuItem>();
        }

        public static bool AddMenuItem(MenuItem mi,out string e)
        {
            bool result = true;
            try
            {
                SqlMap.Insert("InsertMenuItem", mi);
                e = null;
            }
            catch (Exception ex)
            {
                result = false;
                e = ex.Message;
            }
            return result;
        }
        public static bool DeleteMenuItem(MenuItem mi, out string e)
        {
            bool result = true;
            try
            {
                SqlMap.Delete("DeleteMenuItem", mi);
                e = null;
            }
            catch (Exception ex)
            {
                result = false;
                e = ex.Message;
            }
            return result;
        }
        public static bool ModMenuItem(MenuItem mi, out string e)
        {
            bool result = true;
            try
            {
                SqlMap.Update("UpdateMenuItem", mi);
                e = null;
            }
            catch (Exception ex)
            {
                result = false;
                e = ex.Message;
            }
            return result;
        }
    }
}
