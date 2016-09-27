using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using DataBase;

namespace Dao
{   
    public class BaseBiz
    {
        //添加用户信息
        public static string AddUser(string userID,string userCode,string userName,string psw,string userType,string status,string sex,string birthday,string officeTel,string departMent,string email)
        {
            //DBOperate db = new DBOperate("CFDBPOOL");
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"insert into MN_User(UserID,UserCode,UserName,Psw,UserType,Status,Sex,Birthday,OfficeTel,DepartMent,Email) 
                        values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",userID,userCode,userName,psw,userType,status,sex,
                        birthday,officeTel,departMent,email);
            string resule = "1";
            try
            {
                db.RunSqlNonQuery(sql);
            }
            catch (Exception ex)
            {
                resule = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return resule;
        }
        //根据用户编号修改用户信息
        public static string UpdateUser(string userID, string userCode, string userName, string psw, string userType, string status, string sex, string birthday, string officeTel, string departMent, string email)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"update MN_User set UserCode='{0}', UserName='{1}',Psw='{2}', UserType='{3}',status='{4}',sex='{5}',birthday='{6}',
                                         officeTel='{7}',departMent='{8}',email='{9}' where UserID='{10}';",userCode,userName,psw,userType,status,sex,
                                         birthday,officeTel,departMent,email,userID);
            string resule = "1";
            try
            {
                db.RunSqlNonQuery(sql);
            }
            catch (Exception ex)
            {
                resule = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return resule;
            
        }
        //根据用户编号删除用户
        public static string DelUser(string userID)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"delete from MN_User where UserID='{0}';",userID);
            string resule = "1";
            try
            {
                db.RunSqlNonQuery(sql);
            }
            catch (Exception ex)
            {
                resule = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return resule;
            
        }
        /// <summary>
        /// 根据组织编号和组织类别的到相应用户信息

        /// </summary>
        /// <returns></returns>

        public static DataSet GetData()
        {

            DBOperate db = new DBOperate("CFDBPOOL");
            DataSet ds = null;
            try
            {
                string sql = @"SELECT UnitID,ZJM,UnitName FROM MN_Units where unittype='1';
                               select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID where MN_Units.unittype='1';
                               select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID where MN_Units.unittype='2';
                               select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID where MN_Units.unittype='3';
                               select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID where MN_Units.unittype='4';
                               select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent,UnitName from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID;";

                ds = db.RunSql(sql);
                ds.Tables[0].TableName = "Court";//法院列表
                ds.Tables[1].TableName = "CourtUser";//法院用户
                ds.Tables[2].TableName = "ArchieveUser";//档案馆用户

                ds.Tables[3].TableName = "CodeUser";//法规科用户

                ds.Tables[4].TableName = "InfoUser";//信息中心用户
                ds.Tables[5].TableName = "AllUser";//系统所有用户                
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
        /// 得到组织和模块信息

        /// </summary>
        /// <returns></returns>
        public static DataSet GetUnitAndModel()
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            DataSet ds = null;
            string sql = @"SELECT UnitID,ZJM,UnitName FROM MN_Units;
                               select ModelID,ModelName from MN_Model;
                               select MN_ModelEx.ModelID,ModelExID,ModelExName from MN_ModelEx inner join MN_Model on MN_ModelEx.ModelID=MN_Model.ModelID;
                               select MN_Business.ModelExID,ScreenID,ScreenName from MN_Business inner join MN_ModelEx on MN_ModelEx.ModelExID = MN_Business.ModelExID;";
            try
            {
                ds = db.RunSql(sql);
                ds.Tables[1].TableName = "Model";//模块信息
                ds.Tables[2].TableName = "ModelEx";//子模块信息

                ds.Tables[3].TableName = "Business";//窗体信息
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
        //根据条件得到用户列表
        public static DataSet GetUserListByReq(string unitID,string userCode,string userName)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = @"select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent,UnitName from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID";
            if (unitID != "")
            {
                sql += string.Format(" and DepartMent='{0}'",unitID);
            }
            else if (userCode != "")
            {
                sql += string.Format(" and UserCode='{0}'",userCode);
            }
            else if (userName != "")
            {
                sql += string.Format(" and UserName='{0}'",userName);
            }
            DataSet ds = null;
            try
            {
                ds = db.RunSql(sql);

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
        /// 根据条件得到用户列表
        /// </summary>
        /// <param name="condation">条件字符串</param>
        /// <returns></returns>
        public static DataSet GetUserListByCondation(string condation)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = @"select UserID,UserCode,UserName,Sex,OfficeTel,Email,case when Status='1' then '正常'
	                           when Status='0' then '停用' else null end Status,Birthday,DepartMent,UnitName from MN_User inner join MN_Units on MN_User.DepartMent = MN_Units.UnitID where 0=0 ";
            if (condation != null || condation != "")
            {
                sql += condation;
            }
            DataSet ds = null;
            try
            {
                ds = db.RunSql(sql);

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
        /// 添加法院信息
        /// </summary>
        /// <param name="unitID">法院编号</param>
        /// <param name="zjm">助记码</param>
        /// <param name="unitName">法院名称</param>
        /// <returns></returns>
        public static string AddCurt(string unitID, string zjm, string unitName)
        {
            string result = "1";
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"insert into MN_Units(UnitID,UnitType,ZJM,UnitName) values('{0}','1','{1}','{2}');",unitID,zjm,unitName);
            try
            {
                db.RunSqlNonQuery(sql);

            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
        /// <summary>
        /// 根据单位编号删除单位信息
        /// </summary>
        /// <param name="unitID">单位编号</param>
        /// <returns></returns>
        public static string DelUnit(string unitID)
        {
            string result = "1";
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"delete from MN_Units where UnitID='{0}';",unitID);
            //DataSet ds = null;
            try
            {
                db.RunSqlNonQuery(sql);
            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result;
        }
        //根据条件添加授权
        public static string AddBusiness(string userID, string screenID)
        {
            string result = "1";
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"insert into MN_UserBusiness(UserID,ScreenID) values('{0}','{2}');",userID,screenID);
            try
            {
                db.RunSqlNonQuery(sql);

            }
            catch (Exception ex)
            {
                result = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return result; 
        }
        //根据用户编号删除所有用户授权

        public static string DelAllBusinessbyUserID(string userID)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"delete from MN_UserBusiness where UserID='{0}';",userID);
            string resule = "1";
            try
            {
                db.RunSqlNonQuery(sql);
            }
            catch (Exception ex)
            {
                resule = "0";
                throw new Exception(ex.ToString());
            }
            finally
            {
                db.Despose();
            }
            return resule;
        }

        /// <summary>
        /// 取得用户的功能列表

        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetUserBusiness(string userID)
        {
            DBOperate db = new DBOperate("CFDBPOOL");
            string sql = string.Format(@"select UserID,ScreenID from MN_UserBusiness where UserID='{0}';",userID);
            DataSet ds = null;
            try
            {
                ds = db.RunSql(sql);

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
        /// 给用户授权

        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string SetUserBusiness(DataSet ds)
        {
            string result = "1";
            DBOperate db = new DBOperate("CFDBPOOL");

            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("DELETE MN_UserBusiness WHERE UserID='{0}';",ds.Tables[0].Rows[0]["UserID"]));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sql.Append(string.Format("INSERT INTO MN_UserBusiness(UserID,ScreenID) VALUES('{0}','{1}');", dr["UserID"], dr["ScreenID"]));
            }
            try
            {
                db.RunSqlNonQuery(sql.ToString());

            }
            catch (Exception ex)
            {
                result = "0";
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
