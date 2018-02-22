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
using ManagerLogger;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CreateAppointmentWindow.xaml
    /// </summary>
    public partial class CreateAppointmentWindow : Window
    {
        private List<string> _notes;
        private List<LaborItem> _labor;
        private Customer _customer;
        private Car _car;
        private List<Date> _dates;
        

        public CreateAppointmentWindow()
        {
            InitializeComponent();
            _notes = new List<string>();
            _labor = new List<LaborItem>();
            _customer = new Customer();
            _car = new Car();
            _dates = new List<Date>();
            
        }
        

        private void AddNotesBtn_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = new TextBox();
            t.TextWrapping = TextWrapping.WrapWithOverflow;
            t.AcceptsReturn = true;
            t.AcceptsTab = true;
            t.MinHeight = 100;
            
            NotesListBox.Children.Add(t);
            ScrollViewer s = NotesListBox.Parent as ScrollViewer;
            s.ScrollToBottom();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //confirm intent if save then...
            // create the appointment and put into the DB
            //MainWindow.AppServer.CreateAppointment();
        }

        private void AddLaborItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AddLaborItemWindow(_labor);
            win.ShowDialog();
            UpdateUI();     //that seems to work as intended for now (ChangeLater)
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            Window win = new CustomerCreateOrSelectWindow(_customer, _car);
            win.ShowDialog();
            // this code waits for the dialog to close brfore continuing so it is safe to update display here
            // add code to display customer
            CustomerName.Content = _customer.FName + " " + _customer.LName;
            CarInfo.Content = _car.Year + " " + _car.Make + " " + _car.Model;
        }
        private void UpdateUI()
        {
            LaborItemsListBox.Children.Clear();
            foreach (LaborItem item in _labor)
            {
                LaborItemsListBox.Children.Add(new LaborItemView(item));
            }
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment(_customer, _car, _labor, _notes, _dates );
            //Send to server
            try
            {
                MainWindow.AppServer.CreateAppointmentFromClass(a);
            }
            catch (Exception ex)
            {
                UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not create appointment" + a);
            }
            
            this.Close();
        }
    }
}
