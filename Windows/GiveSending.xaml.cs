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

namespace ARM_for_postal_worker.Windows
{
    /// <summary>
    /// Логика взаимодействия для GiveSending.xaml
    /// </summary>
    public partial class GiveSending : Window
    {
        public GiveSending(uint code)
        {
            InitializeComponent();
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CodeBox.Text != "")
            {
                
            }
        }
    }
}
