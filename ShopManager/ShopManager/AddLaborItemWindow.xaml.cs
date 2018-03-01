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
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for AddLaborItemWindow.xaml
    /// </summary>
    public partial class AddLaborItemWindow : Window
    {
        private CreateAppointmentWindow _parent;
        private List<int> HoursList;

        public AddLaborItemWindow(Window parent)
        {
            InitializeComponent();
            _parent = parent as CreateAppointmentWindow;
            HoursList = new List<int>();           
            for (int i = 0; i < 75; i++)
            {
                HoursList.Add(i);
            }
            listBox.ItemsSource = HoursList;
        }

        private void textBoxHours_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LaborItem l = new LaborItem();
            l.Description = textShortDescription.Text;
            l.LongDescription = textBoxLongDescription.Text;
           // double decVal = double.Parse((string)listBox2.SelectedValue);
            //double temp = (int)listBox.SelectedValue + decVal;
            l.Hours = (int)listBox.SelectedValue;
            _parent._labor.Add(l);
            Close();
        }
    }
}
