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
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CustomerResultDisplay.xaml
    /// </summary>
    public partial class CustomerResultDisplay : UserControl
    {
        public Customer _cust;
        private CustomerCreateOrSelectWindow _parent;
        public CustomerResultDisplay(Customer cust, CustomerCreateOrSelectWindow parent)
        {
            _cust = cust;
            _parent = parent;
            InitializeComponent();
            CustomerName.Content = _cust.FName + " " + _cust.LName;
            CompanyName.Content = _cust.CompanyName;
        }

        private void Selectbtn_Click(object sender, RoutedEventArgs e)
        {
            _parent._parent._customer = _cust;
            _parent.UpdateCars();
            _parent.UpdateNumbers();
            _parent.UpdateCustomerDisplay();
        }
    }
}
