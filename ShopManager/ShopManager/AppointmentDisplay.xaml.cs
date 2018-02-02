using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for AppointmentDisplay.xaml
    /// </summary>
    public partial class AppointmentDisplay : UserControl
    {
        private Appointment item;

        public AppointmentDisplay()
        {
            InitializeComponent();
        }

        public AppointmentDisplay(Appointment item, DateTime dispDay)
        {
            InitializeComponent();
            this.item = item;
            CustomerName.Content = item._customer.FName + " " + item._customer.LName;
            Car.Content = item._car.Year + " " + item._car.Make + " " + item._car.Model;
            double hours = 0;
            foreach (var day in item.Dates)
            {
                if (day.Date1 == dispDay.ToString())
                {
                    hours += day.Hours;
                }
            }
            Hours.Content = hours.ToString();
        }
    }
}
