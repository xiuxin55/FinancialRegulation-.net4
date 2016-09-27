using System;

namespace MODEL
{
    /// <summary>
    /// 网点表
    /// </summary>
    public class JG_BranchesInfo
    {
        private string _br_id;
        /// <summary>
        /// ID
        /// </summary>
        public string BR_ID
        {
            get { return _br_id; }
            set { _br_id = value; }
        }
        private string _br_branchcode;
        /// <summary>
        /// 网点名称
        /// </summary>
        public string BR_BranchCode
        {
            get { return _br_branchcode; }
            set { _br_branchcode = value; }
        }
        private string _br_branchname;
        /// <summary>
        /// 编号
        /// </summary>
        public string BR_BranchName
        {
            get { return _br_branchname; }
            set { _br_branchname = value; }
        }
        private string _br_fzr;
        /// <summary>
        /// 负责人
        /// </summary>
        public string BR_Fzr
        {
            get { return _br_fzr; }
            set { _br_fzr = value; }
        }
        private string _br_address;
        /// <summary>
        /// 地址
        /// </summary>
        public string BR_Address
        {
            get { return _br_address; }
            set { _br_address = value; }
        }
       
        private string _br_state;
        /// <summary>
        /// 网点启用状态 OPEN CLOSE
        /// </summary>
        public string BR_State
        {
            get { return _br_state; }
            set { _br_state = value; }
        }
   }
}
