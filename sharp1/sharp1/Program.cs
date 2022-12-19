using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.Drawing;

namespace sharp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.history = new string[1];
            Worker new_worker = new Worker("Али", "Амабар", "Магомедович", "Менеджер", "Деревообрабатывающий", 20000, 20000);

            string str;
            int number;
            bool flag = false;
            do
            {
                Console.WriteLine("Имя:");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Неверный формат строки!");
                    flag = false;
                }
                else
                {
                    flag = StringChecker(str);
                    worker.name = str;
                }
            } while (flag != true);

            do
            {
                Console.WriteLine("Фамилия:");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Неверный формат строки!");
                    flag = false;
                }
                else
                {
                    flag = StringChecker(str);
                    worker.lastname = str;
                }
            } while (flag != true);

            do
            {
                Console.WriteLine("Отчество:");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Неверный формат строки!");
                    flag = false;
                }
                else
                {
                    flag = StringChecker(str);
                    worker.patronymic = str;
                }
            } while (flag != true);


            do
            {
                Console.WriteLine("Должность (введите цифру):");
                ShowPost();
                try
                {
                    str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    {
                        Console.WriteLine("Неверный формат данных!");
                        flag = false;
                    }
                    else
                    {
                        number = Convert.ToInt32(str);
                        switch (number)
                        {
                            case 1:
                                {
                                    flag = true;
                                    worker.post = "Директор";
                                    worker.salary = 50000;
                                    break;
                                }
                            case 2:
                                {
                                    flag = true;
                                    worker.post = "Менеджер";
                                    worker.salary = 20000;
                                    break;
                                }
                            case 3:
                                {
                                    flag = true;
                                    worker.post = "Инженер";
                                    worker.salary = 10000;
                                    break;
                                }
                            case 4:
                                {
                                    flag = true;
                                    worker.post = "Разнорабочий";
                                    worker.salary = 5000;
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Неверное число!");
                                    flag = false;
                                    break;
                                }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный формат строки!");
                    flag = false;
                }
            } while (flag != true);

            do
            {
                Console.WriteLine("Отдел (введите цифру):");
                ShowDepartment();
                try
                {
                    str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    {
                        Console.WriteLine("Неверный формат данных!");
                        flag = false;
                    }
                    else
                    {
                        number = Convert.ToInt32(str);
                        switch (number)
                        {
                            case 1:
                                {
                                    flag = true;
                                    worker.department = "Строительный";
                                    break;
                                }
                            case 2:
                                {
                                    flag = true;
                                    worker.department = "Металлургический";
                                    break;
                                }
                            case 3:
                                {
                                    flag = true;
                                    worker.department = "Деревообрабатывающий";
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Неверное число!");
                                    flag = false;
                                    break;
                                }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный формат строки!");
                    flag = false;
                }
            } while (flag != true);

            int choose = 0;
            do
            {
                Console.WriteLine("\n" + worker.post + " " + worker.lastname + " " + worker.name + " " + worker.patronymic);
                Console.WriteLine("Отдел: " + worker.department);
                Console.WriteLine("Зарплата: " + worker.salary);
                Console.WriteLine("Деньги: " + worker.money);
                Console.WriteLine("\nВведите номер задачи: ");
                Console.WriteLine("1. Сменить должность/отдел \n2. Получить зарплату");
                Console.WriteLine("3. Найти должность/отдел в истории должностных изменений \n4. Полиморфный метод ToString");
                Console.WriteLine("5. Сравнить работников по должности \n10. Закрыть программу");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный формат числа!");
                }
                switch (choose)
                {
                    case 1:
                        {
                            int postnumber = 0;
                            int departmentnumber = 0;
                            Console.WriteLine("Новая должность (введите цифру):");
                            ShowPost();
                            try
                            {
                                postnumber = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Неверный формат данных!");
                                break;
                            }
                            ChangePost(ref worker, postnumber);
                            
                            Console.WriteLine("Новый отдел (введите цифру):");
                            ShowDepartment();
                            try
                            {
                                departmentnumber = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Неверный формат данных!");
                                break;
                            }
                            ChangeDepartment(ref worker, departmentnumber);
                            break;
                        }

                    case 2:
                        GetMoney(ref worker);
                        break;

                    case 3:
                        {
                            string changename;
                            ShowChanges(ref worker);
                            Console.WriteLine("Запрос (введите слово): \nДиректор/Менеджер/Инженер/Разнорабочий \nСтроительный/Металлургический/Деревообрабатывающий");
                            try
                            {
                                changename = Console.ReadLine();
                                FindChanges(ref worker, changename);
                            }
                            catch
                            {
                                Console.WriteLine("Неверные данные!");
                                break;
                            }
                            break;
                        }

                    case 4:
                        PolymorfClass polymorf = new PolymorfClass();
                        worker.ToString();
                        polymorf.ToString();
                        break;

                    case 5:
                        CompareWorkers(ref worker, ref new_worker);
                        break;

                    case 10:
                        Console.WriteLine("Всего доброго!");
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            } while (choose != 10);
        }
    }
}