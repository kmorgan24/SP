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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        List<User> _users = new List<User>();
        bool isSelectedTech;
        long selectedUserID;
        int skill;
        public SettingsWindow()
        {
            InitializeComponent();
            radioButtonUser.IsChecked = true;
            isSelectedTech = false;
            radioButtonSk4.IsChecked = true;
            _users = MainWindow.AppServer.GetUsers();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (isSelectedTech)
            {
                Technician temp = new Technician();
                temp.Active = 1;
                temp.LoginName = LoginNameBox.Text;
                temp.Name = NameBox.Text;
                temp.Password = PasswordBox.Text;
                temp.Skill = skill;
                temp.TargetHours = long.Parse(TargetHoursBox.Text);


                MainWindow.AppServer.AddTechnician(temp);
            }
            else
            {
                ServiceAdvisor temp = new ServiceAdvisor();
                temp.Active = 1;
                temp.LoginName = LoginNameBox.Text;
                temp.Name = NameBox.Text;
                temp.Password = PasswordBox.Text;

                MainWindow.AppServer.AddServiceAdvisor(temp);
            }
            _users = MainWindow.AppServer.GetUsers();
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (isSelectedTech)
            {
                Technician temp = new Technician();
                temp.Active = 1;
                temp.LoginName = LoginNameBox.Text;
                temp.Name = NameBox.Text;
                temp.Password = PasswordBox.Text;
                temp.Skill = skill;
                temp.TargetHours = long.Parse(TargetHoursBox.Text);


                MainWindow.AppServer.AddTechnician(temp);
            }
            else
            {
                ServiceAdvisor temp = new ServiceAdvisor();
                temp.Active = 1;
                temp.LoginName = LoginNameBox.Text;
                temp.Name = NameBox.Text;
                temp.Password = PasswordBox.Text;

                MainWindow.AppServer.AddServiceAdvisor(temp);
            }
            _users = MainWindow.AppServer.GetUsers();
        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppServer.DeactivateUser(selectedUserID);
            _users = MainWindow.AppServer.GetUsers();
        }

        private void radioButtonUser_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonTech.IsChecked = false;
            isSelectedTech = false;
            SkillLabel.Visibility = Visibility.Collapsed;
            TargetHoursLabel.Visibility = Visibility.Collapsed;
            TargetHoursBox.Visibility = Visibility.Collapsed;
            radioButtonSk1.Visibility = Visibility.Collapsed;
            radioButtonSk2.Visibility = Visibility.Collapsed;
            radioButtonSk3.Visibility = Visibility.Collapsed;
            radioButtonSk4.Visibility = Visibility.Collapsed;
        }

        private void radioButtonTech_Checked(object sender, RoutedEventArgs e)
        {
            radioButtonUser.IsChecked = false;
            isSelectedTech = true;
            SkillLabel.Visibility = Visibility.Visible;
            TargetHoursLabel.Visibility = Visibility.Visible;
            TargetHoursBox.Visibility = Visibility.Visible;
            radioButtonSk1.Visibility = Visibility.Visible;
            radioButtonSk2.Visibility = Visibility.Visible;
            radioButtonSk3.Visibility = Visibility.Visible;
            radioButtonSk4.Visibility = Visibility.Visible;
        }


        private void radioButtonSk1_Checked(object sender, RoutedEventArgs e)
        {
            skill = 1;
        }

        private void radioButtonSk2_Checked(object sender, RoutedEventArgs e)
        {
            skill = 2;
        }

        private void radioButtonSk3_Checked(object sender, RoutedEventArgs e)
        {
            skill = 3;
        }

        private void radioButtonSk4_Checked(object sender, RoutedEventArgs e)
        {
            skill = 4;
        }
    }
}
