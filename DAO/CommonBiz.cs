using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;

namespace Dao
{
    public class CommonBiz
    {
        /// <summary>
        /// 根据编号获得相应子项
        /// </summary>
        /// <param name="SetCode">编号</param>
        /// <returns></returns>
        public static DataSet GetItemsBySetCode(string[] SetCode)
        {
            DBOperate db = new DBOperate("DADB");
            DataSet ds = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < SetCode.Length; i++)
                {
                    sb.Append(string.Format(@"select PI_ItemCode,PI_ItemName from ParmItem where PI_SetCode='{0}' order by PI_ItemCode;", SetCode[i]));
                }
                ds = db.RunSql(sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return ds;
        }

        /// <summary>
        /// 获取各业务的流水号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetNumbers()
        {
            DataSet ds = null;
            string sql = string.Format(@";SELECT ISNULL (MAX(SerialNo),'000000000000') SerialNo  From ArchiveIndex where SerialNo like '{0}%';
            SELECT ISNULL (MAX(ListNumber),'000000000000') ListNumber  From ArchiveIndex where substring(ListNumber,len(ListNumber)-11,8)='{0}';
            SELECT ISNULL (MAX(BusiCode),'000000000000') ListNumber  From UseBusiness where BusiCode like '{0}%';", DateTime.Now.ToString("yyyyMMdd"));
            DBOperate dbop = new DBOperate("DADB");
            try
            {
                ds = dbop.RunSql(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbop.Despose();
            }
            return ds;
        }
        /// <summary>
        /// 根据参数编号活的参数值
        /// </summary>
        /// <param name="ParmCode">参数编号</param>
        /// <returns></returns>
        public static string GetSysParaValue(string ParmCode)
        {
            string SysParaValue = "";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "select ParmValue from SysParameter where ParmCode='" + ParmCode + "'";
                DataSet ds = db.RunSql(strSql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysParaValue = ds.Tables[0].Rows[0]["ParmValue"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return SysParaValue;
        }
    }
}
