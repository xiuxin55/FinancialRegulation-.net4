using System;
using System.Text.RegularExpressions;
using FinancialRegulation.Tools;
using Microsoft.Practices.Prism.Commands;

namespace FinancialRegulation.ViewModel
{
    public abstract class BaseEditVM<T> : BaseVM<T> where T : new()
    {
        public BaseEditVM()
        {
            LoadBaseCommand();
        }

        #region 加载命令

        /// <summary>
        /// 加载预制命令
        /// </summary>
        private void LoadBaseCommand()
        {
            OKCommand = new DelegateCommand(OKExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion 加载命令

        #region 命令定义

        private DelegateCommand okCommand;

        /// <summary>
        /// 确认
        /// </summary>
        public DelegateCommand OKCommand
        {
            get { return okCommand; }
            set
            {
                okCommand = value;
                RaisePropertyChanged("OKCommand");
            }
        }

        private DelegateCommand cancelCommand;

        /// <summary>
        /// 取消
        /// </summary>
        public DelegateCommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                RaisePropertyChanged("CancelCommand");
            }
        }

        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 执行添加
        /// </summary>
        public abstract void OKExecute();

        /// <summary>
        /// 执行取消(默认关闭窗体)
        /// </summary>
        public virtual void CancelExecute()
        {
            if (windowClose != null) windowClose();
        }

        #endregion 命令方法

        #region 公开方法

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateData()
        {
            return !(CurrentObj == null);
        }

        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="pattern">表达式</param>
        /// <returns></returns>
        public bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 得到字符串的字符长度，一个汉字的长度为2
        /// </summary>
        /// <param name="psStr">需要得到长度的字符串</param>
        /// <returns>字符串的长度</returns>
        public static int GetStrLen(string psStr)
        {
            return System.Text.UnicodeEncoding.Default.GetByteCount(psStr);
        }

        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件</param>
        public bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }

        #endregion 公开方法

    }
}