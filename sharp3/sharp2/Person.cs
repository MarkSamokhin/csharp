using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp2
{
    public abstract class Person
    {
        public string name;
        public string surname;
        public string patronymic;
        public string number;
        public int workshop_number;

        public Person() { }

        public Person(string name, string surname, string patronymic, string number, int workshop_number)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.number = number;
            this.workshop_number = workshop_number;
        }
    }
}
