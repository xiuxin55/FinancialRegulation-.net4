using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.ClientException;

namespace FinancialRegulation.Base.Check
{
    /// <summary>
    /// 检查输入帮助
    /// 此方法配合CheckException是所有检测正确不显示问题
    /// 如果发现错误会跑出CheckExcepiton异常
    /// </summary>
    public class CheckHelp
    {
        private static CheckHelp _CurrentInstance = null;
        /// <summary>
        /// 获取对象
        /// </summary>
        public static CheckHelp Current
        {
            get
            {
                if (_CurrentInstance == null)
                {
                    _CurrentInstance = new CheckHelp();
                }
                return _CurrentInstance;
            }
        }
        /// <summary>
        /// 非空检查
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="label">标签</param>
        public void NotNullCheck(string input, string label)
        {
            CustomerCheck(input, label + "内容不能为空", (i) => !string.IsNullOrEmpty(i));
        }
        /// <summary>
        /// 非空检查
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="label">标签</param>
        public void NotNullCheck(object input, string label)
        {
            if (input == null) throw new CheckException(label + "内容不能为空");
        }
        /// <summary>
        /// 字符串长度验证 内部验证非空 这个长度写的真是垃圾
        /// </summary>
        /// <param name="input">验证字段</param>
        /// <param name="label">标记</param>
        /// <param name="Max">最大长度</param>
        /// <param name="Min">最小长度</param>
        public void StrLengthCheck(string input, string label, int Max, int Min = 0)
        {
            NotNullCheck(input, label);
            CustomerCheck(input, label += "长度不正确", (i) => !(System.Text.UnicodeEncoding.Default.GetByteCount(i) > Max || System.Text.UnicodeEncoding.Default.GetByteCount(i) < Min));
        }
        /// <summary>
        /// 正则表达式验证 内部验证非空
        /// </summary>
        /// <param name="field">验证字段</param>
        /// <param name="label">提示字符串</param>
        /// <param name="pattern">最小长度</param>
        public void RegexCheck(string input, string label, string pattern)
        {
            NotNullCheck(input, label);
            CustomerCheck(input, label + "输入不正确", (i) => System.Text.RegularExpressions.Regex.IsMatch(input, pattern));
        }
        /// <summary>
        /// 用户自定义验证
        /// </summary>
        /// <typeparam name="T">输入类型</typeparam>
        /// <param name="input">输入</param>
        /// <param name="label">标签</param>
        /// <param name="CheckMethod">验证方法</param>
        public void CustomerCheck<T>(T input, string label, Func<T, bool> CheckMethod)
        {
            NotNullCheck(input, label);
            if (!CheckMethod(input))
            {
                throw new CheckException(label);
            }
        }
        /// <summary>
        /// 用户自定义验证
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="label">标签</param>
        /// <param name="CheckMethod">验证方法</param>
        public void CustomerCheck(string input, string label, Func<string, bool> CheckMethod)
        {
            if (!CheckMethod(input)) throw new CheckException(label);
        }
        /// <summary>
        /// 数值非零验证
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="label">标签</param>
        public void NotZero(int input, string label)
        {
            CustomerCheck<int>(input, label + "不能小于1", (i) => i > 0);
        }
    }
}
