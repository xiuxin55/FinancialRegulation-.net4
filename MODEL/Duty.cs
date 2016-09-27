using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    [Serializable]
    public class Duty
    {
        string _DutyID;

        public string DutyID
        {
            get { return _DutyID; }
            set { _DutyID = value; }
        }
        string _DutyCode;

        public string DutyCode
        {
            get { return _DutyCode; }
            set { _DutyCode = value; }
        }
        string _DutyName;

        public string DutyName
        {
            get { return _DutyName; }
            set { _DutyName = value; }
        }
        string _Describe;

        public string Describe
        {
            get { return _Describe; }
            set { _Describe = value; }
        }
    }
}
