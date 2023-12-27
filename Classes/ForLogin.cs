using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ARM_for_postal_worker.Classes
{
    internal class ForLogin 
    {
        internal static bool TryToLogin(string login, string password, List<Account> accounts)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || accounts == null) return false;
            foreach (Account account in accounts)
            {
                if (account.Login == login && account.Password == Hash.GetHash(password)) return true;
            }
            MessageBox.Show("Неправильный логин или пароль!");
            return false;
        }
    }
}
