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
        public long Hours { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
    }
}
