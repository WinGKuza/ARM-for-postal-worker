using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    public class Account
    {
        public Account() { }
        public Account(string login, string password) {
            Login = login;
            Password = password;
        }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
