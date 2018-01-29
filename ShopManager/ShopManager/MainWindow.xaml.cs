using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using Server;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IManagerService AppServer;
        private static ChannelFactory<IManagerService> _channel;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _channel = new ChannelFactory<IManagerService>("ManagerEndpoint");
                AppServer = _channel.CreateChannel();
            }
            catch (Exception)
            {
                //throw new InvalidOperationException();
            
            }
            BottomGrid.Children.Add(new SingleView());
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            Window w = new CreateAppointmentWindow();
            w.ShowDialog();
        }
    }
}
