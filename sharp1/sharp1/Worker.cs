using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp1
{
    internal class Worker
    {
        public string name, lastname, patronymic, post, department;
        public int salary, money;
        public string[] history;
        public Worker()
        {
        }
        public Worker(string name, string lastname, string patronymic, string post, string department, int salary, int money)
        {
            this.name = name;
            this.lastname = lastname;
            this.patronymic = patronymic;
            this.post = post;
            this.department = department;
            this.salary = salary;
            this.money = money;
        }

        public virtual void ToString()
        {
            Console.WriteLine("Имя: " + $"{name}" + ", Фамилия: " + $"{lastname}" + ", Отчество: " + $"{patronymic}" + ", Должность: " + $"{post}" + ", Отдел: " + $"{department}" + ", Зарплата: " + $"{salary}" + ", Деньги: " + $"{money}");
        }
    }
}
