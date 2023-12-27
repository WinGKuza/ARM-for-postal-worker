using ARM_for_postal_worker.Classes;
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
    /// Логика взаимодействия для ViewLetter.xaml
    /// </summary>
    public partial class ViewLetter : Window
    {
        public ViewLetter(Letter letter)
        {
            InitializeComponent();
            if (letter != null)
            {
                To.Text = letter.ToPerson.LastName + " " + letter.ToPerson.FirstName + "\n" + letter.ToPerson.Patronymic + "\n" + letter.ToPerson.Address + ", " + Convert.ToString(letter.ToPerson.Index);
                From.Text = letter.FromPerson.LastName + " " + letter.FromPerson.FirstName + "\n" + letter.FromPerson.Patronymic + "\n" + letter.FromPerson.Address + ", " + Convert.ToString(letter.FromPerson.Index);
                Type.Text = letter.TypeToStr();
                Weight.Text = letter.Weight.ToString()+" кг.";
            }
        }
    }
}
