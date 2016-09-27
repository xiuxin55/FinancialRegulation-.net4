using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DataBase;
//using Entity;
using System.Data;
//using System.Data.OracleClient;
using System.Data.SqlClient;
using MODEL;

namespace Dao
{
    public class UserBiz
    {
        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="UserCode">用户编号</param>
        /// <param name="UserPwd">用户密码</param>
        /// <param name="UserName">用户姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="LinkTel">联系电话</param>
        /// <param name="Email">邮箱</param>
        /// <param name="State">状态</param>
        /// <param name="Describe">描述</param>
        /// <returns></returns>
        //public static string InsertUser(string UserID,string UserCode, string UserPwd, string UserName, string Sex, string LinkTel, string Email, string State, string Describe,string SSQ)
        //{
        //    string result = "0";
        //    DBOperate db = new DBOperate("DADB");
        //    try
        //    {
        //        string strSql = "insert into UserInfo(UserID,UserCode,UserPwd,UserName,Sex,LinkTel,Email,\"State\",Describe,SSQ)values(:UserID,:UserCode,:UserPwd,:UserName,:Sex,:LinkTel,:Email,:State,:Describe,:SSQ)";

        //        OracleParameter[] sps = new OracleParameter[] {new OracleParameter("UserID",UserID),
        //                                                 new OracleParameter("UserCode",UserCode),
        //                                                 new OracleParameter("UserPwd",UserPwd),
        //                                                 new OracleParameter("UserName",UserName),
        //                                                 new OracleParameter("Sex",Sex),
        //                                                 new OracleParameter("LinkTel",LinkTel),
        //                                                 new OracleParameter("Email",Email),
        //                                                 new OracleParameter("State",State),
        //                                                 new OracleParameter("Describe",Describe),
        //                                                 new OracleParameter("SSQ",SSQ)};
        //        db.RunSqlNonQuery(strSql, sps);
        //        result = "1";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //    finally
        //    {
        //        db.Despose();
        //    }
        //    return result;
        //}


        public static string InsertUser(UserInfo ui)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "insert into UserInfo(UserID,UserCode,UserPwd,UserName,Sex,LinkTel,Email,\"State\",Describe,SSQ)values(@UserID,@UserCode,@UserPwd,@UserName,@Sex,@LinkTel,@Email,@State,@Describe,@SSQ)";

                SqlParameter[] sps = new SqlParameter[] {new SqlParameter("@UserID",ui.UserId),
                                                         new SqlParameter("@UserCode",ui.UserCode),
                                                         new SqlParameter("@UserPwd",ui.UserPwd),
                                                         new SqlParameter("@UserName",ui.UserName),
                                                         new SqlParameter("@Sex",ui.Sex),
                                                         new SqlParameter("@LinkTel",ui.LinkTel),
                                                         new SqlParameter("@Email",ui.Email),
                                                         new SqlParameter("@State",ui.State),
                                                         new SqlParameter("@Describe",ui.Describe),
                                                         new SqlParameter("@SSQ",ui.Ssq)};
                db.RunSqlNonQuery(strSql, sps);
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
        /// 修改用户信息
        /// </summary>
        /// <param name="UserCode">用户编号</param>
        /// <param name="UserPwd">用户密码</param>
        /// <param name="UserName">用户姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="LinkTel">联系电话</param>
        /// <param name="Email">邮箱</param>
        /// <param name="State">状态</param>
        /// <param name="Describe">描述</param>
        /// <param name="LoginIP">登录IP地址</param>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        //public static string UpdateUserByID(string UserCode, string UserPwd, string UserName, string Sex, string LinkTel, string Email, string Describe,string SSQ, string UserID)
        //{
        //    string result = "0";
        //    DBOperate db = new DBOperate("DADB");
        //    try
        //    {
        //        string strSql = "update UserInfo set UserCode=:UserCode,UserName=:UserName,Sex=:Sex,LinkTel=:LinkTel,Email=:Email,Describe=:Describe,SSQ=:SSQ where UserID=:UserID";

