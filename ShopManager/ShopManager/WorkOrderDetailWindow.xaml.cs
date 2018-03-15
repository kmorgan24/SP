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
    /// Interaction logic for WorkOrderDetailWindow.xaml
    /// </summary>
    public partial class WorkOrderDetailWindow : Window
    {
        WorkOrder Order;
        List<int> HoursList;
        public WorkOrderDetailWindow(WorkOrder order)
        {
            InitializeComponent();
            Order = order;

            HoursList = new List<int>();
            for (int i = 0; i < 75; i++)
            {
                HoursList.Add(i);
            }
            listBox.ItemsSource = HoursList;


            // Customer Info Setup
            FNameTxtBox.Text = Order.app._customer.FName;
            LNameTxtBox.Text = Order.app._customer.LName;
            CompanyNameTxtBox.Text = Order.app._customer.CompanyName;
            //Add Phone Numbers
            MainWindow.AppServer.GetCustomerPhoneNumbersByCustomerID(Order.app._customer.Id);

            //Car Info Setup
            YearTxtBox.Text = Order.app._car.Year.ToString();
            MakeTxtBox.Text = Order.app._car.Make;
            ModelTxtBox.Text = Order.app._car.Model;
            VinTxtBox.Text = Order.app._car.Vin;
            ProdDateTxtBox.Text = Order.app._car.ProdDate;
            StateTxtBox.Text = Order.app._car.State;
            PlateTxtBox.Text = Order.app._car.Plate;


            // Notes Setup
            foreach (var item in Order.app.Notes)
            {
                NotesStack.Children.Add(new NoteDetailDisplay(item));
            }

            // Labor
            foreach (var item in Order.app.Labor)
            {
                LaborItemStack.Children.Add(new LaborItemDetailDisplay(item));
            }

            // Parts

        }

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note temp = new Note();
            temp.Active = 1;
            temp.Visible = 1;
            temp.AppointmentID = Order.app.Id;
            temp.CarID = Order.app._car.Id;
            temp.CustomerID = Order.app._customer.Id;
            temp.Description = NewNoteText.Text;
            temp.Id = MainWindow.AppServer.AddNoteToOrder(temp);
            NotesStack.Children.Add(new NoteDetailDisplay(temp));
        }

        private void AddLaborBtn_Click(object sender, RoutedEventArgs e)
        {
            LaborItem l = new LaborItem();
            l.Description = ShortDescriptionTxtBox.Text;
            l.LongDescription = LongDescriptionTxtBox.Text;
            // double decVal = double.Parse((string)listBox2.SelectedValue);
            //double temp = (int)listBox.SelectedValue + decVal;
            l.Hours = (int)listBox.SelectedValue;
            l.Complete = false;
            l.AppointmentID = Order.app.Id;
            l.Id = MainWindow.AppServer.AddLaborToOrder(l);
        }

        private void AddPartBtn_Click(object sender, RoutedEventArgs e)
        {
            Part p = new Part();
            p.WorkOrderID = Order.Id;
            p.Supplier = SupplierBox.Text;
            try
            {
                p.Quantity = double.Parse(QuantityBox.Text);
            }
            catch (Exception)
            {
                p.Quantity = 0;
            }
            p.PartNumber = PartNumberBox.Text;
            p.PartName = PartNameBox.Text;
            p.PartDescription = DescriptionBox.Text;
            try
            {
                p.ListPrice = double.Parse(ListPriceBox.Text);
            }
            catch (Exception)
            {
                p.ListPrice = 0;
            }
            p.InStock = ((bool)InStockCheckBox.IsChecked ? 2 : 0);
            p.InStock = ((bool)InStockCheckBox.IsChecked ? 1 : 0);  // if both record as in stock
            p.Id = MainWindow.AppServer.AddPartToOrder(p);
        }
    }
}
