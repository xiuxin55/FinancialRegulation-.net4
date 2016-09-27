using System;

namespace MODEL
{
    /// <summary>
    /// 支付信息
    /// </summary>
    public class JG_PaymentInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string PA_ID { get; set; }

        /// <summary>
        /// 协议编号
        /// </summary>
        public string PA_xybh { get; set; }

        /// <summary>
        /// 支付类别
        /// </summary>
        public string PA_zflb { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal? PA_zfje { get; set; }

        /// <summary>
        /// 支付节点
        /// </summary>
        public string PA_zfjd { get; set; }

        /// <summary>
        /// 付款方账户
        /// </summary>
        public string PA_fkfzh { get; set; }

        /// <summary>
        /// 付款方名称
        /// </summary>
        public string PA_fkfmc { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        public string PA_fkBank { get; set; }

        /// <summary>
        /// 收款方账户
        /// </summary>
        public string PA_skfzh { get; set; }

        /// <summary>
        /// 收款方名称
        /// </summary>
        public string PA_skfmc { get; set; }

        /// <summary>
        /// 收款银行
        /// </summary>
        public string PA_skBank { get; set; }

        /// <summary>
        /// 支付请求流水号
        /// </summary>
        public string PA_zfqqlsh { get; set; }

        /// <summary>
        /// 支付确认流水号
        /// </summary>
        public string PA_zfqrlsh { get; set; }

        /// <summary>
        /// 支付日期
        /// </summary>
        public DateTime PA_zfrq { get; set; }


        /// <summary>
        /// 银行支付日期
        /// </summary>
        public DateTime PA_yhzfrq { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string PA_sqr { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime PA_sqrq { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string PA_shr { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime PA_shrq { get; set; }

        /// <summary>
        /// 流程
        /// </summary>
        public string PA_lc { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal? PA_zhye { get; set; }

        /// <summary>
        /// 支付类别Name
        /// </summary>
        public string PA_zflbName { get; set; }

        /// <summary>
        /// 支付节点Name
        /// </summary>
        public string PA_zfjdName { get; set; }

        /// <summary>
        /// 流程Name
        /// </summary>
        public string PA_lcName { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string PA_Person { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        public string PA_BankCode { get; set; }

        /// <summary>
        /// 支付备注  用于扣款补录 扣款信息
        /// </summary>
        public string PA_Remark { get; set; }


        /// <summary>
        /// 公司代码
        /// </summary>
        public string SP_CorpCode { get; set; }
    }
}