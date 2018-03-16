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
        public List<LaborItem> _labor;
        public Customer _customer;
        public Car _car;
        public List<Date> _dates;
        public double _hourstotal;
        

        public CreateAppointmentWindow()
        {
            InitializeComponent();
            _hourstotal = 0;
            _notes = new List<string>();
            _labor = new List<LaborItem>();
            _customer = new Customer();
            _car = new Car();
            _dates = new List<Date>();
            DateSelectorPanel.Orientation = Orientation.Horizontal;
            for (int i = 0; i < 5; i++)
            {
                DateSelectorPanel.Children.Add(new DateSelectorDisplay(this, DateTime.Now.AddDays(i), MainWindow.AppServer.GetMaxHours(), MainWindow.AppServer.GetCurrentHours(DateTime.Now.AddDays(i))));
            }
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
            Window win = new AddLaborItemWindow(this);
            win.ShowDialog();
            UpdateUI();     //that seems to work as intended for now (ChangeLater)
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            Window win = new CustomerCreateOrSelectWindow(this);
            win.ShowDialog();
            // this code waits for the dialog to close brfore continuing so it is safe to update display here
            // add code to display customer
            
            CustomerName.Content = _customer.FName + " " + _customer.LName;
            CarInfo.Content = _car.Year + " " + _car.Make + " " + _car.Model;
        }
        private void UpdateUI()
        {
            int hours = 0;
            LaborItemsListBox.Children.Clear();
            foreach (LaborItem item in _labor)
            {
                LaborItemsListBox.Children.Add(new LaborItemView(item));
                hours += (int)item.Hours;
            }
            foreach (DateSelectorDisplay item in DateSelectorPanel.Children)
            {
                item.ShowWithHours(hours);
            }
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox item in NotesListBox.Children)
            {
                _notes.Add(item.Text);
            }
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
        public void UpdateHoursSelector()
        {

            //HoursPanel.Children.Clear();

            //for (int i = 0; i < _dates.Count; i++)
            //{
            //    List<int> values = new List<int>();
            //    for (int i2 = 0; i2 < _hourstotal; i2++)
            //{
            //    values.Add(i2);
            //}
            //    ListBox temp = new ListBox();

            //    temp.ItemsSource = values;
            //    //temp.SelectedIndex = (int)_hourstotal / _dates.Count;
            //    temp.SelectionChanged += Temp_SelectionChanged;
            //    temp.MinWidth = 150;
            //    HoursPanel.Children.Add(temp);
            //}
            foreach (var item in _dates)
            {
                item.Hours = ((int)(_hourstotal / _dates.Count()) + 1);
            }
        }

        private void Temp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
