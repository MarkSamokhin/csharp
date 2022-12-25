using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp2
{
    public partial class Form1 : Form
    {
        public Factory factory = new Factory("Завод #23", 30000, 80000, 1500);
        public List<Workshop> Workshops { get; set; }
        public List<Master> Masters { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Person> Persons { get; set; }

        
        public Form1()
        {
            Workshops = new List<Workshop>();
            Masters = new List<Master>();
            Workers = new List<Worker>();
            Persons = new List<Person>();
            Workshops.Add(new Workshop(1, 200, 200, 100, 100, 0, 0));
            Workshops.Add(new Workshop(2, 150, 150, 75, 75, 0, 0));
            Workshops.Add(new Workshop(3, 100, 100, 50, 50, 0, 0));
            Workshops.Add(new Workshop(4, 50, 50, 25, 25, 0, 0));
            Workshops.Add(new Workshop(5, 25, 25, 12, 13, 0, 0));
            InitializeComponent();
            
        }

        private void GetAll()
        {
            factory.l_workshops = Workshops;
            foreach (var person in Persons)
            {
                factory.AddPerson(person);
            }
            factory.l_masters = Masters;
            foreach (var master in Masters)
            {
                factory.AddPerson(master);
            }
            factory.l_workers = Workers;
            foreach (var worker in Workers)
            {
                factory.AddPerson(worker);
            }
            dataGridView1.Rows.Add(factory.name, factory.workshops, factory.workers, factory.masters, factory.money_by_worker, factory.money_by_master, factory.details_quantity);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Factory factory_copy = new Factory(factory, Workshops, Masters, Workers);
            dataGridView1.Rows.Add(factory_copy.name, factory_copy.workshops, factory_copy.workers, factory_copy.masters, factory_copy.money_by_worker, factory_copy.money_by_master, factory.details_quantity);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"FactoryData");
            File.AppendAllText($"FactoryData\\{ factory.name}.txt", $"{ factory.name}\n");
            foreach (var workshop in Workshops)
            {
                File.AppendAllText($"FactoryData\\{factory.name}.txt",
                $"{workshop.number} " +
                $"{workshop.places} " +
                $"{workshop.MaxCapacity} " +
                $"{workshop.Master_MaxCapacity} " +
                $"{workshop.Worker_MaxCapacity} " +
                $"{workshop.now_master} " +
                $"{workshop.now_worker} " +
                $"{Workshop.master_details} " +
                $"{Workshop.worker_details} " +
                $"{Workshop.detail_cost} " +
                $"{Workshop.detail_sell_cost} ");
                File.AppendAllText($"FactoryData\\{factory.name}.txt", $"\n");
            }
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Factory factory_compare = new Factory("Фабрика \"Ангел\"", 12000, 20000, 1000);
            
            dataGridView1.Rows.Add(factory_compare.name, factory_compare.workshops, factory_compare.workers, factory_compare.masters, factory_compare.money_by_worker, factory_compare.money_by_master, factory_compare.details_quantity);
            factory.Compare(factory, factory_compare);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, Workshops, Masters, Workers, Persons);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetAll();
        }
    }
}
