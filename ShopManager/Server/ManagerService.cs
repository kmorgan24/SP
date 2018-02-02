using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShopManagerClasses;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManagerService" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]

    public class ManagerService : IManagerService
    {
        public bool CreateAppointment(int customerID, int carID, DateTime date, int hours, List<string> notes, List<LaborItem> labor)
        {
            throw new NotImplementedException();
        }

        public void CreateAppointmentFromClass(ShopManagerClasses.Appointment a)
        {
            throw new NotImplementedException();
        }

        public bool DoWork()
        {
            return true;
        }
    }
}
