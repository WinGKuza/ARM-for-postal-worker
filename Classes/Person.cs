using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARM_for_postal_worker.Classes
{
    public class Person
    {
        private string firstName, lastName, patronymic, email, phone;
        private uint index;
        public string FirstName { get { return firstName; } set { if (DataValid.IsValidName(value)) firstName = value; else throw new InvalidDataException("Неверное имя!"); } }
        public string LastName { get { return lastName; } set { if (DataValid.IsValidName(value)) lastName = value; else throw new InvalidDataException("Неверная фамилия!"); } }
        public string Patronymic { get { return patronymic; } set { if (DataValid.IsValidName(value) || value == "") patronymic = value; else throw new InvalidDataException("Неверное отчество!"); } }
        public string Address { get; set; } = "";
        public uint Index { get { return index; } set { if (value < 1000000) index = value; else throw new InvalidDataException("Неверный индекс!"); } }
        public string Phone { get { return phone; } set { if (DataValid.IsValidNumber(value)) phone = value; else throw new InvalidDataException("Неверный номер!"); } }
        public string Email { get { return email; } set { if (DataValid.IsValidEmail(value)) email = value; else throw new InvalidDataException("Неверный email!"); } }
        public Person(string fn, string ln, string addr, uint ind, string phone, string email, string pa = "")
        {
            FirstName = fn;
            LastName = ln;
            Address = addr;
            Index = ind;
            Phone = phone;
            Email = email;
            Patronymic = pa;
        }
        public Person() { }
    }
}
