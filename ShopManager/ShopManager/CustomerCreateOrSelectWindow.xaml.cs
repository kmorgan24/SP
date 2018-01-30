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
        private Customer _customer;
        private Car _car;
        public CustomerCreateOrSelectWindow(Customer cust, Car car)
        {
            _customer = cust;
            _car = car;
            InitializeComponent();
            //MainWindow.AppServer.DoWork(); // does nothing 
            
        }
    }
}
