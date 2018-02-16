using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class LaborItem
    {
        public long Id { get; set; }
        public long AppointmentID { get; set; }
        public double Hours { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public string LongDescription { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object LaborItem";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "AppointmentId=" + AppointmentID;
            temp += Environment.NewLine + "Hours=" + Hours;
            temp += Environment.NewLine + "Description=" + Description;
            temp += Environment.NewLine + "Complete=" + Complete;
            temp += Environment.NewLine + "LongDescription=" + LongDescription;
            return temp;
        }
    }
}
