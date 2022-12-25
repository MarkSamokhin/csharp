using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp2
{
    public class Worker : Person
    {
        public const int salary = 15000;
        public bool university;

        public Worker() { }

        public Worker(string name, string surname, string patronymic, string number, int workshop_number, bool university) : base(name, surname, patronymic, number, workshop_number)
        {
            this.university = university;
        }
    }
}