﻿using ShopManagerClasses;
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
    /// Interaction logic for CustomerCreateOrSelectWindow.xaml
    /// </summary>
    public partial class CustomerCreateOrSelectWindow : Window
    {
        private Customer _customer;
        public CustomerCreateOrSelectWindow(Customer cust)
        {
            _customer = cust;
            InitializeComponent();
            //MainWindow.AppServer.DoWork(); // does nothing 
            
        }
    }
}
