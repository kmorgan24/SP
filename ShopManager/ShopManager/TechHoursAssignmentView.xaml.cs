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
        public TechHoursAssignmentView()
        {
            InitializeComponent();
        }
        public TechHoursAssignmentView(long jobHours, long maxHours, long orderID, long techID, List<WorkOrder> currentAssignments)
        {
            InitializeComponent();
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
