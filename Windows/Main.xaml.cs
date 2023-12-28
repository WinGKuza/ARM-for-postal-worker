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
using System.Xml.Linq;


namespace ARM_for_postal_worker.Windows
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        uint code = 0;
        Sending selected = null;
        public Main()
        {
            InitializeComponent();
            UpdateGetSendingsList();
        }
        void UpdateGetSendingsList()
        {
            List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
            GetSendingsList.ItemsSource = sendings;
        }
        void UpdateGetSendingsList(string str)
        {
            List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
            GetSendingsList.ItemsSource = (from s in sendings where Convert.ToString(s.Id).Contains(str.ToLower()) || s.Letters[0].ToPerson.LastName.ToLower().Contains(str.ToLower()) || (s.Letters[0].ToPerson.LastName.ToLower()+ " " + s.Letters[0].ToPerson.FirstName.ToLower()).Contains(str.ToLower()) || (s.Letters[0].ToPerson.LastName.ToLower() + " " + s.Letters[0].ToPerson.FirstName.ToLower() + " " + s.Letters[0].ToPerson.Patronymic.ToLower()).Contains(str.ToLower()) || s.Letters[0].ToPerson.Phone.ToLower().Contains(str.ToLower()) || s.Letters[0].ToPerson.Email.ToLower().Contains(str.ToLower()) select s);
        }
        private void AddLetter_Click(object sender, RoutedEventArgs e)
        {
            if (ToFirstName.Text == "" || ToLastName.Text == "" || ToAddress.Text == "" || ToIndex.Text == "" || ToPhone.Text == "" || ToEmail.Text == "" || FromFirstName.Text == "" || FromLastName.Text == "" || FromAddress.Text == "" || FromIndex.Text == "" || FromPhone.Text == "" || FromEmail.Text == "" || Weight.Text == "" || TypeBox.SelectedIndex == -1) MessageBox.Show("Введите все данные!");
            else
            {
                if (CheckToPerson.Check(SendingsList, ToFirstName.Text, ToLastName.Text, ToPatronymic.Text, ToAddress.Text, Convert.ToUInt32(ToIndex.Text), ToPhone.Text, ToEmail.Text, FromFirstName.Text, FromLastName.Text, FromPatronymic.Text, FromAddress.Text, Convert.ToUInt32(FromIndex.Text), FromPhone.Text, FromEmail.Text))
                {
                    try
                    {
                        SendingsList.Items.Add(new Letter(new Person(ToFirstName.Text, ToLastName.Text, ToAddress.Text, Convert.ToUInt32(ToIndex.Text), ToPhone.Text, ToEmail.Text, ToPatronymic.Text), new Person(FromFirstName.Text, FromLastName.Text, FromAddress.Text, Convert.ToUInt32(FromIndex.Text), FromPhone.Text, FromEmail.Text, FromPatronymic.Text), (TypeLetter)TypeBox.SelectedIndex, Convert.ToDouble(Weight.Text)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void ClearSending_Click(object sender, RoutedEventArgs e)
        {
            SendingsList.Items.Clear();
        }
        private void ClearData()
        {
            SendingsList.Items.Clear();
            ToFirstName.Text = "";
            ToLastName.Text = "";
            ToPatronymic.Text = "";
            ToAddress.Text = "";
            ToIndex.Text = "";
            ToPhone.Text = "";
            ToEmail.Text = "";
            FromFirstName.Text = "";
            FromLastName.Text = "";
            FromPatronymic.Text = "";
            FromAddress.Text = "";
            FromIndex.Text = "";
            FromPhone.Text = "";
            FromEmail.Text = "";
            Weight.Text = "";
            TypeBox.SelectedIndex = -1;
            Info.Text = "";
        }
        private void SendSending_Click(object sender, RoutedEventArgs e)
        {
            if (SendingsList.HasItems)
            {
                List<Letter> letters = new List<Letter>();
                foreach (Letter letter in SendingsList.Items) letters.Add(letter);
                SendTo.Send(new Sending(SendTo.MakeId(), letters, Status.SortingCenter));
                ClearData();
                UpdateGetSendingsList();
                MessageBox.Show("Отправлено!");
            }
            else
            {
                MessageBox.Show("Список отправлений пуст!");
            }
        }
        void ViewLetter(ListView listView)
        {
            if (listView.SelectedItem != null)
            {
                ViewLetter vl = new ViewLetter((Letter)listView.SelectedItem);
                vl.ShowDialog();
                listView.SelectedItems.Clear();
            }
        }
        private void SendingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewLetter(SendingsList);
        }

        private void FindBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGetSendingsList(FindBox.Text);
        }

        private void GetSendingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sending sending = (Sending)GetSendingsList.SelectedItem;
            if (sending != null)
            {
                Info.Text = "Отправление №" + Convert.ToString(sending.Id) + "\nКому: " + sending.Letters[0].ToPerson.LastName + " " + sending.Letters[0].ToPerson.FirstName + "\n" + sending.Letters[0].ToPerson.Patronymic + "\nОт кого: " + sending.Letters[0].FromPerson.LastName + " " + sending.Letters[0].FromPerson.FirstName + "\n" + sending.Letters[0].FromPerson.Patronymic + "\nКоличество: " + Convert.ToString(sending.Letters.Count) + "\nСтатус: ";
                SolidColorBrush color = Brushes.Black;
                switch ((int)sending.Status)
                {
                    case 0: color = Brushes.Red; break;
                    case 1: color = Brushes.Blue; break;
                    case 2: color = Brushes.Green; break;
                }
                Info.Inlines.Add(new Run(sending.StatusToStr()) { Foreground = color });
            }
        }        
        private void Button_get_sending_Click(object sender, RoutedEventArgs e)
        {
            if (GetSendingsList.SelectedItem != null)
            {
                if (((Sending)GetSendingsList.SelectedItem).Status == Status.Arrived)
                {
                    code = Gmail.SendSecureCode(((Sending)GetSendingsList.SelectedItem).Letters[0].ToPerson);
                    selected = (Sending)GetSendingsList.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Отправление ещё не прибыло!");
                    return;
                }
            }
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selected != null && code == Convert.ToUInt32(CodeBox.Text))
                {
                    List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
                    
                    sendings.Remove(selected);
                    GetSendingsList.ItemsSource = sendings;
                    SaveLoadSendings.SerializeSendings(sendings);
                    UpdateGetSendingsList();
                    code = 0;
                    MessageBox.Show("Посылка выдана!");
                }
                else
                {
                    MessageBox.Show("Неверный код!");
                }
            }
            catch { MessageBox.Show("Неверно введён код!"); }
        }
    }
}
