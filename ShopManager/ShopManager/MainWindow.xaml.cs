using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using Server;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum CurrentViewTypes
        {
            Single,
            Day,
            Week
        }
        public static IManagerService AppServer;
        private static ChannelFactory<IManagerService> _channel;

        public static long IDOfSelectedAppointment;
        public static CurrentViewTypes CurrentView;
        public static DateTime CurrentWorkingDate;

        public static SolidColorBrush SelectedBackground = Brushes.AliceBlue;
        public static SolidColorBrush NotSelectedBackground = Brushes.Gray;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _channel = new ChannelFactory<IManagerService>("ManagerEndpoint");
                AppServer = _channel.CreateChannel();
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            
            }

            IDOfSelectedAppointment = 0;
            CurrentView = CurrentViewTypes.Day;
            CurrentWorkingDate = DateTime.Now;
            List<ShopManagerClasses.Appointment> AppointmentList = new List<ShopManagerClasses.Appointment>();
            try
            {
                AppointmentList =  AppServer.GetAppointments(CurrentWorkingDate);
            }
            catch (Exception)
            {

                throw;
            }
            BottomGrid.Children.Add(new DayView(AppointmentList, CurrentWorkingDate));
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            Window w = new CreateAppointmentWindow();
            w.ShowDialog();
        }

        private void btnSingleView_Click(object sender, RoutedEventArgs e)
        {
            btnDayView.Background = NotSelectedBackground;
            btnSingleView.Background = SelectedBackground;
            btnWeekView.Background = NotSelectedBackground;
        }

        private void btnDayView_Click(object sender, RoutedEventArgs e)
        {
            btnDayView.Background = SelectedBackground;
            btnSingleView.Background = NotSelectedBackground;
            btnWeekView.Background = NotSelectedBackground;
        }

        private void btnWeekView_Click(object sender, RoutedEventArgs e)
        {
            btnDayView.Background = NotSelectedBackground;
            btnSingleView.Background = NotSelectedBackground;
            btnWeekView.Background = SelectedBackground;
        }
    }
}
