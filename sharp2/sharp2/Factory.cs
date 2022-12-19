using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp2
{
    internal class Factory : IComparable
    {
        public string name;
        public int workshops;
        public int workers;
        public int masters;
        public int worker_salary;
        public int master_salary;
        public int money_by_worker;
        public int money_by_master;

        public Factory(string name, int workshops, int workers, int masters, int worker_salary, int master_salary, int money_by_worker, int money_by_master)
        {
            this.name = name;
            this.workshops = workshops;
            this.workers = workers;
            this.masters = masters;
            this.worker_salary = worker_salary;
            this.master_salary = master_salary;
            this.money_by_worker = money_by_worker;
            this.money_by_master = money_by_master;
        }

        public Factory(Factory factory)
        {
            this.name = factory.name;
            this.workshops = factory.workshops;
            this.workers = factory.workers;
            this.masters = factory.masters;
            this.worker_salary = factory.worker_salary;
            this.master_salary = factory.master_salary;
            this.money_by_worker = factory.money_by_worker;
            this.money_by_master = factory.money_by_master;
        }

        public static Factory operator +(Factory factory, Factory factory1)
        {
            return new Factory(factory.name, factory.workshops + factory1.workshops, factory.workers+factory1.workers, factory.masters+factory1.masters, factory.worker_salary, factory.master_salary, factory.money_by_worker, factory.money_by_master);
        }

        public void Compare(Factory factory, Factory factory1)
        {
            if (factory.workshops > factory1.workshops)
            {
                MessageBox.Show("У " + factory.name + " цехов больше на " + (factory.workshops-factory1.workshops), "Сравнение");
            }
            else if (factory.workshops < factory1.workshops)
            {
                MessageBox.Show("У " + factory.name + " цехов меньше на " + (factory1.workshops - factory.workshops), "Сравнение");
            }
            else if (factory.workshops == factory1.workshops)
            {
                MessageBox.Show("У " + factory.name + " цехов ровно как и у " + factory1.name, "Сравнение");
            }
            if (factory.workers > factory1.workers)
            {
                MessageBox.Show("У " + factory.name + " рабочих больше на " + (factory.workers - factory1.workers), "Сравнение");
            }
            else if (factory.workers < factory1.workers)
            {
                MessageBox.Show("У " + factory.name + " рабочих меньше на " + (factory1.workers - factory.workers), "Сравнение");
            }
            else if (factory.workers == factory1.workers)
            {
                MessageBox.Show("У " + factory.name + " рабочих ровно как и у " + factory1.name, "Сравнение");
            }
            if (factory.masters > factory1.masters)
            {
                MessageBox.Show("У " + factory.name + " мастеров больше на " + (factory.masters - factory1.masters), "Сравнение");
            }
            else if (factory.masters < factory1.masters)
            {
                MessageBox.Show("У " + factory.name + " мастеров меньше на " + (factory1.masters - factory.masters), "Сравнение");
            }
            else if (factory.masters == factory1.masters)
            {
                MessageBox.Show("У " + factory.name + " мастеров ровно как и у " + factory1.name, "Сравнение");
            }
        }
    }
}
