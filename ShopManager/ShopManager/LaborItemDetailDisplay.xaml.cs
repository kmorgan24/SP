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
    /// Interaction logic for LaborItemDetailDisplay.xaml
    /// </summary>
    public partial class LaborItemDetailDisplay : UserControl
    {
        LaborItem labor;
        public LaborItemDetailDisplay(LaborItem item)
        {
            InitializeComponent();
            labor = item;
            LongDescBox.Text = item.LongDescription;
            ShortDescBox.Text = item.Description;
            HoursLabel.Content = item.Hours;
            Complete.IsChecked = item.Complete;
        }

        private void Complete_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.AppServer.MarkLaborItemComplete(labor.Id);
        }
    }
}
