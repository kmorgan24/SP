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

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for CustomerResultDisplay.xaml
    /// </summary>
    public partial class CustomerResultDisplay : UserControl
    {
        public Customer _cust;
        public CustomerResultDisplay(Customer cust)
        {
            _cust = cust;
            InitializeComponent();
        }
    }
}