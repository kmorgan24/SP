using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class PhoneNumber
    {
        public long Id { get; set; }
        public long CustomerID { get; set; }
        public string Number { get; set; }
        public long Type { get; set; }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object PhoneNumber";
            temp += Environment.NewLine + "Id=" + Id;
            temp += Environment.NewLine + "CustomerID=" + CustomerID;
            temp += Environment.NewLine + "Number=" + Number;
            temp += Environment.NewLine + "Type=" + Type;
            return temp;
        }
    }
}
