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
    /// Interaction logic for ServiceAdvisorWindow.xaml
    /// </summary>
    public partial class ServiceAdvisorWindow : Window
    {
        public ServiceAdvisorWindow()
        {
            InitializeComponent();
            Button b = new Button();
            b.Content = new WorkOrderListingDisplay();
            UnassignedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            UnassignedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            UnassignedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            UnassignedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            UnassignedStackPanel.Children.Add(b);

            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);
            b = new Button();
            b.Content = new WorkOrderListingDisplay();
            CompletedStackPanel.Children.Add(b);

            InProgressStackPanel.Children.Add(new TechAssignedWorkDisplay());
            InProgressStackPanel.Children.Add(new TechAssignedWorkDisplay());
            InProgressStackPanel.Children.Add(new TechAssignedWorkDisplay());
            InProgressStackPanel.Children.Add(new TechAssignedWorkDisplay());
        }
        public ServiceAdvisorWindow(string name, List<WorkOrder> orders)
        {
            InitializeComponent();

        }

        private void AssignJobsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoAssignJobsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
