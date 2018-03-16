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
    /// Interaction logic for SingleView.xaml
    /// </summary>
    public partial class SingleView : UserControl
    {
        Appointment dispApp;
        public SingleView(long appId)
        {
            InitializeComponent();
            foreach (var item in MainWindow.AppointmentList)
            {
                if (item.Id == appId)
                {
                    dispApp = item;
                }
            }
            setup();
        }
        public SingleView(Appointment a)
        {
            InitializeComponent();
            dispApp = a;
            int i = 0;
            foreach (var item in MainWindow.AppointmentList)
            {
                if (item == a)
                {
                    MainWindow.IndexOfSelectedAppointment = i;
                }
                i++;
            }
            setup();
        }
        public SingleView(int indexOfAppointment)
        {
            InitializeComponent();
            dispApp = MainWindow.AppointmentList[indexOfAppointment];

            setup();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.IndexOfSelectedAppointment--;
            if (MainWindow.IndexOfSelectedAppointment < 0)
            {
                MainWindow.IndexOfSelectedAppointment = 0;
            }
            else
            {
                dispApp = MainWindow.AppointmentList[MainWindow.IndexOfSelectedAppointment];
                labelHours.Content = "";

                labelMake.Content = "";
                labelModel.Content = "";
                labelName.Content = "";
                labelYear.Content = "";
                ProblemDescriptions.Children.Clear();
                Notes.Children.Clear();
                setup();
            }


        }

        private void btnFoward_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.IndexOfSelectedAppointment++;
            if (MainWindow.IndexOfSelectedAppointment >= MainWindow.AppointmentList.Count)
            {
                MainWindow.IndexOfSelectedAppointment = MainWindow.AppointmentList.Count - 1;
            }
            else
            {
                dispApp = MainWindow.AppointmentList[MainWindow.IndexOfSelectedAppointment];
                labelHours.Content ="";

                labelMake.Content = "";
                labelModel.Content ="";
                labelName.Content = "";
                labelYear.Content = "";
                ProblemDescriptions.Children.Clear();
                Notes.Children.Clear();
                setup();

            }
        }

        private void setup()
        {
            long hours = 0;
            foreach (var item in dispApp.Dates)
            {
                hours += item.Hours;
            }
            labelHours.Content += hours.ToString();

            labelMake.Content += dispApp._car.Make;
            labelModel.Content += dispApp._car.Model;
            labelName.Content += dispApp._customer.FName + " " + dispApp._customer.LName;
            labelYear.Content += dispApp._car.Year.ToString();

            foreach (var item in dispApp.Labor)
            {
                TextBox temp = new TextBox();
                temp.Text = item.Description;
                ProblemDescriptions.Children.Add(temp);
            }
            foreach (var item in dispApp.Notes)
            {
                TextBox temp = new TextBox();
                temp.Text = item.Description;
                Notes.Children.Add(temp);
            }
        }

        private void ChangeDatesBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainWindow.AppointmentList[MainWindow.IndexOfSelectedAppointment].Dates)
            {
                Window win = new DateChangeWindow(item);
                win.ShowDialog();
                
            }
        }
    }
}
