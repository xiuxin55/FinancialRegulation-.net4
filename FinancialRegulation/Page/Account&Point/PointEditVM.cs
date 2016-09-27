using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using FundsRegulatoryClient.JG_BranchesSrv;
using FinancialRegulation.Tools;
using FinancialRegulation.ClientException;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 逻辑层
    /// </summary>
    public class PointManageEditVM : BaseEditVM<JG_BranchesInfo>
    {
        //编辑还是添加 false添加 true编辑
        public bool IsEdit = false;

        private JG_BranchesClient client = JG_BranchesClient.Instance;
        /// <summary>
        /// 执行添加
        /// </summary>
        public override void OKExecute()
        {
            try
            {
                if (!IsEdit)
                {
                    if (Check() && VMHelp.AskMessage("确认要添加该网点?"))
                    {
                        CurrentObj.BR_ID = Guid.NewGuid().ToString();
                        CurrentObj.BR_State = Tools.PublicData.Branches_So;

                        bool result = client.Add(CurrentObj);

                        if (result)
                        {
                            VMHelp.ShowMessage("添加成功", true);
                            windowClose();
                        }
                        else
                        {
                            VMHelp.ShowMessage("添加失败", false);
                        }
                    }
                }
                else
                {
                    if (Check() && VMHelp.AskMessage("确认要更新该网点?"))
                    {

                        if (client.Update(CurrentObj))
                        {
                            VMHelp.ShowMessage("更新成功", true);
                            windowClose();
                        }
                        else
                        {
                            VMHelp.ShowMessage("更新失败", false);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("违反了 UNIQUE KEY 约束 'OnlyCode'"))
                {
                    VMHelp.ShowMessage("更新失败,不能添加重复的网点编号", false);
                }
                else
                {
                    throw ex;
                }
            }
        }
        public override bool Check()
        {
            //CheckHelper.StrLengthCheck(CurrentObj.BR_BranchCode, "网店编号", 4);
            CheckHelper.NotNullCheck(CurrentObj.BR_BranchCode, "网店编号");
            CheckHelper.StrLengthCheck(CurrentObj.BR_BranchName, "网点名称", 25);
            CheckHelper.StrLengthCheck(CurrentObj.BR_Address, "网点地址", 100);
           
            return true;
        }
        public override void LoadCommand()
        {

        }
    }
}