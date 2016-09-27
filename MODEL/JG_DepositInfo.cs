using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class JG_DepositInfo
    {
        public string _DE_ID { get; set; }
        public string _DE_xybh { get; set; } //协议编号
        public string _DE_qybh { get; set; } //合同备案号 
        public string _DE_jyckh { get; set; } //
        public string _DE_ckr { get; set; } //存款人
        public string _DE_dwbh { get; set; } //银行编号
        public string _DE_ckxz { get; set; } //存款性质
        public string _DE_cklb { get; set; } //存款类别
        public decimal? _DE_ckje { get; set; } //存款金额
        public DateTime? _DE_ckrq { get; set; }   //存款日期
        public string _DE_cklsh { get; set; } //存款流水号
        public string _DE_isdy { get; set; } //
        public DateTime? _DE_dysj { get; set; }
        public decimal? _DE_zhye { get; set; }
        public string _DE_Person { get; set; } //经办人
        public string _DE_BankCode { get; set; }//银行代码

        public string _DE_ckzh { get; set; } //存款账号
        public string _DE_CropCode { get; set; }//企业编号  取的时候
    }
}
