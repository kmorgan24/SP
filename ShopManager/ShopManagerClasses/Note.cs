using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Note
    {
        public long Id { get; set; }
        public Nullable<long> AppointmentID { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public Nullable<long> CarID { get; set; }
        public string Description { get; set; }
        public long Active { get; set; }
        public long Visible { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Note";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "AppointmentId=" + AppointmentID;
            temp += Environment.NewLine + "CustomerId=" + CustomerID;
            temp += Environment.NewLine + "CarId=" + CarID;
            temp += Environment.NewLine + "Description=" + Description;
            temp += Environment.NewLine + "Active=" + Active;
            temp += Environment.NewLine + "Visible=" + Visible;
            return temp;
        }
    }
}
