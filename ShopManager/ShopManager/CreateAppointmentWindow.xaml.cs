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
using Server;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CreateAppointmentWindow.xaml
    /// </summary>
    public partial class CreateAppointmentWindow : Window
    {
        private List<string> _notes;
        private List<LaborItem> _labor;
        IManagerService AppServer;
        public CreateAppointmentWindow(IManagerService server)
        {
            InitializeComponent();
            AppServer = server;
            _notes = new List<string>();
            _labor = new List<LaborItem>();
        }
        

        private void AddNotesBtn_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = new TextBox();
            t.TextWrapping = TextWrapping.WrapWithOverflow;
            t.AcceptsReturn = true;
            t.AcceptsTab = true;
            t.MinHeight = 100;
            
            NotesListBox.Children.Add(t);
            ScrollViewer s = NotesListBox.Parent as ScrollViewer;
            s.ScrollToBottom();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // create the appointment and put into the DB
            //AppServer.CreateAppointment();
        }
    }
}
