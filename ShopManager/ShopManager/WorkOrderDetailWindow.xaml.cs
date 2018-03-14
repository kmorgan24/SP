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
        public WorkOrderDetailWindow(WorkOrder order)
        {
            InitializeComponent();
            Order = order;
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


            // Labor


            // Parts

        }
    }
}
