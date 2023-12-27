using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    internal class SendTo
    {
        internal static void Send(Sending s)
        {
            List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
            sendings.Add(s);
            SaveLoadSendings.SerializeSendings(sendings);
        }
        internal static uint MakeId()
        {
            Random random = new Random();
            List<Sending> sendings = SaveLoadSendings.DeserializeSendings();
            bool f = true;
            uint id = 0;
            while (f)
            {
                f = false;
                id = (uint)random.Next(100000, 1000000);
                foreach (Sending sending in sendings)
                {
                    if (sending.Id == id) f = true; break;
                }
                if (!f) break;
            }
            return id;
        }
    }
}
