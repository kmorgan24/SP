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
    }
}
