﻿using System.Collections.Generic;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.Tools;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 管理ViewModel
    /// <para>
    /// 子类操作指南:
    /// 父类定义了默认的 T CurModel当前对象和 List&lt;T&gt; 集合对象 Models
    /// </para>
    /// <para> 定义了两个默认的命令 AddCommand (添加) 和FlushCommand (刷新)</para>
    /// <para> 还有对应的方法 AddExecute 和 FlushCommand 子类实现即可</para>
    /// <para>在LoadCommand();抽象方法中绑定子类的自定义命令集合</para>
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BaseManageVM<T> : BaseVM<T> where T : new()
    {
        public BaseManageVM()
        {
            LoadBaseCommand();
        }

        #region 预制对象

        private T _curModel;

        /// <summary>
        /// 管理端列表当前对象
        /// </summary>
        public T CurModel
        {
            get
            {
                if (_curModel == null) _curModel = new T();
                return _curModel;
            }
            set
            {
                _curModel = value;
                RaisePropertyChanged("CurModel");
            }
        }

        private List<T> _models;

        /// <summary>
        /// 当前集合
        /// </summary>
        public List<T> Models
        {
            get
            {
                if (_models == null) _models = new List<T>();
                return _models;
            }
            set
            {
                _models = value;
                RaisePropertyChanged("Models");
            }
        }

        #endregion 预制对象

        #region 命令定义

        private DelegateCommand _addCommand;

        /// <summary>
        /// 添加命令
        /// </summary>
        public DelegateCommand AddCommand
        {
            get { return _addCommand; }
            set
            {
                _addCommand = value;
                RaisePropertyChanged("AddCommand");
            }
        }

        private DelegateCommand _flushCommand;

        /// <summary>
        /// 刷新命令
        /// </summary>
        public DelegateCommand FlushCommand
        {
            get { return _flushCommand; }
            set
            {
                _flushCommand = value;
                this.RaisePropertyChanged("FlushCommand");
            }
        }

        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 添加
        /// </summary>
        public abstract void AddExecute();

        /// <summary>
        /// 刷新
        /// </summary>
        public abstract void FlushExecute();

        #endregion 命令方法

        #region 加载命令

        /// <summary>
        /// 加载默认命令
        /// </summary>
        private void LoadBaseCommand()
        {
            AddCommand = new DelegateCommand(AddExecute);
            FlushCommand = new DelegateCommand(FlushExecute);
        }

        #endregion 加载命令
    }
}