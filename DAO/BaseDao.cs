using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dao;
using IBatisNet.DataMapper;

namespace Dao
{
    public class BaseDao
    {
        public static ISqlMapper SqlMap = MyBatis.SqlMap;
       
    }
}
