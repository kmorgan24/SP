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
    /// Interaction logic for DayView.xaml
    /// </summary>
    public partial class DayView : UserControl
    {
        private DateTime displayedDate;
        public DayView(List<Appointment> data, DateTime day)
        {
            InitializeComponent();
            displayedDate = day;
            foreach (Appointment item in data)
            {
                AppointmentStack.Children.Add(new AppointmentDisplay(item, displayedDate));
            }
            
        }
    }
}
