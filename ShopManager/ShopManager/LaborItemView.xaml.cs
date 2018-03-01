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
using ShopManagerClasses;

namespace ShopManager
{
    /// <summary>
    /// Interaction logic for LaborItemView.xaml
    /// </summary>
    public partial class LaborItemView : UserControl
    {
        private LaborItem item;

        public LaborItemView()
        {
            InitializeComponent();
        }

        public LaborItemView(LaborItem item)
        {
            InitializeComponent();
            this.item = item;
            ShortDescBox.Text = item.Description;
            LongDescBox.Text = item.LongDescription;
            HoursBox.Content = item.Hours.ToString();
        }
    }
}
