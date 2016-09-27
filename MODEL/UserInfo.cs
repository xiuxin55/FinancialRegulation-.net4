using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    [Serializable]
    public class UserInfo
    {
        string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        string _UserCode;

        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }
        string _UserPwd;

        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _UnitID;

        public string UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        string _Sex;

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        string _LinkTel;

        public string LinkTel
        {
            get { return _LinkTel; }
            set { _LinkTel = value; }
        }
        string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _State;

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        string _Describe;

        public string Describe
        {
            get { return _Describe; }
            set { _Describe = value; }
        }
        string _LoginIP;

        public string LoginIP
        {
            get { return _LoginIP; }
            set { _LoginIP = value; }
        }

        private string ssq;

        public string Ssq
        {
            get { return ssq; }
            set { ssq = value; }
        }

        public List<MenuItem> menuitem { get; set; }

    }
}
