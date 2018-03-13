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
using System.Windows.Shapes;
using System.Reflection;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for ServiceAdvisorWindow.xaml
    /// </summary>
    public partial class ServiceAdvisorWindow : Window
    {
        long IDofSelected = -1;
        List<Technician> Users;
        List<WorkOrder> Orders;
        public ServiceAdvisorWindow()
        {
            InitializeComponent();
            Users = MainWindow.AppServer.GetTechs();
            Orders = MainWindow.AppServer.GetOrders();
            foreach (var item in Users)
            {
                if (item is Technician)
                {
                    if (item.Active == 1)
                    {
                        InProgressStackPanel.Children.Add(new TechAssignedWorkDisplay(item as Technician));
                    }
                }
            }
            foreach (var item in Orders)
            {
                int totalCount = 0;
                int completeCount = 0;
                double hours = 0;
                foreach (var item2 in item.app.Labor)
                {
                    hours += item2.Hours;
                    if (item2.Complete)
                    {
                        completeCount++;
                    }
                    totalCount++;
                }
                if (item.TechnicianID == -1)
                {
                    Button b = new Button();
                    b.Click += ItemBtn_Click;
                    b.Content = new WorkOrderListingDisplay(item.app, item.Id, completeCount, totalCount, hours);
                    UnassignedStackPanel.Children.Add(b);
                }
                else if (totalCount == completeCount && completeCount != 0)
                {
                    Button b = new Button();
                    b.Click += ItemBtn_Click;
                    b.Content = new WorkOrderListingDisplay(item.app, item.Id, completeCount, totalCount, hours);
                    CompletedStackPanel.Children.Add(b);
                }
                else
                {
                    foreach (TechAssignedWorkDisplay item2 in InProgressStackPanel.Children)
                    {
                        if (item2.Tech.Id == item.TechnicianID)
                        {
                            item2.AddJob(item);
                        }
                    }
                }
            }





 

        }
        public ServiceAdvisorWindow(string name, List<WorkOrder> orders)
        {
            InitializeComponent();

        }

        private void AssignJobsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IDofSelected != -1)
            {
                double temp = 0;
                foreach (var item in Orders)
                {
                    if (item.Id == IDofSelected)
                    {
                        foreach (var item2 in item.app.Labor)
                        {
                            temp += item2.Hours;
                        }
                    }
                }
                Window win = new AssignWorkWindow(IDofSelected, temp, Users);
                win.ShowDialog();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IDofSelected != -1)
            {
                MainWindow.AppServer.MarkOrderComplete(IDofSelected);
            }
        }

        private void AutoAssignJobsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            WorkOrderListingDisplay w = b.Content as WorkOrderListingDisplay;
            IDofSelected = w.OrderID;
        }
    }
}
