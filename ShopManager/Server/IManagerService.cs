using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShopManagerClasses;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManagerService" in both code and config file together.
    [ServiceContract]
    public interface IManagerService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool CreateAppointment(int customerID, int carID, DateTime date, int hours, List<string> notes, List<LaborItem> labor);
    }
}
