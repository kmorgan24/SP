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
    /// Interaction logic for DateChangeWindow.xaml
    /// </summary>
    public partial class DateChangeWindow : Window
    {
        Date _date;
        public DateChangeWindow(Date date)
        {
            InitializeComponent();
            _date = date;
            DateLabel.Content = _date.Date1;
            HoursLabel.Content = _date.Hours;
            for (int i = 0; i < 10; i++)
            {
                DateSelectorDisplay temp = new DateSelectorDisplay(this, date, DateTime.Now.AddDays(i), 30, 10);
                DayStack.Children.Add(temp);
            }
            
        }
    }
}
