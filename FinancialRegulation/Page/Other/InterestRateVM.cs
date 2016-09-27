using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.ViewModel;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_InterestRateSrv;
using Microsoft.Practices.Prism.Commands;

namespace FinancialRegulation.Page.Other
{
    public class InterestRateVM:BaseManageVM<JG_InterestRateInfo>
    {

        public JG_InterestRateClient client = JG_InterestRateClient.Instance;


        public override void LoadCommand()
        {
            ChangeStateCommond = new DelegateCommand<string>(ChangeStateExecute);
        }


        public override void LoadData()
        {
            FlushExecute();
        }


        #region 属性

        //利率
        private List<JG_InterestRateInfo> _interestRateList;

        public List<JG_InterestRateInfo> InterestRateList
        {
            get { return _interestRateList; }
            set
            {
                _interestRateList = value;
                this.RaisePropertyChanged("InterestRateList");
            }
        }

        private DelegateCommand<string> _changeStateCommond;

        public DelegateCommand<string> ChangeStateCommond
        {
            get { return _changeStateCommond; }
            set
            {
                _changeStateCommond = value;
                this.RaisePropertyChanged("ChangeStateCommond");
            }
        }

        

        #endregion



        #region 命令

        public DelegateCommand SearchCommond { get; set; }

        #endregion



        #region 方法


        /// <summary>
        /// 更改状态方法
        /// </summary>
        /// <param name="state">状态值</param>
        public void ChangeStateExecute(string state)
        {
            if (state == "0")
            {
                CurModel.Flag = "1";
            }
            else
            {
                CurModel.Flag = "0";
            }
            JG_InterestRateClient.Instance.UpdateJG_InterestRateInfo(CurModel);
            FlushExecute();
        }

        public override void AddExecute()
        {
            InterestRateEdit ire = new InterestRateEdit(CurModel);
            ire.ShowDialog();

        }

        public override void FlushExecute()
        {
            Models = client.Selects();
        }

        #endregion

        public override void ModifyExecute()
        {
            throw new NotImplementedException();
        }

        public override void DeleteExecute()
        {
            throw new NotImplementedException();
        }

        public override void DestroyAccountExecute()
        {
            throw new NotImplementedException();
        }
    }
}
