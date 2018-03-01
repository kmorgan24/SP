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
    /// Interaction logic for DateSelectorDisplay.xaml
    /// </summary>
    public partial class DateSelectorDisplay : UserControl
    {
        private CreateAppointmentWindow _parent;
        private DateTime _Date;
        private int MaxHours;
        private int CurrentHours;
        int HoursToShow;

        public DateSelectorDisplay(CreateAppointmentWindow par, DateTime day, int Maxhours, int currentHours)
        {
            InitializeComponent();
            _parent = par;
            _Date = day;
            MaxHours = Maxhours;
            CurrentHours = currentHours;
            HoursToShow = 0;

            DayLabel.Content = _Date.DayOfWeek;
            DateLabel.Content = _Date.Date;
            HoursBar.Value = CurrentHours;
            HoursBar.Maximum = MaxHours;
            HoursLabel.Content = MaxHours - CurrentHours;
            if (CurrentHours/MaxHours < .75)
            {
                HoursBar.Foreground = Brushes.Green;
            }
            else if (CurrentHours / MaxHours > .75)
            {
                HoursBar.Foreground = Brushes.Yellow;
            }
            else
            {
                HoursBar.Foreground = Brushes.Red;
            }
        }
        public void ShowWithHours(int HoursToShow)
        {
            this.HoursToShow = HoursToShow;
            HoursBar.Value = CurrentHours + HoursToShow;
            HoursLabel.Content = (CurrentHours + HoursToShow);
            if ((CurrentHours + HoursToShow) / MaxHours < .75)
            {
                HoursBar.Foreground = Brushes.Green;
            }
            else if ((CurrentHours + HoursToShow) / MaxHours > .75)
            {
                HoursBar.Foreground = Brushes.Yellow;
            }
            else
            {
                HoursBar.Foreground = Brushes.Red;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Date d = new Date();
            d.Date1 = _Date.Date.ToString();
            d.Hours = HoursToShow;
            
            _parent._dates.Add(d);

            //_parent._dates = _parent._dates.Distinct() as List<ShopManagerClasses.Date>;
            this.Background = Brushes.LightBlue;
        }
    }
}
