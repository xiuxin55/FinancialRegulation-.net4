using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DataBase;
using System.Data;
using System.Data.SqlClient;
using MODEL;
namespace Dao
{
    public class UserDutyBiz
    {
        /// <summary>
        /// 根据用户编号得到用户职责信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public static DataSet GetUserDutyByID(string UserID)
        {
            DataSet ds = new DataSet();
            DataTable dt=new DataTable();
            DBOperate db= new DBOperate("DADB");
            try
            {
                string strSql = "select UserDutyID,Duty.DutyID,DutyCode,DutyName from Duty inner join UserDuty on Duty.DutyID=UserDuty.DutyID where UserID='"+UserID+"'";
                ds=db.RunSql(strSql).Copy();

                strSql="select DutyID,DutyCode,DutyName from Duty where DutyID not in (select DutyID from UserDuty where UserID='"+UserID+"')";
                dt = db.RunSql(strSql).Tables[0].Copy();
                dt.TableName = "dtDuty";
                ds.Tables.Add(dt);
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
        /// 分配职责
        /// </summary>
        /// <param name="lsUserDuty">用户职责</param>
        /// <returns></returns>
        public static string LicendToUser(UserDuty[] userdutys)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            db.BeginTransaction();
            try
            {
                StringBuilder sb = new StringBuilder();
                int count = userdutys.Length;
                string UserDutyId =  Guid.NewGuid().ToString();
                if (count > 1)
                {
                    sb.Append("begin ");
                    for (int i = 0; i < count; i++)
                    {
                        UserDutyId = Guid.NewGuid().ToString();
                        sb.Append(string.Format("insert into UserDuty(USERDUTYID,UserID,DutyID) values('{0}','{1}','{2}');", UserDutyId, userdutys[i].UserID, userdutys[i].DutyID));
                    }
                    sb.Append(" end;");
                }
                else
                {
                    sb.Append(string.Format("insert into UserDuty(USERDUTYID,UserID,DutyID) values('{0}','{1}','{2}')", UserDutyId, userdutys[0].UserID, userdutys[0].DutyID));
                }
                db.RunSqlNonQuery(sb.ToString());
                db.Commit();
                result = "1";
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
        /// <summary>
        /// 根据编号移除用户职责
        /// </summary>
        /// <param name="UserDutyIDs">编号</param>
        /// <returns></returns>
        public static string RemoveDuty(string[] UserDutyIDs)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            db.BeginTransaction();
            int count = UserDutyIDs.Length;
            try
            {
                StringBuilder sb = new StringBuilder();
                if (count > 0)
                {
                    sb.Append("begin ");
                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(string.Format("delete from UserDuty where UserDutyID='{0}';", UserDutyIDs[i]));
                    }
                    sb.Append(" end;");
                }
                else
                {
                    sb.Append(string.Format("delete from UserDuty where UserDutyID='{0}'", UserDutyIDs[0]));
                }
                db.RunSqlNonQuery(sb.ToString());
                result = "1";
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
