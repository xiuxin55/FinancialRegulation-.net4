using System;
using System.Text.RegularExpressions;
using FinancialRegulation.ClientException;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.Base.Check;

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
            OKCommand = new DelegateCommand(OKExecuteHost);
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
        /// 执行OK载体 2013年10月28日11:44:58  与命令相连接做捕获异常用
        /// </summary>
        public virtual void OKExecuteHost()
        {
            try
            {
                OKExecute();
            }
            catch (CheckException ex)
            {
                VMHelp.ShowMessage(ex.Message, false);
            }
            catch (Exception ex)
            {
                SendExcetpion(ex);
            }
        }

        /// <summary>
        /// 执行OK方法
        /// </summary>
        public abstract void OKExecute();

        /// <summary>
        /// 执行取消(默认关闭窗体)
        /// </summary>
        public virtual void CancelExecute()
        {
            if (windowClose != null) windowClose();
        }
        /// <summary>
        /// 此方法仅用于OKCommand命令 用于检查
        /// 此方法直接 CheckException 错误对象 在方法最后返回正确 此方法配合CheckHelp使用 
        /// </summary>
        /// <returns></returns>
        public virtual bool Check()
        {
            //if (CurrentObj == null) throw new CheckException("没有要添加的对象");
            return true;
        }

        #endregion 命令方法

        #region 预制对象

        private CheckHelp _checkHelp;
        /// <summary>
        /// 检查对象 集成到本系统业务
        /// </summary>
        public CheckHelp CheckHelper
        {
            get
            {
                if (_checkHelp == null) _checkHelp = new CheckHelp();
                return _checkHelp;
            }
            set { _checkHelp = value; }
        }
        #endregion

    }
}