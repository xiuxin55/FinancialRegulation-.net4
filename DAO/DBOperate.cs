using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using BaseCommon;
//using System.Data.OracleClient;

namespace Dao
{
    public class DBOperate
    {
        private string dbsoure;

        private SqlConnection con;
        //private OracleConnection con;

        private IDbTransaction trans;

        private bool IsFromPool;

        public DBOperate(string soure)
        {
            this.dbsoure = soure;
            con=Common.CommonData.GetInstance().DBPOOLS[soure].GetDBConnection();
        }

        public DBOperate(string soure,bool frompool)
        {
            this.IsFromPool = frompool;
            if (IsFromPool)
            {
                this.dbsoure = soure;
                con = Common.CommonData.GetInstance().DBPOOLS[soure].GetDBConnection();
            }
            else
            {
                this.dbsoure = soure;
                con = new SqlConnection(soure);
                con.Open();
            }
            
        }

        public void BeginTransaction()
        {
            trans = con.BeginTransaction();
        }

        /// <summary>
        /// 提交数据库处理操作
        /// </summary>
        public void Commit()
        {
            if (null != trans)
            {
                trans.Commit();
                trans = null;
            }
        }
        /// <summary>
        /// 回滚数据库处理操作
        /// </summary>
        public void Rollback()
        {
            if (null != trans)
            {
                trans.Rollback();
                trans = null;
            }
        }

        public DataSet RunSql(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbCommand cmd;
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 100000;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                IDbDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + sql + "\r\n" + e.Message);
            }
            finally
            {
            }


        }

        public DataSet RunSql(string sql, IDataParameter[] parms)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbCommand cmd;
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                if (parms.Length != 0)
                {
                    foreach (IDbDataParameter parameter in parms)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                IDbDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + sql + "\r\n" + e.Message);
            }
            finally
            {
            }


        }

        public void RunSqlNonQuery(string sql)
        {
            try
            {
                IDbCommand cmd;
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + sql + "\r\n" + e.Message);
            }
            finally
            {
            }
        }

        public void RunSqlNonQuery(string sql, IDataParameter[] parms)
        {
            try
            {
                IDbCommand cmd;
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                if (parms.Length != 0)
                {
                    foreach (IDbDataParameter parameter in parms)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + sql + "\r\n" + e.Message);
            }
            finally
            {
            }
        }

        public DataSet RunPrc(string prcname)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbDataAdapter adapter = new SqlDataAdapter();
                IDbCommand cmd;
                cmd = new SqlCommand(prcname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + prcname + "\r\n" + e.Message);
            }
            finally
            {
            }
            return ds;
        }

        public DataSet RunPrc(string prcname, IDataParameter[] parms)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbDataAdapter adapter = new SqlDataAdapter();
                IDbCommand cmd;
                cmd = new SqlCommand(prcname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
                if (parms.Length != 0)
                {
                    foreach (IDbDataParameter parameter in parms)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {
                throw new Exception("Execute Sql Error:" + prcname + "\r\n" + e.Message);
            }
            finally
            {
            }
            return ds;
        }

        public void Despose()
        {
            if (IsFromPool)
            {
                Common.CommonData.GetInstance().DBPOOLS[dbsoure].ReturnDBConnection(con);
                con = null;
            }
            else
            {
                con.Close();
                con.Dispose();
            }
        }

        //public DataSet RunProc()
        //{
        //}
    }
}
