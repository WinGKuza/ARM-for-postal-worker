using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ARM_for_postal_worker.Classes
{
    internal class SaveLoadSendings
    {
        internal static List<Sending> DeserializeSendings()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sending>));
            const string path = @"..\..\Data\Sendings.xml";
            List<Sending> sendings;

            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                sendings = xmlSerializer.Deserialize(writer) as List<Sending>;
            }
            return sendings;
        }
        internal static void SerializeSendings(List<Sending> sendings)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sending>));
            const string path = @"..\..\Data\Sendings.xml";
            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, sendings);
            }
        }
    }
}
