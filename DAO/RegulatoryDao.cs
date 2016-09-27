using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;

namespace Dao
{
    public class RegulatoryDao : BaseDao
    {
        public static bool ProtocolSave(JG_SpvProtocol jG_SpvProtocol)
        {
            SqlMap.Insert("InsertSpvProtocol", jG_SpvProtocol);
            return true; 
        }

        /// <summary>
        /// 新增Payment
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool insertPaymentInfo(JG_PaymentInfo p)
        {
            try
            {
                SqlMap.Insert("insertPaymentInfo", p);
                return true;
            }
            catch (Exception e)
            {
                //return false;
                throw e;
            }
        }

        /// <summary>
        /// 插入报文信息
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static bool AddJG_MessageInfo(JG_MessageInfo mi)
        {
            try
            {
                SqlMap.Insert("AddJG_MessageInfo", mi);
                return true;
            }
            catch (Exception e)
            {
                //return false;
                throw e;
            }
        }

        /// <summary>
        /// 协议变更
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static bool ChangeProtocol(JG_SpvProtocol JG_SpvProtocol)
        {
            try
            {
                SqlMap.Update("ChangeProtocol", JG_SpvProtocol);
                return true;
            }
            catch (Exception e)
            {
                //return false;
                throw e;
            }
        }


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <returns></returns>
        public static DataSet DoSqlRetrun(string sqlStr,string UserCode,string UserPwd)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds.Tables.Add(dt);
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("Msg",typeof(string));
                
                if(UserCode.Trim().Length==0)
                {
                    DataRow drCode = dt.NewRow();
                    drCode["Code"] = "01";
                    drCode["Msg"] = "用户名不能为空!";
                    dt.Rows.Add(drCode);
                    return ds;
                }
                if (UserPwd.Trim().Length == 0)
                {
                    DataRow drPwd = dt.NewRow();
                    drPwd["Code"] = "02";
                    drPwd["Msg"] = "密码不能为空!";
                    dt.Rows.Add(drPwd);
                    return ds;
                }
                UserInfo ui = new UserInfo();
                ui.UserPwd = UserPwd;
                ui.UserCode = UserCode;

                List<UserInfo> listUserInfo= new List<UserInfo>(LoginDao.CheckUserInfo(ui));
                if (listUserInfo != null && listUserInfo.Count != 0)
                {
                    ds.Tables.Add(MyBatis.QueryForDataTable("SelectSql", sqlStr).Copy());
                    DataRow drOk = dt.NewRow();
                    drOk["Code"] = "00";
                    drOk["Msg"] = "成功!";
                    dt.Rows.Add(drOk);
                    return ds;
                }
                else
                {
                    DataRow drNull = dt.NewRow();
                    drNull["Code"] = "03";
                    drNull["Msg"] = "用户名密码错误!";
                    dt.Rows.Add(drNull);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                DataRow drError = dt.NewRow();
                drError["Code"] = "04";
                drError["Msg"] = ex.ToString();
                dt.Rows.Add(drError);
                return ds;
            }
        }
    }
}
