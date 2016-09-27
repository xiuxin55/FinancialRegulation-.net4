using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.Tools;

namespace FinancialRegulation.ViewModel
{
    public class UnKnownInfoAddVM : BaseEditVM<Message.Message105>
    {
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_DepositClient deClient = FundsRegulatoryClient.JG_DepositClient.Instance;

        #region 构造加载
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            JdModel = new FundsRegulatoryClient.JG_DepositSrv.DepositFund();
        }
        #endregion

        #region 变量属性
        //TODO:在此定义命令和属性


        private FundsRegulatoryClient.JG_DepositSrv.DepositFund _jdmodel;
        /// <summary>
        /// 存款信息
        /// </summary>
        public FundsRegulatoryClient.JG_DepositSrv.DepositFund  JdModel
        {
            get { return _jdmodel; }
            set
            {
                _jdmodel = value;
                this.RaisePropertyChanged("JdModel");
            }
        }

        private FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol _spvModel;
        /// <summary>
        /// 协议信息
        /// </summary>
        public FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol SpvModel
        {
            get { return _spvModel; }
            set
            {
                _spvModel = value;
                //this.RaisePropertyChanged("SpvModel");
            }
        }

        #endregion

        #region 命令定义
        //TODO:在此定义命令
        #endregion

        #region 命令方法

        public override void OKExecute()
        {
           /* if (JdModel._DE_ckje == null)
            {
                VMHelp.ShowMessage("请填写存款金额!", true);
                return;
            }
            if (JdModel._DE_ckxz == null)
            {
                VMHelp.ShowMessage("请选择资金性质!", true);
                return;
            }
            if (JdModel._DE_zhye == null)
            {
                VMHelp.ShowMessage("请填写账户余额!", true);
                return;
            }


            if (VMHelp.AskMessage("确定要缴存不明账款?"))
            {
                Message.Message005 msg005 = GetResponse();
                if (msg005.ExceptionCode == "01")
                {
                    JdModel._DE_ID = Guid.NewGuid().ToString();
                    JdModel._DE_xybh = SpvModel.SP_XYBH;

                    JdModel._DE_cklb = "1";
                    JdModel._DE_Person = Common.CommonData.GetInstance().LoginUserCode;
                    JdModel._DE_BankCode = VMHelp.PointCode;
                    bool result = deClient.AddUnKownJG_Deposit(JdModel);

                    if (result)
                    {
                        if (msg005.SaveMessage(Message.XmlSerializerTools.ToXmlStr(msg005, VMHelp.EncodingX)))
                        {
                            VMHelp.ShowMessage("不明账款缴存成功!", true);
                            windowClose();
                            
                        }
                        else
                        {
                            throw new Exception("报文保存失败!");
                        }
                    }
                    else
                    {
                        VMHelp.ShowMessage("不明账款缴存失败!", false);
                    }
                }
            }*/
        }
        #endregion


        #region 内部方法

        private Message.Message005 GetResponse()
        {
          /*  Message.Message105 request = new Message.Message105();
            JdModel._DE_ckrq = Convert.ToDateTime(VMHelp.NowTime.ToString());
            JdModel._DE_cklsh = VMHelp.ServiceNo;
            JdModel._DE_dwbh=VMHelp.SYSCONFIG.BankCode;

            request.BusinessCode = "105";
            request.BusinessTime = JdModel._DE_ckrq.ToString();
            request.SerialNo = JdModel._DE_cklsh;
            request.PactNo = SpvModel.SP_XYBH;
            request.CorpCode = SpvModel.SP_CorpCode;
            request.Money = JdModel._DE_ckje.Value;
            request.NatureOfFunding = JdModel._DE_ckxz;
            request.Balances = JdModel._DE_zhye.Value;
            request.FromBbank = JdModel._DE_dwbh;*/

           // Message.NewMessage.Request.Request01 response = SendMessage<Message.NewMessage.Request.Request01>(request);

            return null;
        }

        #endregion

    }
}
