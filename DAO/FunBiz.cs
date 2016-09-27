using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using DataBase;
//using System.Data.OracleClient;
using System.Data.SqlClient;

namespace Dao
{
    public class FunBiz
    {
        public static DataSet getFunData()
        {
            DataSet ds;
            
            DBOperate db = new DBOperate("DADB");
            try
            {
                ds = db.RunSql("select * from DSPFUNC;");
                ds.Tables[0].TableName = "UserFuc";
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

        public static bool AddFun(DataSet ds)
        {
            bool result = true;
            DBOperate db = new DBOperate("DADB");
            //DataSet ds;
            //DBOperate db = new DBOperate(@"Data Source=.;Initial Catalog=DZFrame;User ID=sa;Password=sa");
            try
            {
                //DataBaseEx db = new DataBaseEx(DataBaseEx.DBTypes.SQLServer, @"Data Source=2011-20110902HE\SQLSERVER2005;Initial Catalog=AHMS;User ID=sa;Password=111111");

                DataRow dr = ds.Tables[0].Rows[0];
                string sql = string.Format(@"delete DSPFUNC where ID='{0}';
                insert into DSPFUNC(ID,Code,Name,Layer,IsDetail,InvokingConfig) values('{0}','{1}','{2}','{3}','{4}','{5}');", dr["ID"], dr["Code"], dr["Name"], dr["Layer"], dr["IsDetail"], dr["InvokingConfig"]);

                db.RunSqlNonQuery(sql);


            }
            catch
            {
                result = false;
            }
            finally
            {
                db.Despose();
            }
            return result;
        }

        public static bool DeleteFun(string id)
        {
            bool result = true;
            //DataSet ds;
            //DBOperate db = new DBOperate(@"Data Source=.;Initial Catalog=DZFrame;User ID=sa;Password=sa");;
            DBOperate db=null;
            try
            {
                //DataBaseEx db = new DataBaseEx(DataBaseEx.DBTypes.SQLServer, @"Data Source=2011-20110902HE\SQLSERVER2005;Initial Catalog=AHMS;User ID=sa;Password=111111");
                db = new DBOperate("DADB");
                SqlParameter[] sps = new SqlParameter[] { new SqlParameter("@id", id) };
                string sql = "delete DSPFUNC where ID=@id;";

                db.RunSqlNonQuery(sql,sps);
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (db != null)
                {
                    db.Despose();
                }
            }
            return result;

        }

        public static DataSet GetDutyFun(string dutyid)
        {
            DataSet dsAllUser = new DataSet();
            DataTable dt = new DataTable();
            DBOperate db = new DBOperate("DADB");
            try
            {
                SqlParameter[] sps = new SqlParameter[] { new SqlParameter("@dutyid", dutyid) };
                string strSql = "select MENUID,Code,Name,Layer,IsDetail,InvokingConfig from DSPFUNC where MENUID in (select FunID as ID from DutyFun where DutyID =@dutyid)order by Code";
                dsAllUser = db.RunSql(strSql, sps);

                strSql = "select MENUID,Code,Name,Layer,IsDetail,InvokingConfig from DSPFUNC where MENUID not in (select FunID as ID from DutyFun where DutyID =@dutyid and layer='3')order by Code";
                dt = db.RunSql(strSql, sps).Tables[0].Copy();
                dt.TableName = "dtDuty";
                dsAllUser.Tables.Add(dt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return dsAllUser;
        }

        public static bool SetFun(string dutyid, string[] funids)
        {
            bool result=true;
            DBOperate db = new DBOperate("DADB");
            try
            {
                List<SqlParameter> splist = new List<SqlParameter>();
                splist.Add(new SqlParameter("@dutyid", dutyid));
                StringBuilder strSql = new StringBuilder("begin Delete DutyFun where DutyID =@dutyid;");
                string dfid = Guid.NewGuid().ToString();
                for (int i = 0;i< funids.Length; i++)
                {
                    dfid=Guid.NewGuid().ToString();
                    strSql.Append("insert into DutyFun(DF_ID,DutyID,FunID) values(@DF_ID" + i.ToString() + ",@dutyid,@funid" + i.ToString() + ");");
                    splist.Add(new SqlParameter("@DF_ID" + i.ToString(), dfid));
                    splist.Add(new SqlParameter("@funid" + i.ToString(), funids[i]));
                }
                strSql.Append(" end;");
                SqlParameter[] sps = splist.ToArray();
                db.RunSqlNonQuery(strSql.ToString(), sps);
            }
            catch (Exception ex)
            {
                result = false;
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
