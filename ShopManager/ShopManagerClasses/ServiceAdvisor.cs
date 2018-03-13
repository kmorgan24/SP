using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    [Serializable]
    public class ServiceAdvisor : User
    {
        long _active;
        long _id;
        long _loggedIN;
        string _loginName;
        string _name;
        string _password;

        public long Active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
            }
        }

        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public long LoggedIn
        {
            get
            {
                return _loggedIN;
            }

            set
            {
                _loggedIN = value;
            }
        }

        public string LoginName
        {
            get
            {
                return _loginName;
            }

            set
            {
                _loginName = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
    }
}
