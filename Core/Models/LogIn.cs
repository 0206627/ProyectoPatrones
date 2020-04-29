using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class LogIn
    {
        private string _email;
        private string _pwd;
        private int _userID;
        public LogIn(string email, string pwd)
        {
            this._email = email;
            this._pwd = pwd;
        }

        public string GetEmail()
        {
            return _email;
        }

        public string GetPwd()
        {
            return _pwd;
        }

        public void SetEmail(string dataBasePwd)
        {
            _email = dataBasePwd;
        }

        public int GetID()
        {
            return _userID;
        }

        public void SetID(int userID)
        {
            _userID = userID;
        }
    }
}
