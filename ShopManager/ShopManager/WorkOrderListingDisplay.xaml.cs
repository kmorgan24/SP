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
    /// Interaction logic for WorkOrderListingDisplay.xaml
    /// </summary>
    public partial class WorkOrderListingDisplay : UserControl
    {
        public Appointment App;
        public int Complete;
        public int Total;
        public double Hours;
        public long OrderID;

        public WorkOrderListingDisplay()
        {
            InitializeComponent();
        }
        public WorkOrderListingDisplay(Appointment app, long orderID, int complete, int total, double hours)
        {
            InitializeComponent();
            App = app;
            Complete = complete;
            Total = total;
            Hours = hours;
            OrderID = orderID;

            NameLabel.Content = app._customer.FName +" " + app._customer.LName;
            CarLabel.Content = app._car.Year + " " + app._car.Make + " " + app._car.Model;
            CompletenessLabel.Content = complete + " of " + total;
            HoursLabel.Content = hours;
            JobStatusLabel.Content = "In Progress";
            foreach (var item in app.Labor)
            {
                LaborDescriptionsBox.Text += item.Description + Environment.NewLine;
            }
        }
    }
}
