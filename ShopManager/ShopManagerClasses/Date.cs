using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Date
    {
        public long Id { get; set; }
        public long AppointmentID { get; set; }
        public string Date1 { get; set; }
        public long Hours { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Customer";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "AppointmentID=" + AppointmentID;
            temp += Environment.NewLine + "Date=" + Date1;
            temp += Environment.NewLine + "Hours=" + Hours;

            return temp;
        }
    }
}
