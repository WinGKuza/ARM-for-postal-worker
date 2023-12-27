using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    internal class DataValid
    {
        internal static bool IsValidNumber(string phone)
        {
            string pattern = @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}";
            Match isMatch = Regex.Match(phone, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        internal static bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        internal static bool IsValidName(string name)
        {
            string pattern = @"[а-яёА-ЯË]{2,20}";
            Match isMatch = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}