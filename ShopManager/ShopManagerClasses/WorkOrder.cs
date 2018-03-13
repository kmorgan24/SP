using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    [Serializable]
    public class WorkOrder
    {

        public long Id { get; set; }
        public Appointment app;
        public long TechnicianID { get; set; }
        public bool Complete;

        public WorkOrder(Appointment App, long ID, long TechID, bool complete)
        {
            app = App;
            Id = ID;
            TechnicianID = TechID;
            Complete = complete;
        }

        public override string ToString()
        {
            string temp = Environment.NewLine + "Object WorkOrder";
            temp += Environment.NewLine + "Id" + Id;
            temp += Environment.NewLine + "Appointment=" + app;
            temp += Environment.NewLine + "TechnicianID=" + TechnicianID;
            return temp;
        }
    }
}
