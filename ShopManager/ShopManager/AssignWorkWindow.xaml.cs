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
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for AssignWorkWindow.xaml
    /// </summary>
    public partial class AssignWorkWindow : Window
    {
        private List<Technician> Users;
        long WorkOrderid;
        double Hours;

        public AssignWorkWindow(long WorkOrderID, double hours, List<Technician> users)
        {
            InitializeComponent();
            Users = users;
            WorkOrderid = WorkOrderID;
            Hours = hours;

            foreach (var item in Users)
            {
                TechStack.Children.Add(new TechHoursAssignmentView(item.Name, Hours, item.TargetHours, WorkOrderid, item.Id, MainWindow.AppServer.GetAssignedJobs(item.Id)));
            }
        }
    }
}
