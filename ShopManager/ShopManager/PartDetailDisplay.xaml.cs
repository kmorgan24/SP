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
    /// Interaction logic for PartDetailDisplay.xaml
    /// </summary>
    public partial class PartDetailDisplay : UserControl
    {
        Part part;
        public PartDetailDisplay(Part p)
        {
            InitializeComponent();
            part = p;
            PartNumberBox.Text = p.PartDescription;
            PartNameBox.Text = p.PartName;
            QuantityBox.Text = p.Quantity.ToString();
            SupplierBox.Text = p.Supplier;
            InStockCheckBox.IsChecked = p.InStock == 1 ? true : false;
            OnOrderCheckBox.IsChecked = p.InStock == 2 ? true : false;
            DescriptionBox.Text = p.PartDescription;
            ListPriceBox.Text = p.ListPrice.ToString();
            CostBox.Text = p.Cost.ToString();
        }

        private void InStockCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void OnOrderCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
