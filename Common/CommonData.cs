using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using System.Collections.Specialized;
using System.Xml;


namespace Common
{
    public class CommonData
    {
        private static CommonData mCommonData;//系统共享对象
        private string mDbConnStr;//数据库连接串产权
        private string daCqDbConnStr;//数据库连接串产权
        private string daDbConnStr;//档案库连接串
        private string daOldDbConnStr;//老产权库连接串
        private string doc_UpDownSeverAddress; //上传下载文档服务器地址
        private string video_UpDownSeverAddress; //上传下载文档服务器地址
        private string upDownSeverAddress;
        private string ScanDbConnStr; //扫描数据库
        private string BADbConnStr;//备案数据库
        private string mWebReferenceUrl;//Web服务引用地址
        private Dictionary<string, string> webReferenceUrlList;//Web服务引用地址列表
        private Dictionary<string, string> dbConnStrs;//数据库连接字符串列表
        private int mClientMachineFormCount;//末端最多显示窗体数
        private CookieContainer mCookieContainer;//共享容器
        private string mCurrentDir;
        private string mWebLogPath;
        private Hashtable commonData;
        public Dictionary<string, DBConnectionPool> DBPOOLS;
        private Dictionary<string, string> UsersToken;
        private string webReference;
        private string updateWebReference;

        private object customerinfo;

        public object CustomerInfo
        {
            get { return customerinfo; }
            set { customerinfo = value; }
        }

        private object userinfo;

        public object UserInfo
        {
            get { return userinfo; }
            set { userinfo = value; }
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        private object listCheckUesrInfo;

        public object ListCheckUesrInfo
        {
            get { return listCheckUesrInfo; }
            set
            {
                listCheckUesrInfo = value;
            }
        }

        private object _sysConfig;
        /// <summary>
        /// 银行端配置
        /// </summary>
        public object SysConfig
        {
            get { return _sysConfig; }
            set { _sysConfig = value; }
        }



        public void SetUserToken(string userid, string token)
        {
            UsersToken.Remove(userid);
            UsersToken.Add(userid, token);
        }

        public void RemoveUserToken(string userid)
        {
            UsersToken.Remove(userid);
        }

        public string DocUpDownSeverAddressDoc
        {
            get { return webReference+"/Document"; }
            //set { doc_UpDownSeverAddress = value; }
        }

        public string Video_UpDownSeverAddress
        {
            get { return webReference+"/"; }
            //set { video_UpDownSeverAddress = value; }
        }

        public string Tool_UpDownSeverAddress
        {
            get { return webReference+"/Tools"; }
            //set { video_UpDownSeverAddress = value; }
        }

        public string UpDownSeverAddress
        {
            get { return webReference + "/"; }
            //set { upDownSeverAddress = value; }
        }

        public string UpdateSeverAddress
        {
            get { return updateWebReference; }
            //set { upDownSeverAddress = value; }
        }
        public bool CheckUserToken(string usertoken)
        {
            if (usertoken.Length < 72)
            {
                return false;
            }
            string userid = usertoken.Substring(36, 36);
            string token = usertoken.Substring(0, 36);
            if (!UsersToken.ContainsKey(userid))
            {
                return false;
            }
            return UsersToken[userid].Equals(token);
        }


        //本地图片保存目录
        public string LocalImagePath = "";

        private string myToken;

        public string MyToken
        {
            get { return myToken+LoginUserID; }
            set { myToken = value; }
        }
        #region 查询
        /// <summary>
        /// SqlConfig缓存
        /// </summary>
        private XmlDocument xmldot;

        public XmlDocument Xmldot
        {
            get { return xmldot; }
        }

        #endregion

        // 档案接收流水号
        private static int SerialNo = 0;
        //最后取档案接收流水号得时间
        private static DateTime snlastTime = DateTime.MinValue;
        // 取档案接收流水号的同步锁
        private static object snlok = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetSerialNo(DateTime time)
        {
            lock (snlok)
            {
                if (snlastTime != DateTime.MinValue && time.Day > snlastTime.Day)
                {
                    SerialNo = 0;
                }
                snlastTime = time;
                SerialNo++;
            }
            return SerialNo;
        }


        // 转档清单流水号
        private static int ListNumber = 0;
        //最后取转档清单流水号得时间
        private static DateTime lnlastTime = DateTime.MinValue;
        // 取转档清单流水号的同步锁
        private static object lnlok = new object();
        public static int GetListNumber(DateTime time)
        {
            lock (lnlok)
            {
                if (lnlastTime != DateTime.MinValue && time.Day > lnlastTime.Day)
                {
                    ListNumber = 0;
                }
                lnlastTime = time;
                ListNumber++;
            }
            return ListNumber;
        }


