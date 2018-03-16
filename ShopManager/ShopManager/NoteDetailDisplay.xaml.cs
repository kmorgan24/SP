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
    /// Interaction logic for NoteDetailDisplay.xaml
    /// </summary>
    public partial class NoteDetailDisplay : UserControl
    {
        Note n;
        public NoteDetailDisplay(Note note)
        {
            InitializeComponent();
            n = note;
            LongDescBox.Text = n.Description;
            Active.IsChecked = n.Active == 0 ? false : true;
            Visible.IsChecked = n.Visible == 0 ? false : true;
            
        }

        private void Visible_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Active_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
