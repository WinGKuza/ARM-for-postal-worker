using ARM_for_postal_worker.Classes;
using ARM_for_postal_worker.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;


namespace ARM_for_postal_worker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textbox_login.Text, password = passwordbox_password.Password;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                List<Account> accounts = SaveLoadAccount.Accounts();
                if (ForLogin.TryToLogin(login, password, accounts))
                {
                    // Переход на след окно
                    Main main = new Main();
                    main.Show();
                    this.Close();
                }
            } 
            else
            {
                MessageBox.Show("Логин и/или пароль не могут быть пустыми!");
            }
        }
    }
}
