using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    internal class Gmail
    {
        private static MailMessage CreateMail(string name, string emailFrom, string emailTo, string subject, string body)
        {
            var from = new MailAddress(emailFrom, name);
            var to = new MailAddress(emailTo);
            var mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            return mail;
        }

        private static void SendMail(string host, int smptPort, string emailFrom, string pass, MailMessage mess)
        {
            SmtpClient smtp = new SmtpClient(host, smptPort);
            smtp.Credentials = new NetworkCredential(emailFrom, pass);
            smtp.EnableSsl = true;
            smtp.Send(mess);
        }

        public static uint SendSecureCode(Person p)
        {
            Random r = new Random();
            uint code = (uint)r.Next(1000,10000);
            string textMail = p.LastName + " " + p.FirstName + " " + p.Patronymic + ", подтвердите получение письма сказав данный код:<br><b>" + Convert.ToString(code) + "</b>";

            var mail = CreateMail("Подтвердите получение письма на почте", "pochta.nstu@gmail.com", p.Email, "PostARMSystem", textMail);
            SendMail("smtp.gmail.com", 587, "pochta.nstu@gmail.com", "wljetykzaapbpdxy", mail);
            return code;
        }
    }
}