        // 查询利用流水号
        private static int BusiCode = 0;
        //最后取查询利用流水号得时间
        private static DateTime bclastTime = DateTime.MinValue;
        // 取查询利用流水号的同步锁
        private static object bclok = new object();

        public static int GetBusiCode(DateTime time)
        {
            lock (bclok)
            {
                if (bclastTime != DateTime.MinValue && time.Day > bclastTime.Day)
                {
                    BusiCode = 0;
                }
                bclastTime = time;
                BusiCode++;
            }
            return BusiCode;
        }

        private static int ContractCode = 0;
        private static object contractcodelok = new object();

        public static string GetContractCode(DateTime time)
        {
            lock (contractcodelok)
            {
                if (bclastTime != DateTime.MinValue && time.Day > bclastTime.Day)
                {
                    ContractCode = 0;
                }
                bclastTime = time;
                ContractCode++;
            }
            return time.ToString("yyyyMMdd") + ContractCode.ToString().PadLeft(5, '0');
        }

        public static int GetBusiCode()
        {
            return BusiCode;
        }

        public static void SetlshNo(DataSet ds)
        {
            lock (contractcodelok)
            {
                ContractCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Substring(8));
            }
        }

        private string uploadPath;

        public string UpLoadPath
        {
            get { return uploadPath; }
            set { uploadPath = value; }
        }
        

        private string conpath;

        public string ConfigPath
        {
            set
            {
                this.conpath = value;
            }
            get
            {
                return conpath;
            }
        }

        private Dictionary<string, string> Sqls;

        public String GetSql(string sqlNo)
        {
            if (Sqls.ContainsKey(sqlNo))
            {
                return Sqls[sqlNo];
            }
            else
            {
                string sql = DefineFileReadWrite.GetConfigSql(sqlNo);
                if (sql != null)
                {
                    Sqls.Add(sqlNo, sql);
                }
                return sql;
            }
        }

        public void SetSql(string sqlNo, string Sql)
        {
            if (Sqls.ContainsKey(sqlNo))
            {
                Sqls.Remove(sqlNo);
            }
            Sqls.Add(sqlNo, Sql);
        }

        public void InitSqls()
        {
            Sqls.Clear();
        }

        public static CommonData Instance 
        {
            get
            {
                if (mCommonData == null)
                {
                    mCommonData = new CommonData();

                }
                return mCommonData; 
            }
        }

        /// <summary>
        /// 载体实例取得
        /// </summary>
        /// <returns></returns>
        public static CommonData GetInstance()
        {
            if (mCommonData == null)
            {
                mCommonData = new CommonData();

            }
            return mCommonData;
        }

        /// <summary>
        /// 构造函数


        /// </summary>
        private CommonData()
        {
            //this.mCurrentDir = System.IO.Directory.GetCurrentDirectory(); AppDomain.CurrentDomain.BaseDirectory;
            this.mCurrentDir = AppDomain.CurrentDomain.BaseDirectory;
            //this.mWebReferenceUrl = "http://localhost/HSSQSTSrv"; 
            webReferenceUrlList = new Dictionary<string, string>();
            dbConnStrs = new Dictionary<string, string>();
            mCookieContainer = new CookieContainer();
            commonData = Hashtable.Synchronized(new Hashtable());
            DBPOOLS = new Dictionary<string, DBConnectionPool>();
            Sqls = new Dictionary<string, string>();
            xmldot = new XmlDocument();
            UsersToken = new Dictionary<string, string>();
            webReference = DefineFileReadWrite.GetConfigValue("WebReference");
            updateWebReference = DefineFileReadWrite.GetConfigValue("UpdateWebReference");
        }
        public void SetxmlDot()
        {
            
        }

