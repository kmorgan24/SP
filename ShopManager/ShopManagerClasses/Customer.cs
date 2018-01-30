using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Customer
    {
        public long Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Nullable<long> SpouseID { get; set; }
        public string CompanyName { get; set; }
    }
}
