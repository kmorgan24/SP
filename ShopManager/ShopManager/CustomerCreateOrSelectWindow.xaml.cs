using ManagerLogger;
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
using System.Windows.Shapes;
namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CustomerCreateOrSelectWindow.xaml
    /// </summary>
    public partial class CustomerCreateOrSelectWindow : Window
    {
        public CreateAppointmentWindow _parent;
        
        private List<Car> CarsList;
        private List<PhoneNumber> PhoneList;
        public CustomerCreateOrSelectWindow(CreateAppointmentWindow parent)
        {
            _parent = parent;
            InitializeComponent();

            CarsList = new List<Car>();
            PhoneList = new List<PhoneNumber>();
            
            //MainWindow.AppServer.DoWork(); // does nothing 

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> resultsList = new List<Customer>();
            ResultsPanel.Children.Clear();

            if (CompanyNameBox.Text != "")
            {
                try
                {
                    resultsList = MainWindow.AppServer.SearchCustomerByCompanyName(CompanyNameBox.Text);
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not get Customer by company name");
                }

            }
            else if (PhoneNumberBox.Text != "")
            {
                try
                {
                    resultsList = MainWindow.AppServer.SearchCustomerByPhoneNumber(PhoneNumberBox.Text);
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not get Customer by Phone number");
                }


            }
            else if (LastNameBox.Text != "")
            {
                try
                {
                    resultsList = MainWindow.AppServer.SearchCustomerByLastName(LastNameBox.Text);
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not get Customer by Last Name");
                }

            }
            else if (FirstNameBox.Text != "")
            {
                try
                {
                    resultsList = MainWindow.AppServer.SearchCustomerByFirstName(FirstNameBox.Text);
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not get Customer by First Name");
                }

            }
            // else ignore the button push because they searched nothing

            // update the displayed customers
            foreach (Customer item in resultsList)
            {
                // add a display object to the stackpan
                ResultsPanel.Children.Add(new CustomerResultDisplay(item, this));
            }
        }

        private void AddPhoneBtn_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AddPhoneNumberWindow(_parent._customer.Id);
            win.ShowDialog();
            UpdateNumbers();
        }

        private void SaveAndContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_parent._customer == null || _parent._car == null)
            {
                // display warning some day
            }
            else
            {
                if (_parent._customer.Id == -1) // it was never set
                {
                    if (FNameEditBox.Text != "")
                    {
                        _parent._customer.FName = FNameEditBox.Text;
                    }
                    else
                    {
                        //error
                    }
                    if (LNameEditBox.Text != "")
                    {
                        _parent._customer.LName = LNameEditBox.Text;
                    }
                    else
                    {
                        //error
                    }
                    _parent._customer.CompanyName = CompanyNameEditBox.Text;


                    _parent._customer.Id = MainWindow.AppServer.CreateCustomer(_parent._customer.CompanyName, _parent._customer.FName, _parent._customer.LName, _parent._customer.SpouseID);
                    
                }
                else
                {
                    // this would be where updating customer info would occur in the future
                }
                this.Close();
            }
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AddCarWindow(_parent._customer.Id);
            win.ShowDialog();
            UpdateCars();
        }

        public void UpdateCars()
        {
            CarsList = MainWindow.AppServer.GetCarsByCustomerID(_parent._customer.Id);
            CarStackpanel.Children.Clear();
            foreach (Car item in CarsList)
            {
                CarStackpanel.Children.Add(new CarDisplay(item, this));
            }
        }

        public void UpdateNumbers()
        {
            PhoneList = MainWindow.AppServer.GetCustomerPhoneNumbersByCustomerID(_parent._customer.Id);
            foreach (PhoneNumber item in PhoneList)
            {
                TextBlock temp = new TextBlock();
                temp.Text = item.Number;
                PhoneNumberDisplay.Children.Add(temp);
            }
        }
        public void UpdateCustomerDisplay()
        {
            FNameEditBox.Text = _parent._customer.FName;
            LNameEditBox.Text = _parent._customer.LName;
            CompanyNameEditBox.Text = _parent._customer.CompanyName;
        }
    }
}
