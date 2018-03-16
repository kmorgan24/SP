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
    /// Interaction logic for WeekView.xaml
    /// </summary>
    public partial class WeekView : UserControl
    {
        public WeekView()
        {
            InitializeComponent();
            foreach (var item in MainWindow.AppointmentList)
            {
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals( DateTime.Now.AddDays(-2).Date.ToString()))
                    {
                        Stack1.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(-2)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(-1).Date.ToString()))
                    {
                        Stack2.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(-1)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(0).Date.ToString()))
                    {
                        Stack3.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(0)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(1).Date.ToString()))
                    {
                        Stack4.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(1)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(2).Date.ToString()))
                    {
                        Stack5.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(2)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(3).Date.ToString()))
                    {
                        Stack6.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(3)));
                    }
                }
                foreach (var item2 in item.Dates)
                {
                    if (item2.Date1.Equals(DateTime.Now.AddDays(4).Date.ToString()))
                    {
                        Stack7.Children.Add(new AppointmentDisplay(item, DateTime.Now.AddDays(4)));
                    }
                }
            }
            Label1.Content = DateTime.Now.AddDays(-2).DayOfWeek;
            Label2.Content = DateTime.Now.AddDays(-1).DayOfWeek;
            Label3.Content = DateTime.Now.AddDays(0).DayOfWeek;
            Label4.Content = DateTime.Now.AddDays(1).DayOfWeek;
            Label5.Content = DateTime.Now.AddDays(2).DayOfWeek;
            Label6.Content = DateTime.Now.AddDays(3).DayOfWeek;
            Label7.Content = DateTime.Now.AddDays(4).DayOfWeek;
            
        }
    }
}
