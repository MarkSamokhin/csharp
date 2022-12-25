using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp2
{
    public class Master : Person
    {
        public const int salary = 40000;
        public int courses;

        public Master() { }

        public Master(string name, string surname, string patronymic, string number, int workshop_number, int courses):base(name, surname, patronymic, number, workshop_number)
        {
            this.courses = courses;
        }
    }
}