using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class WorkOrder
    {

        public long Id { get; set; }
        public long AppointmentID { get; set; }
        public long TechnicianID { get; set; }
    }
}
