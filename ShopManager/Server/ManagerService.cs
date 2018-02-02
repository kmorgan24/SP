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


        /*
        using (var db = new mainEntities())
            {
                String n = new String
                {
                    Id = db.Strings.Count() + 1,
                    Input = stuff   
                };
                db.Strings.Add(n);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                
                db.Dispose();
            }
            */





        /// <summary>
        /// use this function to create a new appointment on the server from its base componants
        /// this function is currently not implimented and may be removed later if it is not needed
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="carID"></param>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="notes"></param>
        /// <param name="labor"></param>
        /// <returns></returns>
        public bool CreateAppointment(int customerID, int carID, DateTime date, int hours, List<string> notes, List<LaborItem> labor)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// use this function to create the appointment from an assembled appointment class
        /// </summary>
        /// <param name="a"></param>
        public void CreateAppointmentFromClass(ShopManagerClasses.Appointment a)
        {
            using (var db = new mainEntities())
            {
                Appointment app = new Appointment
                {
                    Id = db.Appointments.Count() + 1,
                    CarID = a._car.Id,
                    CustomerID = a._customer.Id
                };
                db.Appointments.Add(app);

                foreach (ShopManagerClasses.Date item in a.Dates)
                {
                    Date d = new Date
                    {
                        Id = db.Dates.Count() + 1,
                        Date1 = item.Date1,
                        Hours = item.Hours,
                        AppointmentID = item.AppointmentID
                    };
                    db.Dates.Add(d);
                }
                foreach (ShopManagerClasses.Note item in a.Notes)
                {
                    Note n = new Note
                    {
                        Id = db.Notes.Count() + 1,
                        Active = item.Active,
                        AppointmentID = app.Id,
                        CarID = app.CarID,
                        CustomerID = app.CustomerID,
                        Description = item.Description,
                        Visible = item.Visible
                    };
                    db.Notes.Add(n);
                }
                foreach (ShopManagerClasses.LaborItem item in a.Labor)
                {
                    Labor l = new Labor
                    {
                        Id = db.Labors.Count() + 1,
                        AppointmentID = app.Id,
                        Complete = 0,
                        Description = item.Description,
                        Hours = (long)item.Hours    // this needs changed on the DB to support tenths of an hour
                    };
                    db.Labors.Add(l);
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }

            }
        }

        public bool DoWork()
        {
            return true;
        }

        public List<ShopManagerClasses.Appointment> GetAppointments(DateTime day)
        {
            List<ShopManagerClasses.Appointment> apps = new List<ShopManagerClasses.Appointment>();
            using (var db = new mainEntities())
            {
                // select from dates table any dates that match
                var tempApps =
                    from d in db.Dates
                    where d.Date1 == day.ToString()
                    select d;

                foreach (var item in tempApps)
                {
                    var temp = new ShopManagerClasses.Appointment();
                    temp.Id = item.AppointmentID;
                    // select the list of dates with matching appointment ids
                    List<ShopManagerClasses.Date> dates = new List<ShopManagerClasses.Date>();
                    var tempDates =
                        from d in db.Dates
                        where d.AppointmentID == item.AppointmentID
                        select d;
                    foreach (var tempdateitem in tempDates)
                    {
                        var tempSDate = new ShopManagerClasses.Date();
                        tempSDate.AppointmentID = tempdateitem.AppointmentID;
                        tempSDate.Date1 = tempdateitem.Date1;
                        tempSDate.Hours = tempdateitem.Hours;
                        tempSDate.Id = tempdateitem.Id;
                        dates.Add(tempSDate);
                    }
                   temp.Dates = dates;
                   // select the list of labor items with matching appointment ids
                   //temp.Labor;
                   // select the list of notes with matching ids
                   //temp.Notes
                   // select the car that is associated
                   //temp._car
                   // select the customer that is associated
                   //temp._customer

                   apps.Add(temp);
                }

                

            }


            return apps;
        }
    }
}
