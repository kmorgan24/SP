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

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IManagerService Server;
        private static ChannelFactory<IManagerService> _channel;
        public MainWindow()
        {
            InitializeComponent();
            _channel = new ChannelFactory<IManagerService>("ManagerEndpoint");
            Server = _channel.CreateChannel();
        }
    }
}
