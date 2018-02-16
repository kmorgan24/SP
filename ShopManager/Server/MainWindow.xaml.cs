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
using ManagerLogger;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ManagerService _server;
        public ServerErrorLogger _logger;
        public MainWindow()
        {
            _logger = ServerErrorLogger.GetInstance();
            try
            {
                startService();
                _logger.WriteError(ERR_TYPES_SERVER.SERVER_START, LOGGING_LEVEL.INFO , "The Server Started");
            }
            catch (Exception e)
            {
                _logger.WriteError(ERR_TYPES_SERVER.SERVER_START, LOGGING_LEVEL.FATAL_ERROR, "The service failed to start", e.Message);
               
            }
            
            InitializeComponent();
            

        }
        private void startService()
        {
            _server = new ManagerService();
            ServiceHost host = new ServiceHost(_server);
            
            host.Open();
            
        }
    }
}
