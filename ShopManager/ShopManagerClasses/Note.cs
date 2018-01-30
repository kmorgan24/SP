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
    }
}
