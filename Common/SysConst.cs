using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text .RegularExpressions ;
using System.IO;


namespace Common
{
    /// <summary>
    ///  窗体操作类型枚举
    /// </summary>
    public enum OpreatType
    {
        VIEW = 1,
        CREATE,
        MODIFY,
        DELETE,
        EXTRACTION
    }
    
    /// <summary>
    /// 系统常量
    /// </summary>
    public class SysConst
    {
        
        //档案流程时间格式
        public static readonly string PROCESSDATEFORMATE="yyyy-MM-dd HH:mm:ss";
        //业务流程时间格式
        public static readonly string BUSINESSTIMEFORMATE = "yyyy-MM-dd HH:mm:ss";
        //业务流程日期格式
        public static readonly string BUSINESSDATEFORMATE = "yyyy-MM-dd";


        //服务端询问消息 确认客户端是否在线
        public static readonly string QUERYMSG = "ARE YOU ON LINE?";

        
        #region 常用正则表示式

        //身份证正则表达式(15位) 
        public static readonly string IDCardNO15=@"/^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/"; 
        //身份证正则表达式(18位) 
        public static readonly string IDCardNO18=@"/^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$/";

        public static readonly Regex RegexID15 = new Regex("^[1-9]\\d{7}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}$");
        //public static readonly Regex RegexID18 = new Regex("^[1-9]\\d{5}[1-9]\\d{3}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{4}$");
        public static readonly Regex RegexID18 = new Regex("^[1-9][0-9]{5}(19[0-9]{2}|200[0-9]|2010)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$");
        // 转档清单
        public static readonly Regex ZDQD = new Regex("^([A-Z]|[a-z]|[0-9]){2,8}[1-2]{1}[0-9]{3}[0-1]{1}[0-9]{1}[0-3]{1}[0-9]{1}[0-9]{4}$");

        //public static readonly Regex YWZH = new Regex("^[1-2]{1}[0-9]{3}[0-1]{1}[0-9]{1}[0-3]{1}[0-9]{1}[0-9]{4}$");
        public static readonly Regex YWZH = new Regex("^([1-2]{1}[0-9]{3})(([0-1]{1}[0-9]{1}[0-3]{1}[0-9]{1}[0-9]{4})|([0-9]{3}[0-9]{6}[0-9]{0,2}))$");
        /// <summary>
        /// 身份证号码格式验证
        /// </summary>
        /// <param name="cardno">身份证号码</param>
        /// <returns></returns>
        public bool PersonCard(string cardno)
        {
            bool isok = false ;
            Regex personcardno=new Regex ("\\d{15}|\\d{18}");
            if (personcardno .IsMatch (cardno ))
            {
                isok = true;
            }

            return isok;
        }



