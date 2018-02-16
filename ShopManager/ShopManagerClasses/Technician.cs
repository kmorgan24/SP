using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Technician: User
    {
        public long Active { get; set; }

        public long Id { get; set; }

        public long LoggedIn { get; set; }

        public string LoginName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public long Skill { get; set; }
        public long TargetHours { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Address";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "Active=" + Active;
            temp += Environment.NewLine + "LoggedIn=" + LoggedIn;
            temp += Environment.NewLine + "LoginName=" + LoginName;
            temp += Environment.NewLine + "Name=" + Name;
            temp += Environment.NewLine + "Password=" + Password;
            temp += Environment.NewLine + "Skill=" + Skill;
            temp += Environment.NewLine + "TargetHours=" + TargetHours;
            return temp;
        }
    }
}
