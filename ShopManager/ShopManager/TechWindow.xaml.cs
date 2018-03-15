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

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for TechWindow.xaml
    /// </summary>
    public partial class TechWindow : Window
    {
        long UserID;
        List<WorkOrder> AssignedJobs;
        public TechWindow(long userID)
        {
            InitializeComponent();
            UserID = userID;
            try
            {
                AssignedJobs = MainWindow.AppServer.GetAssignedJobs(UserID);
            }
            catch (Exception)
            {

            }
            foreach (var item in AssignedJobs)
            {
                int totalCount = 0;
                int completeCount = 0;
                double hours = 0;
                if (item.Complete == false)
                {
                    foreach (var item2 in item.app.Labor)
                    {
                        hours += item2.Hours;
                       if( item2.Complete)
                        {
                            completeCount++;
                        }
                        totalCount++;
                    }
                    if (completeCount == 0)
                    {
                        Button b = new Button();
                        b.Click += B_Click;
                        b.Content = new WorkOrderListingDisplay(item, item.app, item.Id, completeCount, totalCount, hours);
                        NewJobsStack.Children.Add(b);
                    }
                    else if (completeCount < totalCount)
                    {
                        Button b = new Button();
                        b.Click += B_Click;
                        b.Content = new WorkOrderListingDisplay(item, item.app, item.Id, completeCount, totalCount, hours);
                        IPJobsStack.Children.Add(b);
                    }
                    else
                    {
                        Button b = new Button();
                        b.Click += B_Click;
                        b.Content = new WorkOrderListingDisplay(item, item.app, item.Id, completeCount, totalCount, hours);
                        CompleteJobsStack.Children.Add(b);
                    }
                    
                }
            }
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            WorkOrderListingDisplay content = temp.Content as WorkOrderListingDisplay;
            Window win = new WorkOrderDetailWindow(content.Order);
            win.ShowDialog();
        }
    }

}