        /// <summary>
        /// 身份证号码格式验证
        /// </summary>马祥帅添加2012-11-19
        /// <param name="cardno">身份证号码</param>
        /// <returns></returns>
        public bool PersonCardLenthCheck(string cardno)
        {
            bool isok = false;
            Regex personcardno = new Regex(@"^\d{15}$|^\d{18}$");
            if (personcardno.IsMatch(cardno))
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 固定电话号码格式验证
        /// </summary>
        /// <param name="phoneno">电话号码</param>
        /// <returns></returns>
        public bool TeltePhone(string phoneno)
        {
            bool isok = false;
            Regex Telephone = new Regex("\\d{3}-\\d{8}|\\d{4}-\\d{7}");
            if (Telephone .IsMatch (phoneno))
            {
                isok = true;               
            }
            return isok;
        }
       /// <summary>
       /// 手机号码格式验证
       /// </summary>
       /// <param name="inputno"></param>
       /// <returns></returns>
        public bool Phonenumber(string inputno)
        {
              bool isok = false;
              Regex phonenumberno = new Regex("@^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\\d{8}$");
              if (phonenumberno.IsMatch(inputno))
              {
                  isok = true;
              }
            return isok;
        }


        /// <summary>
        /// IP地址格式验证
        /// </summary>
        /// <param name="ipno"></param>
        /// <returns></returns>
        public bool ComputerIp(string ipno)
        {
            bool isok = false;
            Regex computeripno = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+");
            if (computeripno.IsMatch(ipno))
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 数字字母组合格式验证
        /// </summary>
        /// <param name="inputstr">要验证的字符串</param>
        /// <returns></returns>
        public bool Alphanumeric(string inputstr)
        {
            bool isok = false;
            Regex alphanumericno = new Regex("^[A-Za-z0-9]+$");
            if (alphanumericno.IsMatch(inputstr))
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 字母格式验证
        /// </summary>
        /// <param name="inputstr">要验证的字符串</param>
        /// <returns></returns>
        public bool Alphabet(string inputstr)
        {
            bool isok = false;
            Regex Alphabetno = new Regex("^[A-Za-z]+$");
            if (Alphabetno.IsMatch(inputstr))
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 正浮点数格式验证
        /// </summary>
        /// <param name="inputnum">要验证的字符串</param>
        /// <returns></returns>
        public static bool AreFloatingpoint(string inputnum)
        {
            bool isok = false;
            Regex arefloatingpointno = new Regex("^[1-9]\\d*\\.\\d*|0\\.\\d*[1-9]\\d*$");
            if (arefloatingpointno.IsMatch(inputnum))
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 整数格式验证
        /// </summary>
        /// <param name="inputnum">要验证的字符串</param>
        /// <returns></returns>
        public static bool InterNum(string inputnum)
        {
            bool isok = false;
            Regex InterNumno = new Regex("^[1-9]\\d*$");
            if (InterNumno.IsMatch(inputnum))
            {
                isok = true;
            }

            return isok;
 
        }

        /// <summary>
        /// 邮政编码格式验证
        /// </summary>
        /// <param name="inputstr">邮政编码号码</param>
        /// <returns></returns>
        public bool PostalCoding(string inputstr)
        {
            bool isok = false;
            Regex postalcodingdno = new Regex("[1-9]\\d{5}(?!\\d)");
            if (postalcodingdno.IsMatch(inputstr))
            {
                isok = true;
            }
            return isok;
        }

        /// <summary>
        /// email地址格式验证
        /// </summary>
        /// <param name="inputno">email号码</param>
        /// <returns></returns>
        public bool Emailadress(string inputno)
        {

            bool isok = false;
            Regex Emailadressno = new Regex("^[/w-]+(/.[/w-]+)*@[/w-]+(/.[/w-]+)+$");
            if (Emailadressno.IsMatch(inputno))
            {
                isok = true;
            }
            return isok;
        }

        /// <summary>
        /// 年_月_日格式验证
        /// </summary>
        /// <param name="inputtime">日期字符串</param>
        /// <returns></returns>
        public bool Yearmonthday(string inputtime)
        {
            bool isok = false;
            Regex yearmonthdayno = new Regex("/^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$");
            if (yearmonthdayno.IsMatch(inputtime))
            {
                isok = true;
            }
            return isok;
        }

        /// <summary>
        /// 月/日/年/格式验证
        /// </summary>
        /// <param name="inputtime">日期字符串</param>
        /// <returns></returns>
        public bool Monthdayyear(string inputtime)
        {
            bool isok = false;
            Regex monthdayyearno = new Regex("/^((0([1-9]{1}))|(1[1|2]))/(([0-2]([1-9]{1}))|(3[0|1]))/(d{2}|d{4})$");
            if (monthdayyearno.IsMatch(inputtime))
            {
                isok = true;
            }
            return isok;
 
        }

        /// <summary>
        /// 字符串是否为纯数字
        /// </summary>
        /// <param name="inputno">要验证的字符串</param>
        /// <returns></returns>
        public bool Purenumber(string inputno)
        {
             bool isok = false;
             Regex purenumberno = new Regex("/^\\d+$/");
             if (purenumberno.IsMatch(inputno))
            {
                isok = true;
            }
            return isok;

        }

        #endregion

        #region 保障房系统字典内容
        public static readonly string HSIS_BUSINESSTIMEFORMATE = "yyyy-MM-dd HH:mm:ss";
        public static readonly string HSIS_SQLB = "00";
        public static readonly string HSIS_XZFXZ = "01";
        public static readonly string HSIS_TSJT = "02";
        public static readonly string HSIS_TSJT_LZ = "03";
        public static readonly string HSIS_XZQ = "04";
        public static readonly string HSIS_JDBSC = "05";
        public static readonly string HSIS_SQJWH = "06";
        public static readonly string HSIS_HYZT = "07";
        //学历
        public static readonly string HSIS_XL = "08";

        public static readonly string HSIS_FYLX = "09";
        public static readonly string HSIS_YHLX = "10";
        public static readonly string HSIS_ZT = "11";
        public static readonly string HSIS_DALC = "14";



        #region 各合同出租人名称、账号、账户名称
        //廉租
        public static readonly string LZFJF = "";
        public static readonly string LZFZHMC = "";
        public static readonly string LZFZH = "";

        //公租
        public static readonly string GZFJF = "";
        public static readonly string GZZHMC = "";
        public static readonly string GZZH = "";
        
        #endregion 

        #endregion


        #region 支付类别

        public static readonly string ZFLB_ZD = "0";     //重点
        public static readonly string ZFLB_FZD = "1";    //1非重点
        public static readonly string ZFLB_LX = "2";     //2利息
        public static readonly string ZFLB_KK = "3";     //3扣款
        public static readonly string ZFLB_TZ = "4";     //3调账

        #endregion


        #region 支付类型

        public static readonly string ZFLX_ZF = "0";     //支付
        public static readonly string ZFLX_KK = "1";    //1扣款
        public static readonly string ZFLX_TZ = "2";     //2调账

        #endregion
    }
}
