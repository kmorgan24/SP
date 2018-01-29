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
using System.Windows.Shapes;
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for AddLaborItemWindow.xaml
    /// </summary>
    public partial class AddLaborItemWindow : Window
    {
        private List<LaborItem> _labor;

        public AddLaborItemWindow()
        {
            InitializeComponent();
        }

        public AddLaborItemWindow(List<LaborItem> _labor)
        {
            this._labor = _labor;
        }
    }
}
