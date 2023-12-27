using ARM_for_postal_worker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ARM_for_postal_worker.Classes
{
    public enum Status { SortingCenter, OnTheWay, Arrived } // В сортировочном центре, В пути, Прибыло
    public class Sending
    {
        public uint Id { get; set; }
        private List<Letter> letters = new List<Letter>();
        public List<Letter> Letters {  get; set; }
        public Status Status { get; set; } = Status.SortingCenter;
        public Sending() { }
        public Sending(uint id, List<Letter> letters, Status status)
        {
            Id = id;
            Letters = letters;
            Status = status;
        }
        public override string ToString()
        {
            return "Отправление №" + Convert.ToString(Id) + " (" + Letters[0].FromPerson.LastName + "->" + Letters[0].ToPerson.LastName + " Количество: " + Letters.Count.ToString() + " шт.)";
        }
        public string StatusToStr()
        {
            string[] stat = { "В сортировочном центре", "В пути", "Прибыло" };
            return stat[(int)Status];
        }
        public override bool Equals(object obj)
        {
            Sending send = (Sending)obj;
            if (send.Id == Id) { return true; }
            return false;
        }
    }
}
