using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace FinancialRegulation.ViewModel
{
    public class SysConfigEditVM : BaseEditVM<FundsRegulatoryClient.SysConfigSrv.SysConfigInfo>
    {
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.SysConfigClient client = FundsRegulatoryClient.SysConfigClient.Instance;

        #region 构造加载
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {

        }
        public override void LoadData()
        {
            CurrentObj = client.Selects()[0];
        }
        #endregion

        #region 变量属性
        //TODO:在此定义命令和属性
       
        #endregion

        #region 命令定义
        //TODO:在此定义命令
        #endregion

        #region 命令方法

        public override void OKExecute()
        {
            if (Check() && VMHelp.AskMessage("确定要更改系统配置?"))
            {
                if (client.Update(CurrentObj))
                {
                    VMHelp.GETSYSTEMCONFIG();
                    VMHelp.ShowMessage("修改成功", true);
                }
                else
                {
                    VMHelp.ShowMessage("数据更新失败,原因：1、数据库无法更新 2、文件路径错误", false);
                }
            }
        }
        public override bool Check()
        {
            CheckHelper.RegexCheck(CurrentObj.IP, "IP", "([1-9]|[1-9]\\d|1\\d{2}|2[0-4]\\d|25[0-5])(\\.(\\d|[1-9]\\d|1\\d{2}|2[0-4]\\d|25[0-5])){3}");
            CheckHelper.StrLengthCheck(CurrentObj.BankCode, "银行编号", 30);
            CheckHelper.StrLengthCheck(CurrentObj.BankName, "银行名称", 50);
            CheckHelper.CustomerCheck(CurrentObj.Port, "端口号不正确", (i) => int.Parse(i) < 65536 && int.Parse(i) > 0);
            CheckHelper.NotNullCheck(CurrentObj.MainWebSite, "总行网点号");
            return true;
        }
        #endregion

        #region 内部方法
        //private bool SetBillPath(string path)
        //{
        //    try
        //    {
        //        DefineFileReadWrite.WriteXml(CommonData.GetInstance().ConfigFile, "Config/ClientPara/FilePath/Path", path);
        //        DefineFileReadWrite.ReadXml(CommonData.GetInstance().ConfigFile, "Config/ClientPara/FilePath/Path");
        //        return true;
        //    }
        //    catch
        //    {
        //        return false; 
        //    }
        //}
        #endregion
    }
}
