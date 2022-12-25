using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace sharp2
{
    public class Factory : IComparable
    {
        public string name;
        public int workshops => l_workshops.Count;
        public int workers => l_workers.Count;
        public int masters => l_masters.Count;
        public int money_by_worker;
        public int money_by_master;
        public int details_quantity;
        public List<Workshop> l_workshops;
        public List<Worker> l_workers;
        public List<Master> l_masters;
        private Dictionary<string, Person> d_person;

        public Factory(string name, int money_by_worker, int money_by_master, int details_quantity)
        {
            this.name = name;
            this.money_by_worker = money_by_worker;
            this.money_by_master = money_by_master;
            this.details_quantity = details_quantity;
            l_workshops = new List<Workshop>();
            l_workers = new List<Worker>();
            l_masters = new List<Master>();
            d_person = new Dictionary<string, Person>();
        }

        public Factory(string name, int workshops, int workers, int masters, int money_by_worker, int money_by_master, int details_quantity)
        {
            this.name = name;
            this.money_by_worker = money_by_worker;
            this.money_by_master = money_by_master;
            this.details_quantity = details_quantity;
            l_workshops = new List<Workshop>();
            l_workers = new List<Worker>();
            l_masters = new List<Master>();
            d_person = new Dictionary<string, Person>();
        }

        public Factory() 
        {
            l_workshops = new List<Workshop>();
            l_masters = new List<Master>();
            l_workers = new List<Worker>();
            d_person = new Dictionary<string, Person>();
        }

        public Factory(Factory factory, List<Workshop> list_workshop, List<Master> list_master, List<Worker> list_worker)
        {
            this.name = factory.name;
            this.money_by_worker = factory.money_by_worker;
            this.money_by_master = factory.money_by_master;
            this.l_workshops = list_workshop;
            this.l_masters = list_master;
            this.l_workers = list_worker;
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

        public void AddPerson(Person person)
        {
            if (person is null)
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            try
            {
                d_person.Add(person.number, person);
            }
            catch
            {
            }
        }

        public void AddWorker(Worker worker)
        {
            if (worker is null)
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            try
            {
                d_person.Add(worker.number, worker);
            }
            catch
            {
            }
        }

        public void AddMaster(Master master)
        {
            if (master is null)
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            try
            {
                d_person.Add(master.number, master);
            }
            catch
            {
            }
        }
    }
}