        //        OracleParameter[] sps = new OracleParameter[] {new OracleParameter("UserCode",UserCode),
        //                                                 new OracleParameter("UserName",UserName),
        //                                                 new OracleParameter("Sex",Sex),
        //                                                 new OracleParameter("LinkTel",LinkTel),
        //                                                 new OracleParameter("Email",Email),
        //                                                 new OracleParameter("Describe",Describe),
        //                                                 new OracleParameter("SSQ",SSQ),
        //                                                 new OracleParameter("UserID",UserID)};
        //        db.RunSqlNonQuery(strSql, sps);
        //        result = "1";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //    finally
        //    {
        //        db.Despose();
        //    }
        //    return result;
        //}


        public static string UpdateUserByID(UserInfo ui)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                if (string.IsNullOrWhiteSpace(ui.UserPwd))
                {
                    string strSql = "update UserInfo set UserCode=@UserCode,UserName=@UserName,Sex=@Sex,LinkTel=@LinkTel,Email=@Email,Describe=@Describe,SSQ=@SSQ where UserID=@UserID";

                    SqlParameter[] sps = new SqlParameter[] {new SqlParameter("@UserCode",ui.UserCode),
                                                         new SqlParameter("@UserName",ui.UserName),
                                                         new SqlParameter("@Sex",ui.Sex),

                                                         new SqlParameter("@LinkTel",ui.LinkTel),
                                                         new SqlParameter("@Email",ui.Email),
                                                         new SqlParameter("@Describe",ui.Describe),
                                                         new SqlParameter("@SSQ",ui.Ssq),
                                                        
                                                         new SqlParameter("@UserID",ui.UserId)};
                    db.RunSqlNonQuery(strSql, sps);
                    result = "1";
                }
                else
                {


                    string strSql = "update UserInfo set UserCode=@UserCode,UserName=@UserName,Sex=@Sex,LinkTel=@LinkTel,Email=@Email,Describe=@Describe,SSQ=@SSQ,UserPwd=@UserPwd where UserID=@UserID";

                    SqlParameter[] sps = new SqlParameter[] {new SqlParameter("@UserCode",ui.UserCode),
                                                         new SqlParameter("@UserName",ui.UserName),
                                                         new SqlParameter("@Sex",ui.Sex),

                                                         new SqlParameter("@LinkTel",ui.LinkTel),
                                                         new SqlParameter("@Email",ui.Email),
                                                         new SqlParameter("@Describe",ui.Describe),
                                                         new SqlParameter("@SSQ",ui.Ssq),
                                                         new SqlParameter("@UserPwd",ui.UserPwd),
                                                         new SqlParameter("@UserID",ui.UserId)};
                    db.RunSqlNonQuery(strSql, sps);
                    result = "1";
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
            return result;
        }

        /// <summary>
        /// 得到所有现存用户信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllUser()
        {
            DataSet dsAllUser = new DataSet();
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = @"select UserID,UserCode,UserPWD,UserName,UNITID,SEX,LINKTEL,EMAIL,State,DESCRIBE,LOGINIP,
                                case when State='1' then '正常' when State='0' then '停用' end as UserState,SSQ,jb.BR_BranchName as SSQNAME from UserInfo u
                                inner join dbo.JG_Branches jb
                                on u.ssq=jb.BR_BranchCode";
                dsAllUser = db.RunSql(strSql);
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
        /// <summary>
        /// 根据用户编号删除用户信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public static string DeleteUserByID(string UserID)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "delete from UserInfo where UserID=@UserID";
                SqlParameter[] sps = new SqlParameter[] { new SqlParameter("@UserID", UserID) };
                db.RunSqlNonQuery(strSql, sps);
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
        /// 根据用户编号修改用户状态
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        public static string UpdataStateByID(string UserID,string State)
        {
            string result = "0";
            DBOperate db = new DBOperate("DADB");
            try
            {
                string strSql = "Update UserInfo set \"State\"=@State where UserID=@UserID";
                SqlParameter[] sps = new SqlParameter[] { new SqlParameter("@State", State), new SqlParameter("@UserID", UserID) };
                db.RunSqlNonQuery(strSql, sps);
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
        /// 获取所有可用网点
        /// </summary>
        /// <returns></returns>
        public static DataSet GetJG_Branches()
        {
            DataSet ds = null;
            DBOperate db = new DBOperate("DADB");
            string sql = " select BR_BranchCode,BR_BranchName from JG_Branches where BR_State='1' ";
            try
            {
                ds = db.RunSql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Despose();
            }

            return ds;
        }
    }
}
