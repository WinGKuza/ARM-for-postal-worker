using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ARM_for_postal_worker.Classes
{
    internal class SaveLoadAccount
    {
        internal static List<Account> Accounts()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Account>));
            const string path = @"..\..\Data\Accounts.xml";
            List<Account> accounts = new List<Account>();

            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                accounts = xmlSerializer.Deserialize(writer) as List<Account>;
            }
            return accounts;
        }
    }
}
