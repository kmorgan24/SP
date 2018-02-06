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
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        long _customer;
        public AddCarWindow(long customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Car temp = new Car();
            temp.Make = MakeBox.Text;
            temp.Model = ModelBox.Text;
            temp.Owner = _customer;
            temp.Plate = PlateBox.Text;
            temp.ProdDate = ProdDateBox.Text;
            temp.State = StateBox.Text;
            temp.Vin = VinBox.Text;
            temp.Year = long.Parse(YearBox.Text);

            MainWindow.AppServer.AddCar(_customer, temp);
        }
    }
}
