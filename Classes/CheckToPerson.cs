using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ARM_for_postal_worker.Classes
{
    internal class CheckToPerson
    {
        internal static bool Check(ListView sendingsList, string toFirstName, string toLastName, string toPatronymic, string toAddress, uint toIndex, string toPhone, string toEmail, string fromFirstName, string fromLastName, string fromPatronymic, string fromAddress, uint fromIndex, string fromPhone, string fromEmail)
        {
            if (sendingsList.Items.Count > 0)
            {
                Person person = ((Letter)sendingsList.Items[0]).ToPerson, person_;
                if (toFirstName != person.FirstName || toLastName != person.LastName || toPatronymic != person.Patronymic || toAddress != person.Address || toIndex != person.Index || toPhone != person.Phone || toEmail != person.Email)
                {
                    MessageBox.Show("Нельзя добавить посылки для другого человека в это отправление!");
                    return false;
                }
                List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
                foreach (Sending sending in sendings)
                {
                    person = sending.Letters[0].ToPerson;
                    person_ = sending.Letters[0].FromPerson;
                    if ((((toEmail == person.Email || toPhone == person.Phone) && (toFirstName != person.FirstName || toLastName != person.LastName || toPatronymic != person.Patronymic || toAddress != person.Address || toIndex != person.Index)) || ((fromEmail == person.Email || fromPhone == person.Phone) && (fromFirstName != person.FirstName || fromLastName != person.LastName || fromPatronymic != person.Patronymic || fromAddress != person.Address || fromIndex != person.Index))) || (((toEmail == person_.Email || toPhone == person_.Phone) && (toFirstName != person_.FirstName || toLastName != person_.LastName || toPatronymic != person_.Patronymic || toAddress != person_.Address || toIndex != person_.Index)) || ((fromEmail == person_.Email || fromPhone == person_.Phone) && (fromFirstName != person_.FirstName || fromLastName != person_.LastName || fromPatronymic != person_.Patronymic || fromAddress != person_.Address || fromIndex != person_.Index))))
                    {
                        MessageBox.Show("Эта почта и(или) номер телефона записаны на другого человека!");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
