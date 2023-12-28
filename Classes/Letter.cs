using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    public enum TypeLetter { Letter, Parcel, Package } // Письмо, Бандероль, Посылка
    public class Letter
    {
        private double weight;
        public TypeLetter TypeLetter { get; set; } = TypeLetter.Letter;
        public Person ToPerson { get; set; }
        public Person FromPerson { get; set; }
        public double Weight { get { return weight; } set { if (value > 0) weight = value; else throw new InvalidDataException("Неверный вес!"); } }
        
        public Letter(Person To, Person From, TypeLetter TypeL, double weight) {
            ToPerson = To;
            FromPerson = From;
            TypeLetter = TypeL;
            Weight = weight;
        }
        public Letter() { }
        public override string ToString()
        {
            return TypeToStr()+" ("+FromPerson.LastName+"->"+ToPerson.LastName+" Вес: "+Weight.ToString()+" кг.)";
        }
        public string TypeToStr()
        {
            string[] TypeL = { "Письмо", "Бандероль", "Посылка" };
            return TypeL[(int)TypeLetter];
        }
    }
}
