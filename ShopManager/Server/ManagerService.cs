using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShopManagerClasses;
using System.Data.SQLite;
using ManagerLogger;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManagerService" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]

    public class ManagerService : IManagerService
    {
        public void AddCar(long _customer, ShopManagerClasses.Car temp)
        {
            using (var db = new mainEntities())
            {
                Car c = new Car
                {
                    Id = db.Cars.Count() + 1,
                    Make = temp.Make,
                    Model = temp.Model,
                    Owner = temp.Owner,
                    Plate = temp.Plate,
                    ProdDate = temp.ProdDate,
                    State = temp.State,
                    Vin = temp.Vin,
                    Year = temp.Year
                };
                db.Cars.Add(c);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "AddCar", e.Message);
                }
            }
        }

        public void AddPhoneNumber(ShopManagerClasses.PhoneNumber num, long _customerID)
        {
            using (var db = new mainEntities())
            {
                PhoneNumber numb = new PhoneNumber
                {
                    Id = db.PhoneNumbers.Count() + 1,
                    CustomerID = _customerID,
                    Number = num.Number,
                    Type = num.Type
                };
                db.PhoneNumbers.Add(numb);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "AddPhoneNumber", e.Message);
                }
            }
        }

        public void AddServiceAdvisor(ServiceAdvisor Newuser)
        {
            using (var db = new mainEntities())
            {
                User tempuser = new User
                {
                    Id = db.Users.Count() + 1,
                    LoggedIn = 0,
                    Active = Newuser.Active,
                    LoginName = Newuser.LoginName,
                    Name = Newuser.Name,
                    Password = Newuser.Password,
                    Skill = -1,
                    TargetHours = -1
                };
                db.Users.Add(tempuser);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "AddServiceAdvisor", e.Message);
                }
            }
        }

        public void AddTechnician(Technician Newuser)
        {
            using (var db = new mainEntities())
            {
                User tempuser = new User
                {
                    Id = db.Users.Count() + 1,
                    LoggedIn = 0,
                    Active = Newuser.Active,
                    LoginName = Newuser.LoginName,
                    Name = Newuser.Name,
                    Password = Newuser.Password,
                    Skill = Newuser.Skill,
                    TargetHours = Newuser.TargetHours
                };
                db.Users.Add(tempuser);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "AddTechnician", e.Message);
                }
            }
        }


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
                try
                {
                    foreach (ShopManagerClasses.Date item in a.Dates)
                    {
                        Date d = new Date
                        {
                            Id = db.Dates.Count() + 1,
                            Date1 = item.Date1,
                            Hours = item.Hours,
                            AppointmentID = app.Id
                        };
                        db.Dates.Add(d);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "No Dates were included", "CreateAppointmentFromClass", e.Message);
                    throw new InvalidOperationException("a date must be supplied");
                }
                try
                {
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
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "No Notes were included", "CreateAppointmentFromClass", e.Message);

                }
                try
                {
                    foreach (ShopManagerClasses.LaborItem item in a.Labor)
                    {
                        Labor l = new Labor
                        {
                            Id = db.Labors.Count() + 1,
                            AppointmentID = app.Id,
                            Complete = 0,
                            Description = item.Description,
                            LongDescription = item.LongDescription,
                            Hours = (long)item.Hours    // this needs changed on the DB to support tenths of an hour
                        };
                        db.Labors.Add(l);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "No Labor items were included", "CreateAppointmentFromClass", e.Message);
                    throw new InvalidOperationException("a LaborItem must be supplied");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "CreateAppointmentFromClass", e.Message + a);
                }

            }
        }

        public long CreateCustomer(string companyName, string fName, string lName, long? spouseID)
        {
            long Rvalue = -1;
            using (var db = new mainEntities())
            {
                Customer c = new Customer
                {
                    Id = db.Customers.Count() + 1,
                    CompanyName = companyName,
                    FName = fName,
                    LName = lName,
                    SpouseID = spouseID
                };
                db.Customers.Add(c);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "CreateCustomer", e.Message);
                    return Rvalue;
                }
                Rvalue = c.Id;
            }
            return Rvalue;
        }

        public void DeactivateUser(long selectedUserID)
        {
            using (var db = new mainEntities())
            {
                var target =
                    from t in db.Users
                    where t.Id == selectedUserID
                    select t;
                foreach (var item in target)
                {
                    item.Active = 0;
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "DeactivateUser", e.Message);
                }

            }
        }

        public bool DoWork()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<ShopManagerClasses.Appointment> GetAppointments(DateTime day)
        {
            List<ShopManagerClasses.Appointment> apps = new List<ShopManagerClasses.Appointment>();
            using (var db = new mainEntities())
            {
                string dateString = day.Date.ToString();
                // select from dates table any dates that match
                try
                {
                    var tempApps =
                        from d1 in db.Dates
                        where d1.Date1.Equals(dateString)
                        select d1;



                    foreach (var item in tempApps)
                    {
                        try
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
                            List<ShopManagerClasses.LaborItem> labor = new List<ShopManagerClasses.LaborItem>();
                            var tempLaborItems =
                                 from l in db.Labors
                                 where l.AppointmentID == item.AppointmentID
                                 select l;
                            foreach (var tempLaborItem in tempLaborItems)
                            {
                                var tempSLabor = new ShopManagerClasses.LaborItem();
                                tempSLabor.AppointmentID = temp.Id;
                                tempSLabor.Id = tempLaborItem.Id;
                                tempSLabor.Complete = (tempLaborItem.Complete == 0) ? false : true;
                                tempSLabor.Description = tempLaborItem.Description;
                                tempSLabor.LongDescription = "Not Yet implimented on DB";
                                tempSLabor.Hours = tempLaborItem.Hours;
                                labor.Add(tempSLabor);
                            }
                            temp.Labor = labor;
                            // select the list of notes with matching ids
                            List<ShopManagerClasses.Note> notes = new List<ShopManagerClasses.Note>();
                            var tempNotes =
                                 from n in db.Notes
                                 where n.AppointmentID == temp.Id
                                 select n;
                            foreach (var tempNoteItem in tempNotes)
                            {
                                var tempSNote = new ShopManagerClasses.Note();
                                tempSNote.Active = tempNoteItem.Active;
                                tempSNote.AppointmentID = tempNoteItem.AppointmentID;
                                tempSNote.CarID = tempNoteItem.CarID;
                                tempSNote.CustomerID = tempNoteItem.CustomerID;
                                tempSNote.Description = tempNoteItem.Description;
                                tempSNote.Id = tempNoteItem.Id;
                                tempSNote.Visible = tempNoteItem.Visible;
                                notes.Add(tempSNote);
                            }
                            temp.Notes = notes;
                            var tempAppointment =
                                from a in db.Appointments
                                where a.Id == temp.Id
                                select a;
                            Appointment tempapp = tempAppointment.First();

                            // select the car that is associated
                            var tempCar =
                                 from c in db.Cars
                                 where c.Id == tempapp.CarID
                                 select c;
                            Car car = tempCar.First();
                            ShopManagerClasses.Car tempSCar = new ShopManagerClasses.Car();
                            tempSCar.Id = car.Id;
                            tempSCar.Make = car.Make;
                            tempSCar.Model = car.Model;
                            tempSCar.Owner = car.Owner;
                            tempSCar.Plate = car.Plate;
                            tempSCar.ProdDate = car.ProdDate;
                            tempSCar.State = car.State;
                            tempSCar.Vin = car.Vin;
                            tempSCar.Year = car.Year;

                            temp._car = tempSCar;
                            // select the customer that is associated
                            var tempCustomer =
                                 from c in db.Customers
                                 where c.Id == tempapp.CustomerID
                                 select c;
                            Customer cust = tempCustomer.First();
                            ShopManagerClasses.Customer tempSCustomer = new ShopManagerClasses.Customer();
                            tempSCustomer.CompanyName = cust.CompanyName;
                            tempSCustomer.FName = cust.FName;
                            tempSCustomer.Id = cust.Id;
                            tempSCustomer.LName = cust.LName;
                            tempSCustomer.SpouseID = cust.SpouseID;

                            temp._customer = tempSCustomer;

                            apps.Add(temp);
                        }
                        catch (Exception ei)
                        {
                            ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "GetAppointments", ei.Message);

                        }
                    }

                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "GetAppointments", e.Message);

                }






            }


            return apps;
        }

        public List<ShopManagerClasses.WorkOrder> GetAssignedJobs(long userID)
        {
            List<ShopManagerClasses.WorkOrder> Jobs = new List<ShopManagerClasses.WorkOrder>();

            using (var db = new mainEntities())
            {
                var orders =
                    from o in db.WorkOrders
                    where o.TechnicianID == userID
                    select o;
                foreach (var item in orders)
                {
                    ShopManagerClasses.WorkOrder temp = new ShopManagerClasses.WorkOrder(GetAppointmentByID(item.AppointmentID), item.Id, item.TechnicianID, item.Complete == 0 ? false : true);
                    Jobs.Add(temp);
                }
            }


            return Jobs;
        }

        private ShopManagerClasses.Appointment GetAppointmentByID(long appointmentID)
        {
            var temp = new ShopManagerClasses.Appointment();
            try
            {

                using (var db = new mainEntities())
                {



                    temp.Id = appointmentID;
                    // select the list of dates with matching appointment ids
                    List<ShopManagerClasses.Date> dates = new List<ShopManagerClasses.Date>();
                    var tempDates =
                        from d in db.Dates
                        where d.AppointmentID == appointmentID
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
                    List<ShopManagerClasses.LaborItem> labor = new List<ShopManagerClasses.LaborItem>();
                    var tempLaborItems =
                         from l in db.Labors
                         where l.AppointmentID == appointmentID
                         select l;
                    foreach (var tempLaborItem in tempLaborItems)
                    {
                        var tempSLabor = new ShopManagerClasses.LaborItem();
                        tempSLabor.AppointmentID = temp.Id;
                        tempSLabor.Id = tempLaborItem.Id;
                        tempSLabor.Complete = (tempLaborItem.Complete == 0) ? false : true;
                        tempSLabor.Description = tempLaborItem.Description;
                        tempSLabor.LongDescription = "Not Yet implimented on DB";
                        tempSLabor.Hours = tempLaborItem.Hours;
                        labor.Add(tempSLabor);
                    }
                    temp.Labor = labor;
                    // select the list of notes with matching ids
                    List<ShopManagerClasses.Note> notes = new List<ShopManagerClasses.Note>();
                    var tempNotes =
                         from n in db.Notes
                         where n.AppointmentID == temp.Id
                         select n;
                    foreach (var tempNoteItem in tempNotes)
                    {
                        var tempSNote = new ShopManagerClasses.Note();
                        tempSNote.Active = tempNoteItem.Active;
                        tempSNote.AppointmentID = tempNoteItem.AppointmentID;
                        tempSNote.CarID = tempNoteItem.CarID;
                        tempSNote.CustomerID = tempNoteItem.CustomerID;
                        tempSNote.Description = tempNoteItem.Description;
                        tempSNote.Id = tempNoteItem.Id;
                        tempSNote.Visible = tempNoteItem.Visible;
                        notes.Add(tempSNote);
                    }
                    temp.Notes = notes;
                    var tempAppointment =
                        from a in db.Appointments
                        where a.Id == temp.Id
                        select a;
                    Appointment tempapp = tempAppointment.First();

                    // select the car that is associated
                    var tempCar =
                         from c in db.Cars
                         where c.Id == tempapp.CarID
                         select c;
                    Car car = tempCar.First();
                    ShopManagerClasses.Car tempSCar = new ShopManagerClasses.Car();
                    tempSCar.Id = car.Id;
                    tempSCar.Make = car.Make;
                    tempSCar.Model = car.Model;
                    tempSCar.Owner = car.Owner;
                    tempSCar.Plate = car.Plate;
                    tempSCar.ProdDate = car.ProdDate;
                    tempSCar.State = car.State;
                    tempSCar.Vin = car.Vin;
                    tempSCar.Year = car.Year;

                    temp._car = tempSCar;
                    // select the customer that is associated
                    var tempCustomer =
                         from c in db.Customers
                         where c.Id == tempapp.CustomerID
                         select c;
                    Customer cust = tempCustomer.First();
                    ShopManagerClasses.Customer tempSCustomer = new ShopManagerClasses.Customer();
                    tempSCustomer.CompanyName = cust.CompanyName;
                    tempSCustomer.FName = cust.FName;
                    tempSCustomer.Id = cust.Id;
                    tempSCustomer.LName = cust.LName;
                    tempSCustomer.SpouseID = cust.SpouseID;

                    temp._customer = tempSCustomer;


                }
            }
            catch (Exception ei)
            {
                ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "GetAppointments", ei.Message);

            }
            return temp;
        }
        

        public List<ShopManagerClasses.Car> GetCarsByCustomerID(long id)
        {
            List<ShopManagerClasses.Car> RCars = new List<ShopManagerClasses.Car>();
            using (var db = new mainEntities())
            {
                var cars =
                    from c in db.Cars
                    where c.Owner == id
                    select c;
                foreach (var item in cars)
                {
                    ShopManagerClasses.Car tempSCar = new ShopManagerClasses.Car();
                    tempSCar.Id = item.Id;
                    tempSCar.Make = item.Make;
                    tempSCar.Model = item.Model;
                    tempSCar.Owner = item.Owner;
                    tempSCar.Plate = item.Plate;
                    tempSCar.ProdDate = item.ProdDate;
                    tempSCar.State = item.State;
                    tempSCar.Vin = item.Vin;
                    tempSCar.Year = item.Year;
                    RCars.Add(tempSCar);
                }
            }
            return RCars;
        }

        public int GetCurrentHours(DateTime dateTime)
        {
            int hours = 0;
            string searchS = dateTime.Date.ToString();
            using (var db = new mainEntities())
            {
                try
                {
                    var days =
                        from d in db.Dates
                        where d.Date1 == searchS
                        select d;
                    foreach (var item in days)
                    {
                        hours += (int)item.Hours;
                    }
                }
                catch (Exception)
                {

                }

            }

            return hours;
        }

        public List<ShopManagerClasses.PhoneNumber> GetCustomerPhoneNumbersByCustomerID(long id)
        {
            List<ShopManagerClasses.PhoneNumber> RPhoneNumber = new List<ShopManagerClasses.PhoneNumber>();
            using (var db = new mainEntities())
            {
                var nums =
                    from n in db.PhoneNumbers
                    where n.CustomerID == id
                    select n;
                foreach (var item in nums)
                {
                    ShopManagerClasses.PhoneNumber temp = new ShopManagerClasses.PhoneNumber();
                    temp.CustomerID = item.CustomerID;
                    temp.Id = item.Id;
                    temp.Number = item.Number;
                    temp.Type = item.Type;
                    RPhoneNumber.Add(temp);
                }
            }

            return RPhoneNumber;
        }

        public int GetMaxHours()
        {
            int hours = 0;
            using (var db = new mainEntities())
            {
                try
                {
                    var users =
                        from u in db.Users
                        where u.Active == 1
                        select u;
                    foreach (var item in users)
                    {
                        hours += (int)item.TargetHours;
                    }
                }
                catch (Exception)
                {

                    hours = 1;
                }

            }
            if (hours == 0)
            {
                hours = 1;
            }

            return hours;
            //return 16;
        }

        public List<ShopManagerClasses.User> GetUsers()
        {
            List<ShopManagerClasses.User> RUsers = new List<ShopManagerClasses.User>();
            using (var db = new mainEntities())
            {
                try
                {
                    var users =
                        from u in db.Users
                        where u.TargetHours != -1
                        select u;
                    foreach (var item in users)
                    {
                        ShopManagerClasses.Technician tempSUser = new ShopManagerClasses.Technician();
                        tempSUser.Id = item.Id;
                        tempSUser.LoggedIn = item.LoggedIn;
                        tempSUser.LoginName = item.LoginName;
                        tempSUser.Name = item.Name;
                        tempSUser.Password = item.Password;
                        tempSUser.Skill = item.Skill;
                        tempSUser.TargetHours = item.TargetHours;
                        RUsers.Add(tempSUser);
                    }

                    var Susers =
                        from u in db.Users
                        where u.TargetHours == -1
                        select u;
                    foreach (var item2 in users)
                    {
                        ShopManagerClasses.ServiceAdvisor tempSAdvisor = new ShopManagerClasses.ServiceAdvisor();
                        tempSAdvisor.Id = item2.Id;
                        tempSAdvisor.LoggedIn = item2.LoggedIn;
                        tempSAdvisor.LoginName = item2.LoginName;
                        tempSAdvisor.Name = item2.Name;
                        tempSAdvisor.Password = item2.Password;
                        RUsers.Add(tempSAdvisor);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "GetUsers", e.Message);
                }

            }
            try
            {
                return RUsers;
            }
            catch (Exception)
            {
                return new List<ShopManagerClasses.User>();
            }

        }

        public List<ShopManagerClasses.Technician> GetTechs()
        {
            List<ShopManagerClasses.Technician> RUsers = new List<ShopManagerClasses.Technician>();
            using (var db = new mainEntities())
            {
                try
                {
                    var users =
                        from u in db.Users
                        where u.TargetHours != -1
                        select u;
                    foreach (var item in users)
                    {
                        ShopManagerClasses.Technician tempSUser = new ShopManagerClasses.Technician();
                        tempSUser.Id = item.Id;
                        tempSUser.LoggedIn = item.LoggedIn;
                        tempSUser.LoginName = item.LoginName;
                        tempSUser.Name = item.Name;
                        tempSUser.Password = item.Password;
                        tempSUser.Skill = item.Skill;
                        tempSUser.TargetHours = item.TargetHours;
                        tempSUser.Active = item.Active;
                        RUsers.Add(tempSUser);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "GetUsers", e.Message);
                }

            }

                return RUsers;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<ShopManagerClasses.Customer> SearchCustomerByCompanyName(string text)
        {
            List<ShopManagerClasses.Customer> results = new List<ShopManagerClasses.Customer>();
            using (var db = new mainEntities())
            {
                try
                {
                    var cust =
                        from c in db.Customers
                        where c.CompanyName == text
                        select c;
                    foreach (var item in cust)
                    {
                        ShopManagerClasses.Customer temp = new ShopManagerClasses.Customer(item.Id, item.FName, item.LName, item.SpouseID, item.CompanyName);
                        results.Add(temp);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "SearchCustomerByCompanyName", e.Message);
                }
                return results;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<ShopManagerClasses.Customer> SearchCustomerByFirstName(string text)
        {
            List<ShopManagerClasses.Customer> results = new List<ShopManagerClasses.Customer>();
            using (var db = new mainEntities())
            {
                try
                {
                    var cust =
                        from c in db.Customers
                        where c.FName == text
                        select c;
                    foreach (var item in cust)
                    {
                        ShopManagerClasses.Customer temp = new ShopManagerClasses.Customer(item.Id, item.FName, item.LName, item.SpouseID, item.CompanyName);
                        results.Add(temp);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "SearchCustomerByFirstName", e.Message);
                }
                return results;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<ShopManagerClasses.Customer> SearchCustomerByLastName(string text)
        {
            List<ShopManagerClasses.Customer> results = new List<ShopManagerClasses.Customer>();
            using (var db = new mainEntities())
            {
                try
                {
                    var cust =
                        from c in db.Customers
                        where c.LName == text
                        select c;
                    foreach (var item in cust)
                    {
                        ShopManagerClasses.Customer temp = new ShopManagerClasses.Customer(item.Id, item.FName, item.LName, item.SpouseID, item.CompanyName);
                        results.Add(temp);
                    }
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "SearchCustomerByLastName", e.Message);
                }
                return results;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<ShopManagerClasses.Customer> SearchCustomerByPhoneNumber(string text)
        {
            List<ShopManagerClasses.Customer> results = new List<ShopManagerClasses.Customer>();
            using (var db = new mainEntities())
            {
                try
                {
                    var phone =
                        from p in db.PhoneNumbers
                        where p.Number == text
                        select p;
                    foreach (var result in phone)
                    {
                        var cust =
                            from c in db.Customers
                            where c.Id == result.CustomerID
                            select c;
                        foreach (var item in cust)
                        {
                            ShopManagerClasses.Customer temp = new ShopManagerClasses.Customer(item.Id, item.FName, item.LName, item.SpouseID, item.CompanyName);
                            results.Add(temp);
                        }
                    }


                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_RETURN_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Return Data or to Connect", "SearchCustomerByPhoneNumber", e.Message);
                }
                return results;
            }
        }

        public List<ShopManagerClasses.WorkOrder> GetOrders()
        {
            List<ShopManagerClasses.WorkOrder> Jobs = new List<ShopManagerClasses.WorkOrder>();
            using (var db = new mainEntities())
            {
                var orders =
                    from o in db.WorkOrders
                    where o.Complete == 0
                    select o;
                foreach (var item in orders)
                {
                    ShopManagerClasses.WorkOrder temp = new ShopManagerClasses.WorkOrder(GetAppointmentByID(item.AppointmentID), item.Id, item.TechnicianID, false);
                    Jobs.Add(temp);
                }
            }

            return Jobs;
        }

        public void MarkOrderComplete(long idofSelected)
        {
            throw new NotImplementedException();
        }

        public void AssignJob(long techID, long orderID)
        {
            using (var db = new mainEntities())
            {
                var order =
                    from o in db.WorkOrders
                    where o.Id == orderID
                    select o;
                try
                {
                    order.First().TechnicianID = techID;
                }
                catch (Exception)
                {

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

        public void ConvertToOrder(long AppointmentID)
        {
            using (var db = new mainEntities())
            {
                WorkOrder w = new WorkOrder {
                    AppointmentID = AppointmentID,
                    Complete = 0,
                    Id = db.WorkOrders.Count() + 1,
                    TechnicianID = -1
                };
                db.WorkOrders.Add(w);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ServerErrorLogger.GetInstance().WriteError(ERR_TYPES_SERVER.DATABASE_CONNECTION_ERROR, LOGGING_LEVEL.ERROR, "Database Failed to Update changes", "ConvertToOrder", e.Message);
                }

            }
        }
    }
}
