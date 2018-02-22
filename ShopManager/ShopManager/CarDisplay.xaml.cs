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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CarDisplay.xaml
    /// </summary>
    public partial class CarDisplay : UserControl
    {
        public Car _car;
        public CarDisplay(Car car)
        {
            InitializeComponent();
            _car = car;
            YearMakeModel.Content = car.Year + " " + car.Make + " " + car.Model;
            Vin.Content = car.Vin;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CustomerCreateOrSelectWindow._car = this._car;
        }
    }
}
