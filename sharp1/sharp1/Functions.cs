using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp1
{
    partial class Program
    {
        public static bool StringChecker(string str)
        {
            if (!str.All(char.IsLetter))
            {
                Console.WriteLine("\nИспользуй лишь буквы!");
                return false;
            }
            else
                return true;
        }

        public static void ShowPost()
        {
            Console.WriteLine("1. Директор");
            Console.WriteLine("2. Менеджер");
            Console.WriteLine("3. Инженер");
            Console.WriteLine("4. Разнорабочий");
        }

        public static void ShowDepartment()
        {
            Console.WriteLine("1. Строительный");
            Console.WriteLine("2. Металлургический");
            Console.WriteLine("3. Деревообрабатывающий");
        }

        public static void ChangePost(ref Worker worker1, int newpost)
        {
                switch (newpost)
                {
                    case 1:
                    {
                        worker1.post = "Директор";
                        worker1.salary = 50000;
                        for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                        {
                            worker1.history[i] += "Директор";
                        }
                        Array.Resize(ref worker1.history, worker1.history.Length + 1);
                        break;
                    }

                    case 2:
                    {
                        worker1.post = "Менеджер";
                        worker1.salary = 20000;
                        for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                        {
                            worker1.history[i] += "Менеджер";
                        }
                        Array.Resize(ref worker1.history, worker1.history.Length + 1);
                        break;
                    }

                    case 3:
                    {
                        worker1.post = "Инженер";
                        worker1.salary = 10000;
                        for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                        {
                            worker1.history[i] += "Инженер";
                        }
                        Array.Resize(ref worker1.history, worker1.history.Length + 1);
                        break;
                    }

                    case 4:
                    {
                        worker1.post = "Разнорабочий";
                        worker1.salary = 5000;
                        for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                        {
                            worker1.history[i] += "Разнорабочий";
                        }
                        Array.Resize(ref worker1.history, worker1.history.Length + 1);
                        break;
                    }

                    default:
                        Console.WriteLine("Неверное число!");
                        break;
                }
                return;
        }

        public static void ChangeDepartment(ref Worker worker1, int newdepartment)
        {
            switch (newdepartment)
            {
                case 1:
                    worker1.department = "Строительный";
                    int v = worker1.history.Length - 1;
                    for (int i = v; i < worker1.history.Length; i++)
                    {
                        worker1.history[i] += "Строительный";
                        break;
                    }
                    Array.Resize(ref worker1.history, worker1.history.Length + 1);
                    break;

                case 2:
                    worker1.department = "Металлургический";
                    for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                    {
                        worker1.history[i] += "Металлургический";
                    }
                    Array.Resize(ref worker1.history, worker1.history.Length + 1);
                    break;

                case 3:
                    worker1.department = "Деревообрабатывающий";
                    for (int i = worker1.history.Length - 1; i < worker1.history.Length; i++)
                    {
                        worker1.history[i] += "Деревообрабатывающий";
                    }
                    Array.Resize(ref worker1.history, worker1.history.Length + 1);
                    break;

                default:
                    Console.WriteLine("Неверное число!");
                    break;
            }
            return;
        }

        public static void GetMoney(ref Worker worker1)
        {
            if (worker1.post == "Директор")
            {
                worker1.money += 50000;
                return;
            }
            if (worker1.post == "Менеджер")
            {
                worker1.money += 20000;
                return;
            }
            if (worker1.post == "Инженер")
            {
                worker1.money += 10000;
                return;
            }
            if (worker1.post == "Разнорабочий")
            {
                worker1.money += 5000;
                return;
            }
            else
                Console.WriteLine("Неверная должность!");
        }

        public static void ShowChanges(ref Worker worker1)
        {
            for (int i = 0; i < worker1.history.Length - 1; i++)
            {
                Console.WriteLine(i + 1 + ". " + worker1.history[i]);
            }
        }

        public static void FindChanges(ref Worker worker1, string change)
        {
            bool checker = false;
            for (int i = 0; i < worker1.history.Length; i++)
            {
                if (change == worker1.history[i])
                {
                    checker = true;
                }
            }
            if (checker == true)
            {
                Console.WriteLine("\nНайдено совпадение!");
                return;
            }
            else
            {
                Console.WriteLine("\nСовпадений не найдено!");
                return;
            }
        }
        

        public static void CompareWorkers(ref Worker worker1, ref Worker worker2)
        {
            int position1 = 0, position2 = 0;
            if (worker1.post == "Директор")
            {
                position1 = 4;
            }
            else if (worker1.post == "Менеджер")
            {
                position1 = 3;
            }
            else if (worker1.post == "Инженер")
            {
                position1 = 2;
            }
            else if (worker1.post == "Разнорабочий")
            {
                position1 = 1;
            }
            else
            {
                position1 = 0;
            }
            if (worker2.post == "Директор")
            {
                position2 = 4;
            }
            else if (worker2.post == "Менеджер")
            {
                position2 = 3;
            }
            else if (worker2.post == "Инженер")
            {
                position2 = 2;
            }
            else if (worker2.post == "Разнорабочий")
            {
                position2 = 1;
            }
            else
            {
                position2 = 0;
            }
            if (position1 > position2)
            {
                Console.WriteLine(worker1.post + " " + worker1.name + " " + worker1.lastname + " старше по должности чем " + worker2.post + " " + worker2.name + " " + worker2.lastname);
            }
            else if (position1 == position2)
            {
                Console.WriteLine(worker1.post + " " + worker1.name + " " + worker1.lastname + " имеет такую же должность как " + worker2.post + " " + worker2.name + " " + worker2.lastname);
            }
            else
            {
                Console.WriteLine(worker1.post + " " + worker1.name + " " + worker1.lastname + " младше по должности чем " + worker2.post + " " + worker2.name + " " + worker2.lastname);
            }
        }
    }
}