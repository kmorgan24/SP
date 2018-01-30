using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerClasses
{
    public class Appointment
    {

        public long Id { get; }
        public long CustomerID { get; set; }
        public long CarID { get; set; }
        public string ProblemDescription { get; set; }

        // this class will need some data changes in order to work
        public List<Note> Notes;
        public List<LaborItem> Labor;
        public List<Date> Dates;
        private Customer _customer;
        private Car _car;
        private List<LaborItem> _labor;
        private List<string> _notes;
        private List<Date> _dates;

        public Appointment(Customer _customer, Car _car, List<LaborItem> _labor, List<string> _notes, List<Date> _dates)
        {
            this._customer = _customer;
            this._car = _car;
            this._labor = _labor;
            this._notes = _notes;
            this._dates = _dates;
        }
    }
}
