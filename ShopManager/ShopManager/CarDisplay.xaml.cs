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
        public CustomerCreateOrSelectWindow _parent;
        public CarDisplay(Car car, CustomerCreateOrSelectWindow parent)
        {
            InitializeComponent();
            _car = car;
            _parent = parent;
            YearMakeModel.Content = car.Year + " " + car.Make + " " + car.Model;
            Vin.Content = car.Vin;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _parent._parent._car = this._car;
        }
    }
}
