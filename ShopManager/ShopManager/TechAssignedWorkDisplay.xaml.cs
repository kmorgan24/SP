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
    /// Interaction logic for TechAssignedWorkDisplay.xaml
    /// </summary>
    public partial class TechAssignedWorkDisplay : UserControl
    {
        public Technician Tech;
        public TechAssignedWorkDisplay()
        {
            InitializeComponent();
            Button b = new Button();
            b.Content = new WorkOrderListingDisplay();
            AssignedWorkPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            AssignedWorkPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            AssignedWorkPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            AssignedWorkPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            AssignedWorkPanel.Children.Add(b);
        }
        public TechAssignedWorkDisplay(Technician tech)
        {
            InitializeComponent();
            Tech = tech;
        }
        public void AddJob(WorkOrder order)
        {
            int totalCount = 0;
            int completeCount = 0;
            double hours = 0;
            foreach (var item2 in order.app.Labor)
            {
                hours += item2.Hours;
                if (item2.Complete)
                {
                    completeCount++;
                }
                totalCount++;
            }
            Button b = new Button();
            b.Content = new WorkOrderListingDisplay(order.app, order.Id, completeCount, totalCount, hours);
            AssignedWorkPanel.Children.Add(b);
        }
    }
}
