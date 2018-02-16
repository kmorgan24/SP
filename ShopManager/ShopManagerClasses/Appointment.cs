using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Appointment
    {

        public long Id { get; set; }

        //public string ProblemDescription { get; set; } dont know where this came from probably dont need it

        // this class will need some data changes in order to work
        public List<Note> Notes;
        public List<LaborItem> Labor;
        public List<Date> Dates;
        public Customer _customer;
        public Car _car;


        // a date has the number of hours that will be taken up inside of it
        public Appointment()
        {

        }

        public Appointment(Customer _customer, Car _car, List<LaborItem> _labor, List<string> _notes, List<Date> _dates)
        {
            this._customer = _customer;
            this._car = _car;
            Labor = _labor;

            Dates = _dates;
            // construct a list of notes from the string list notes
            foreach (var item in _notes)
            {
                Note temp = new Note();
                temp.Active = 1;
                temp.CarID = _car.Id;
                temp.CustomerID = _customer.Id;
                temp.Description = item;
                temp.Visible = 1;
                Notes.Add(temp);
            }
        }
        public override string ToString()
        {
            string temp = Environment.NewLine + "Object Appointment";
            foreach (Note n in Notes)
            {
                temp += n;
            }
            foreach (LaborItem li in Labor)
            {
                temp += li;
            }
            foreach (Date d in Dates)
            {
                temp += d;
            }

            temp += _customer;

            temp += _car;

            return temp;
        }
    }
}
