using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    [Serializable]
    public class UserDuty
    {
        string _UserDutyID;

        public string UserDutyID
        {
            get { return _UserDutyID; }
            set { _UserDutyID = value; }
        }
        string _UserID;

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        string _DutyID;

        public string DutyID
        {
            get { return _DutyID; }
            set { _DutyID = value; }
        }
        string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
