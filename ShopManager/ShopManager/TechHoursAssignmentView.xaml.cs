using ShopManagerClasses;
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

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for TechHoursAssignmentView.xaml
    /// </summary>
    public partial class TechHoursAssignmentView : UserControl
    {
        double JobHours;
        long MaxHours;
        long OrderID;
        long TechID;
        string techname;
        List<WorkOrder> Orders;
        public TechHoursAssignmentView()
        {
            InitializeComponent();
        }
        public TechHoursAssignmentView(string TechName, double jobHours, long maxHours, long orderID, long techID, List<WorkOrder> currentAssignments)
        {
            InitializeComponent();
            JobHours = jobHours;
            MaxHours = maxHours;
            OrderID = orderID;
            TechID = techID;
            techname = TechName;
            Orders = currentAssignments;
            double totalCurrentHours = 0;
            foreach (var item in Orders)
            {
                double totalJobHours = 0;
                int numLaborItems = 0;
                foreach (var item2 in item.app.Labor)
                {
                    totalJobHours += item2.Hours;
                    numLaborItems++;
                }
                totalCurrentHours += totalJobHours;
                AssignedJobsStack.Children.Add(new WorkOrderListingDisplay(item, item.app, item.Id, 0, numLaborItems, totalJobHours));
            }
            TechNameLabel.Content = techname;
            HoursLabel.Content = (JobHours + totalCurrentHours) + " of " + MaxHours;
            HoursProgressBar.Minimum = 0;
            HoursProgressBar.Maximum = MaxHours;
            HoursProgressBar.Value = (JobHours + totalCurrentHours);
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppServer.AssignJob(TechID, OrderID);
        }
    }
}
