﻿using System;
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
using ManagerLogger;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for DayView.xaml
    /// </summary>
    public partial class DayView : UserControl
    {
        public DayView()
        {
            InitializeComponent();
            labelDay.Content = MainWindow.CurrentWorkingDate.Date;
            foreach (Appointment item in MainWindow.AppointmentList)
            {
                try
                {
                    AppointmentStack.Children.Add(new AppointmentDisplay(item, MainWindow.CurrentWorkingDate));
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not add appointment to appointment stack" + item);                   
                }
                
            }
            
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentWorkingDate = MainWindow.CurrentWorkingDate.AddDays(-1);
            MainWindow.AppointmentList = MainWindow.AppServer.GetAppointments(MainWindow.CurrentWorkingDate);
            AppointmentStack.Children.Clear();
            labelDay.Content = MainWindow.CurrentWorkingDate.Date;
            foreach (Appointment item in MainWindow.AppointmentList)
            {
                try
                {
                    AppointmentStack.Children.Add(new AppointmentDisplay(item, MainWindow.CurrentWorkingDate));
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not add appointment to appointment stack" + item);
                }

            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentWorkingDate = MainWindow.CurrentWorkingDate.AddDays(1);
            MainWindow.AppointmentList = MainWindow.AppServer.GetAppointments(MainWindow.CurrentWorkingDate);
            AppointmentStack.Children.Clear();
            labelDay.Content = MainWindow.CurrentWorkingDate.Date;
            foreach (Appointment item in MainWindow.AppointmentList)
            {
                try
                {
                    AppointmentStack.Children.Add(new AppointmentDisplay(item, MainWindow.CurrentWorkingDate));
                }
                catch (Exception ex)
                {
                    UserErrorLogger.GetInstance().WriteError(ERR_TYPES.USER_UNABLE_TO_READWRITE, ex.Message, "Could Not add appointment to appointment stack" + item);
                }

            }
        }
    }
}
