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
            try
            {
                MainWindow.AppServer.GetCustomerPhoneNumbersByCustomerID(Order.app._customer.Id);
            }
            catch (Exception)
            {

            }


            //Car Info Setup
            YearTxtBox.Text = Order.app._car.Year.ToString();
            MakeTxtBox.Text = Order.app._car.Make;
            ModelTxtBox.Text = Order.app._car.Model;
            VinTxtBox.Text = Order.app._car.Vin;
            ProdDateTxtBox.Text = Order.app._car.ProdDate;
            StateTxtBox.Text = Order.app._car.State;
            PlateTxtBox.Text = Order.app._car.Plate;
            JobStatusText.Text = Order.Status;


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

            // Parts.
            try
            {
                foreach (var item in MainWindow.AppServer.GetPartsByOrderID(order.Id))
                {
                    PartsStack.Children.Add(new PartDetailDisplay(item));
                }
            }
            catch (Exception)
            {

            }


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
            try
            {
                temp.Id = MainWindow.AppServer.AddNoteToOrder(temp);
            }
            catch (Exception)
            {

            }

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
            try
            {
                l.Id = MainWindow.AppServer.AddLaborToOrder(l);
            }
            catch (Exception)
            {
                
            }

            LaborItemStack.Children.Add(new LaborItemDetailDisplay(l));
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
            try
            {
                p.Id = MainWindow.AppServer.AddPartToOrder(p);
            }
            catch (Exception)
            {

            }

            PartsStack.Children.Add(new PartDetailDisplay(p));
        }

        private void JobStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.AppServer.UpdateOrderStatus(Order.Id, JobStatusText.Text);
            }
            catch (Exception)
            {

            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Order.app._customer.FName = FNameTxtBox.Text;
            Order.app._customer.LName = LNameTxtBox.Text;
            Order.app._customer.CompanyName = CompanyNameTxtBox.Text;
            try
            {
                Order.app._car.Year = long.Parse(YearTxtBox.Text);
            }
            catch (Exception)
            {

            }

            Order.app._car.Make = MakeTxtBox.Text;
            Order.app._car.Model = ModelTxtBox.Text;
            Order.app._car.Vin = VinTxtBox.Text;
            Order.app._car.ProdDate = ProdDateTxtBox.Text;
            Order.app._car.State = StateTxtBox.Text;
            Order.app._car.Plate = PlateTxtBox.Text;
            Order.Status = JobStatusText.Text;
            try
            {
                MainWindow.AppServer.UpdateCarInfo(Order.app._car);
            }
            catch (Exception)
            {

            }

            try
            {
                MainWindow.AppServer.UpdateCustomerInfo(Order.app._customer);
            }
            catch (Exception)
            {

            }

        }
    }
}
