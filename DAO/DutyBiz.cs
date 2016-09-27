using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.OracleClient;
using System.Data.SqlClient;
//using DataBase;
using MODEL;
namespace Dao
{
    public class DutyBiz
    {
        /// <summary>
        /// 插入职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public static string InsertDuty(Duty duty)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string DutyId = Guid.NewGuid().ToString();
                string strSql = "insert into Duty(DutyId,DutyCode,DutyName,Describe) values(@DutyId,@DutyCode,@DutyName,@Describe)";
                db.RunSqlNonQuery(strSql, new SqlParameter[] {new SqlParameter("@DutyId",DutyId),
                                                                new SqlParameter("@DutyCode",duty.DutyCode),
                                                               new SqlParameter("@DutyName",duty.DutyName),
                                                               new SqlParameter("@Describe",duty.Describe)});
                result = "1";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
        /// <summary>
        /// 得到所有的职责
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllDuty()
        {
            DataSet ds = new DataSet();
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "select * from Duty";
                ds = db.RunSql(strSql);
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
        /// 根据编号删除指定职责
        /// </summary>
        /// <param name="DutyID">编号</param>
        /// <returns></returns>
        public static string DeleteDutyByID(string DutyID)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "delete from Duty where DutyID=@DutyID";
                db.RunSqlNonQuery(strSql, new SqlParameter[] { new SqlParameter("@DutyID", DutyID) });
                result = "1";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
        /// <summary>
        /// 修改职责信息
        /// </summary>
        /// <param name="duty">职责对象</param>
        /// <returns></returns>
        public static string UpdateDuty(Duty duty)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "update Duty set DutyCode=@DutyCode,DutyName=@DutyName,Describe=@Describe where DutyID=@DutyID";
                db.RunSqlNonQuery(strSql, new SqlParameter[] { new SqlParameter("@DutyCode",duty.DutyCode),
                                                               new SqlParameter("@DutyName",duty.DutyName),
                                                               new SqlParameter("@Describe",duty.Describe),
                                                               new SqlParameter("@DutyID",duty.DutyID)});
                result = "1";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
    }
}
