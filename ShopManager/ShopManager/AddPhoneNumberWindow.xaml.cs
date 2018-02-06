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
    /// Interaction logic for AddPhoneNumberWindow.xaml
    /// </summary>
    public partial class AddPhoneNumberWindow : Window
    {
        long _customerID;
        public AddPhoneNumberWindow(long customerID)
        {
            InitializeComponent();
            _customerID = customerID;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber num = new PhoneNumber();
            num.Number = AreaCodeBox.Text + "-" + MiddleBox.Text + "-" + EndBox.Text + "x" + ExtentionBox.Text;
            num.Type = comboBox.SelectedIndex;
            MainWindow.AppServer.AddPhoneNumber(num, _customerID);
        }
    }
}