        /// <summary>
        /// 数据库连接串的设置
        /// </summary>
        /// <param name="mDbConnStr">数据库连接串</param>
        public void SetDbConnStr(string mDbConnStr)
        {
            this.mDbConnStr = mDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的取得
        /// </summary>
        /// <returns>数据库连接串</returns>
        public string GetDbConnStr()
        {
            return this.mDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的设置

        /// </summary>
        /// <param name="mDbConnStr">数据库连接串</param>
        public void SetDaDbConnStr(string mDbConnStr)
        {
            this.daDbConnStr = mDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的取得

        /// </summary>
        /// <returns>数据库连接串</returns>
        public string GetDaDbConnStr()
        {
            return this.daDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的设置

        /// </summary>
        /// <param name="mDbConnStr">数据库连接串</param>
        public void SetCqDbConnStr(string mDbConnStr)
        {
            this.daCqDbConnStr = mDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的取得

        /// </summary>
        /// <returns>数据库连接串</returns>
        public string GetCqDbConnStr()
        {
            return this.daCqDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的设置

        /// </summary>
        /// <param name="mDbConnStr">数据库连接串</param>
        public void SetOldDaDbConnStr(string mDbConnStr)
        {
            this.daOldDbConnStr = mDbConnStr;
        }

        /// <summary>
        /// 数据库连接串的取得

        /// </summary>
        /// <returns>数据库连接串</returns>
        public string GetOldDaDbConnStr()
        {
            return this.daOldDbConnStr;
        }

        public void SetScanDbConnStr(string mDbConnStr)
        {
            this.ScanDbConnStr = mDbConnStr;
        }

        public string GetScanDbConnStr()
        {
            return this.ScanDbConnStr;
        }

        /// <summary>
        /// 备案数据库

        /// </summary>
        /// <param name="mDbConnStr"></param>
        public void SetBADbConnStr(string mDbConnStr)
        {
            this.BADbConnStr = mDbConnStr;
        }
        /// <summary>
        /// 备案数据库
        /// </summary>
        /// <returns></returns>
        public string GetBADbConnStr()
        {
            return this.BADbConnStr;
        }

        public string GetDBConnStr(string connName)
        {
            return this.dbConnStrs[connName];
        }

        public void SetDBConnStr(string connName, string connStr)
        {
            this.dbConnStrs.Add(connName, connStr);
        }

        /// <summary>
        /// Web引用地址
        /// </summary>
        /// <param name="mWebReferenceUrl">Web引用地址</param>
        public void SetWebReferenceUrl(string mWebReferenceUrl)
        {
            if (mWebReferenceUrl != null)
                this.mWebReferenceUrl = mWebReferenceUrl;
        }

        /// <summary>
        /// Web引用地址
        /// </summary>
        /// <returns>Web引用地址</returns>
        public string GetWebReferenceUrl()
        {
            if (this.mWebReferenceUrl==null)
            {
                this.mWebReferenceUrl = DefineFileReadWrite.GetConfigValue("WebReference");
            }
            return this.mWebReferenceUrl;
        }

        /// <summary>
        /// Web引用地址
        /// </summary>
        /// <param name="mWebReferenceUrl">Web引用地址</param>
        public void SetWebReferenceUrl(string key,string webReferenceUrl)
        {
            if (webReferenceUrl != null)
            {
                webReferenceUrlList.Remove(key);
                this.webReferenceUrlList.Add(key, webReferenceUrl);
            }
        }

        /// <summary>
        /// Web引用地址
        /// </summary>
        /// <returns>Web引用地址</returns>
        public string GetWebReferenceUrl(string key)
        {
            if (!webReferenceUrlList.ContainsKey(key) || (webReferenceUrlList[key] == ""))
            {
                this.SetWebReferenceUrl(key, DefineFileReadWrite.GetConfigValue(key));
            }
            return this.webReferenceUrlList[key];
        }

        /// <summary>
        /// 同时显示窗体个数
        /// </summary>
        /// <param name="mClientMachineFormCount">同时显示窗体个数</param>
        public void SetClientMachineFormCount(int mClientMachineFormCount)
        {
            this.mClientMachineFormCount = mClientMachineFormCount;
        }

        /// <summary>
        /// 同时显示窗体个数
        /// </summary>
        /// <returns>同时显示窗体个数</returns>
        public int GetClientMachineFormCount()
        {
            return this.mClientMachineFormCount;
        }

        /// <summary>
        /// session容器
        /// </summary>
        /// <returns>session容器</returns>
        public CookieContainer getCookieContainer()
        {
            return this.mCookieContainer;
        }

        /// <summary>
        /// CurrentDir
        /// </summary>
        /// <returns>CurrentDir</returns>
        public string getCurrentDir()
        {
            return this.mCurrentDir;
        }

        public void setValue(object key, object value)
        {
            this.commonData.Add(key, value);
        }

        public object getValue(object key)
        {
            return this.commonData[key];
        }

        public void removeValue(object key)
        {
            this.commonData.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spath"></param>
        public void SetWebLogPath(string spath)
        {
            this.mWebLogPath = spath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getWebLogPath()
        {
            return this.mWebLogPath;
        }

        public string returnip()
        {
            //IPHostEntry myHost = new IPHostEntry();
            //myHost = Dns.GetHostByName(Dns.GetHostName());
            //string ip = myHost.AddressList[0].ToString();
            //return ip;
            return "127.0.0.1";
        }

        #region container4net

        private string mConfigFile = "ClientConfig.xml";
        //private string mDbConnStr2;
        //private string mDbConnStr3;
        //private string mDbConnStr4;
        //private string mDbConnStr5;
        private string mLoginUserID;
        private string dalb;    //档案类别
        private string mssq;   //所属区
        private string mLoginUserCode;
        private string mLoginUserName = null;
        private string mLoginUserUnit = "0258";
        private string mUnitName = null;
        private string mUserType = null;
        private string mCropID_jm = null;
        private string mUserID_jm = null;
        private string mTel = null;
        private int mLogOutLevel = 0x63;
        private string mLogPath;
        private string mMessageFile = "Net4Message.xml";
        private DataTable mModelDt = null;
        private DataTable mModelExDt = null;
        private DataTable mUserBusinessDt = null;
        private Hashtable objTb = null;
        private StringDictionary strTb;


        public DataTable GetValueDt(string key)
        {
            if (this.objTb == null)
            {
                return null;
            }
            return (DataTable)this.objTb[key];
        }

        public int GetValueInt(string key)
        {
            if (this.strTb == null)
            {
                return 0;
            }
            string str = this.strTb[key];
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }

        public object GetValueObj(string key)
        {
            if (this.objTb == null)
            {
                return null;
            }
            return this.objTb[key];
        }

        public string GetValueStr(string key)
        {
            if (this.strTb == null)
            {
                return null;
            }
            return this.strTb[key];
        }

        public void SetValueDt(string key, DataTable value)
        {
            if (this.objTb == null)
            {
                this.objTb = new Hashtable();
            }
            this.objTb[key] = value;
        }

        public void SetValueDt(string key, object value)
        {
            if (this.objTb == null)
            {
                this.objTb = new Hashtable();
            }
            this.objTb[key] = value;
        }

        public void SetValueInt(string key, int value)
        {
            if (this.strTb == null)
            {
                this.strTb = new StringDictionary();
            }
            this.strTb[key] = value.ToString();
        }

        public void SetValueStr(string key, string value)
        {
            if (this.strTb == null)
            {
                this.strTb = new StringDictionary();
            }
            this.strTb[key] = value;
        }

        // Properties
        public string ConfigFile
        {
            get
            {
                return this.mConfigFile;
            }
            set
            {
                this.mConfigFile = value;
            }
        }

        public CookieContainer CookieContainer
        {
            get
            {
                return this.mCookieContainer;
            }
        }

        public string CurrentDir
        {
            get
            {
                return this.mCurrentDir;
            }
            set
            {
                this.mCurrentDir = value;
            }
        }

        public string DbConnStr
        {
            get
            {
                return this.mDbConnStr;
            }
            set
            {
                this.mDbConnStr = value;
            }
        }


        public string LoginUserID
        {
            get
            {
                return this.mLoginUserID;
            }
            set
            {
                this.mLoginUserID = value;
            }
        }


        public string SSQ
        {
            get
            {
                return this.mssq;
            }
            set
            {
                this.mssq = value;
            }
        }

        public string DALB
        {
            get
            {
                return this.dalb;
            }
            set
            {
                this.dalb = value;
            }
        }

        public string LoginUserCode
        {
            get
            {
                return this.mLoginUserCode;
            }
            set
            {
                this.mLoginUserCode = value;
            }
        }

        public string LoginUserName
        {
            get
            {
                return this.mLoginUserName;
            }
            set
            {
                this.mLoginUserName = value;
            }
        }

        public string LoginUserUnit
        {
            get
            {
                return this.mLoginUserUnit;
            }
            set
            {
                this.mLoginUserUnit = value;
            }
        }

        public string CropID_JM
        {
            get { return mCropID_jm; }
            set { mCropID_jm = value; }
        }

        public string UserID_JM
        {
            get { return mUserID_jm; }
            set { mUserID_jm = value; }
        }
        public string UniteName
        {
            get
            {
                return this.mUnitName;
            }
            set
            {
                this.mUnitName = value;
            }
        }
        public string Tel
        {
            get
            {
                return this.mTel;
            }
            set
            {
                this.mTel = value;
            }
        }

        public string UserType
        {
            get
            {
                return this.mUserType;
            }
            set
            {
                this.mUserType = value;
            }
        }

        public int LogOutLevel
        {
            get
            {
                return this.mLogOutLevel;
            }
            set
            {
                this.mLogOutLevel = value;
            }
        }

        public string LogPath
        {
            get
            {
                return this.mLogPath;
            }
            set
            {
                this.mLogPath = value;
            }
        }

        public string MessageFile
        {
            get
            {
                return this.mMessageFile;
            }
            set
            {
                this.mMessageFile = value;
            }
        }

        public DataTable ModelDt
        {
            get
            {
                return this.mModelDt;
            }
            set
            {
                this.mModelDt = value;
            }
        }

        public DataTable ModelExDt
        {
            get
            {
                return this.mModelExDt;
            }
            set
            {
                this.mModelExDt = value;
            }
        }

        public DataTable UserBusinessDt
        {
            get
            {
                return this.mUserBusinessDt;
            }
            set
            {
                this.mUserBusinessDt = value;
            }
        }

        public string WebReferenceUrl
        {
            get
            {
                return this.mWebReferenceUrl;
            }
            set
            {
                this.mWebReferenceUrl = value;
            }
        }

        #endregion
    }
}
