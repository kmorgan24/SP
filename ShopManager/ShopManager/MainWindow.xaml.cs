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
using ManagerLogger;

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

        public static int IndexOfSelectedAppointment;
        public static CurrentViewTypes CurrentView;
        public static DateTime CurrentWorkingDate;

        public static List<ShopManagerClasses.Appointment> AppointmentList;

        public static SolidColorBrush SelectedBackground = Brushes.LightBlue;
        public static SolidColorBrush NotSelectedBackground = Brushes.LightGray;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _channel = new ChannelFactory<IManagerService>("ManagerEndpoint");
                AppServer = _channel.CreateChannel();
            }
            catch (Exception e)
            {
                UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_SERVER_CONNECTION_ERROR, e.Message, "Failed to open Comm chanel");
            }
            UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_GUI_LOGIN, "Program started");
            IndexOfSelectedAppointment = 0;
            CurrentView = CurrentViewTypes.Day;
            btnDayView.Background = SelectedBackground;
            CurrentWorkingDate = DateTime.Now;
            AppointmentList = new List<ShopManagerClasses.Appointment>();
            try
            {
                AppointmentList = AppServer.GetAppointments(CurrentWorkingDate);
            }
            catch (Exception e)
            {
                UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, e.Message, "Could Not get appointments List");
            }
            BottomGrid.Children.Add(new DayView());

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

            CurrentView = CurrentViewTypes.Single;

            BottomGrid.Children.Clear();
            IndexOfSelectedAppointment = 0;
            BottomGrid.Children.Add(new SingleView(0));
        }

        private void btnDayView_Click(object sender, RoutedEventArgs e)
        {
            btnDayView.Background = SelectedBackground;
            btnSingleView.Background = NotSelectedBackground;
            btnWeekView.Background = NotSelectedBackground;

            CurrentView = CurrentViewTypes.Day;
            BottomGrid.Children.Clear();
            AppointmentList = AppServer.GetAppointments(CurrentWorkingDate);
            BottomGrid.Children.Add(new DayView());
        }

        private void btnWeekView_Click(object sender, RoutedEventArgs e)
        {
            btnDayView.Background = NotSelectedBackground;
            btnSingleView.Background = NotSelectedBackground;
            btnWeekView.Background = SelectedBackground;

            CurrentView = CurrentViewTypes.Week;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Window win = new SettingsWindow();
            win.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_GUI_LOGOUT, "Program Closed");
            UserErrorLogger.GetInstance().ForceWrite();
        }

        private void btnOrdersView_Click(object sender, RoutedEventArgs e)
        {
            Window win = new ServiceAdvisorWindow();
            win.Show();
        }

        private void btnSAView_Click(object sender, RoutedEventArgs e)
        {
            Window win = new ServiceAdvisorWindow();
            win.Show();
        }

        private void btnTechView_Click(object sender, RoutedEventArgs e)
        {
            Window win = new TechWindow(2);
            win.Show();
        }

        private void btnConvertToOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppServer.ConvertToOrder(AppointmentList[IndexOfSelectedAppointment].Id);
            }
            catch (Exception)
            {

            }
            btnSAView_Click(sender, e);
        }
    }
}
