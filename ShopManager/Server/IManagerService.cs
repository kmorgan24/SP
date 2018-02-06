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
        bool DoWork();

        [OperationContract]
        bool CreateAppointment(int customerID, int carID, DateTime date, int hours, List<string> notes, List<LaborItem> labor);

        [OperationContract]
        void CreateAppointmentFromClass(ShopManagerClasses.Appointment a);

        [OperationContract]
        List<ShopManagerClasses.Appointment> GetAppointments(DateTime start);

        [OperationContract]
        List<ShopManagerClasses.User> GetUsers();

        [OperationContract]
        List<ShopManagerClasses.Customer> SearchCustomerByCompanyName(string text);

        [OperationContract]
        List<ShopManagerClasses.Customer> SearchCustomerByPhoneNumber(string text);

        [OperationContract]
        void AddTechnician(Technician temp);

        [OperationContract]
        List<ShopManagerClasses.Customer> SearchCustomerByLastName(string text);

        [OperationContract]
        void AddCar(long _customer, ShopManagerClasses.Car temp);

        [OperationContract]
        void AddServiceAdvisor(ServiceAdvisor temp);

        [OperationContract]
        void AddPhoneNumber(ShopManagerClasses.PhoneNumber num, long _customerID);

        [OperationContract]
        List<ShopManagerClasses.Customer> SearchCustomerByFirstName(string text);

        [OperationContract]
        long CreateCustomer(string companyName, string fName, string lName, long? spouseID);

        [OperationContract]
        List<ShopManagerClasses.Car> GetCarsByCustomerID(long id);

        [OperationContract]
        List<ShopManagerClasses.PhoneNumber> GetCustomerPhoneNumbersByCustomerID(long id);

        [OperationContract]
        void DeactivateUser(long selectedUserID);
    }
}
