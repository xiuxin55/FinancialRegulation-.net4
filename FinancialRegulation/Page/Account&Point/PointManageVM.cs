using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_BranchesSrv;
using FinancialRegulation.Page;
using Microsoft.Practices.Prism.Commands;

namespace FinancialRegulation.ViewModel
{
    public class PointManageVM : BaseManageVM<JG_BranchesInfo>
    {
        public JG_BranchesClient client = JG_BranchesClient.Instance;

        #region 命令定义
        private DelegateCommand _updateCommand;
        /// <summary>
        /// 更新网点
        /// </summary>
        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand; }
            set
            {
                _updateCommand = value;

                RaisePropertyChanged("UpdateCommand");
            }
        }


        private DelegateCommand<string> changeStateCommand;

        /// <summary>
        /// 更改状态
        /// </summary>
        public DelegateCommand<string> ChangeStateCommand
        {
            get { return changeStateCommand; }
            set
            {
                changeStateCommand = value;
                RaisePropertyChanged("ChangeStateCommand");
            }
        }

        #endregion 命令定义

        #region 构造加载

        public override void LoadCommand()
        {
            ChangeStateCommand = new DelegateCommand<string>(ChangeStateExecute);
            UpdateCommand = new DelegateCommand(UpdateExecute);
        }

        public override void LoadData()
        {
            FlushExecute();//更新数据
        }

        #endregion 构造加载

        #region 命令方法
        public void UpdateExecute()
        {
            PointEdit pme = new PointEdit(new PointManageEditVM()
            {
                IsEdit = true,
                CurrentObj = this.CurModel
            });
            pme.ShowDialog();
            FlushExecute();
        }
        /// <summary>
        /// 更改状态方法
        /// </summary>
        /// <param name="state">状态值</param>
        public void ChangeStateExecute(string state)
        {
            if (state == Tools.PublicData.Branches_Sc)
            {
                CurModel.BR_State = Tools.PublicData.Branches_So;
            }
            else
            {
                CurModel.BR_State = Tools.PublicData.Branches_Sc;
            }
            JG_BranchesClient.Instance.Update(CurModel);
            FlushExecute();
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        public override void AddExecute()
        {
            PointEdit pme = new PointEdit();
            pme.ShowDialog();
            FlushExecute();
        }

        /// <summary>
        /// 刷新方法
        /// </summary>
        public override void FlushExecute()
        {
            Models = client.Selects();
        }

        #endregion 命令方法

        public override void ModifyExecute()
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteExecute()
        {
            throw new System.NotImplementedException();
        }

        public override void DestroyAccountExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}