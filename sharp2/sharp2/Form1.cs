using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp2
{
    public partial class Form1 : Form
    {
        Factory factory = new Factory("Завод #23", 25, 100, 10, 15000, 25000, 30000, 80000);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HireWorkers();
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void GetAll()
        {
            dataGridView1.Rows.Add(factory.name, factory.workshops, factory.workers, factory.masters, factory.worker_salary, factory.master_salary, factory.money_by_worker, factory.money_by_master);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Factory factory_copy = new Factory(factory);
            dataGridView1.Rows.Add(factory_copy.name, factory_copy.workshops, factory_copy.workers, factory_copy.masters, factory_copy.worker_salary, factory_copy.master_salary, factory_copy.money_by_worker, factory_copy.money_by_master);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void HireWorkers()
        {
            try
            {
                int quantity = Convert.ToInt32(textBox1.Text);
                if (quantity <= 0)
                {
                    MessageBox.Show("Неверный формат числа!", "Error");
                    textBox1.Clear();
                    return;
                }
                factory.workers += quantity;
                factory.masters = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(factory.workers/10)))+1;
            }
            catch
            {
                textBox1.Clear();
                MessageBox.Show("Ошибка ввода!", "Error");
            }
        }

        private void HireMasters()
        {
            try
            {
                int quantity = Convert.ToInt32(textBox2.Text);
                if (quantity <= 0)
                {
                    MessageBox.Show("Неверный формат числа!", "Error");
                    textBox2.Clear();
                    return;
                }
                factory.masters += quantity;
                factory.workers += quantity * 10;
            }
            catch
            {
                textBox2.Clear();
                MessageBox.Show("Ошибка ввода!", "Error");
            }
        }

        private void FireWorkers()
        {
            try
            {
                int number = Convert.ToInt32(textBox1.Text);
                if (number <= 0 || number > factory.workers)
                {
                    MessageBox.Show("Неверный формат числа либо на заводе нет столько рабочих/мастеров!", "Error");
                    textBox1.Clear();
                    return;
                }
                factory.workers -= number;
                factory.masters = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(factory.workers/10)))+1;
            }
            catch
            {
                textBox1.Clear();
                MessageBox.Show("Ошибка ввода!", "Error");
            }
        }

        private void FireMasters()
        {
            try
            {
                int number = Convert.ToInt32(textBox2.Text);
                if (number <= 0 || number > factory.masters || number*10 > factory.workers)
                {
                    MessageBox.Show("Неверный формат числа либо на заводе нет столько мастеров/рабочих!", "Error");
                    textBox2.Clear();
                    return;
                }
                factory.masters -= number;
                factory.workers -= number * 10;
            }
            catch
            {
                textBox2.Clear();
                MessageBox.Show("Ошибка ввода!", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FireWorkers();
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HireMasters();
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FireMasters();
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private Factory UniteFactories(Factory factory, Factory factory1)
        {
            return (Factory)(factory + factory);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Factory factory_copy = new Factory(factory);
            factory = UniteFactories(factory, factory_copy);
            dataGridView1.Rows.Clear();
            GetAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Factory factory_compare = new Factory("Фабрика \"Ангел\"", 10, 50, 200, 10000, 15000, 12000, 20000);
            dataGridView1.Rows.Add(factory_compare.name, factory_compare.workshops, factory_compare.workers, factory_compare.masters, factory_compare.worker_salary, factory_compare.master_salary, factory_compare.money_by_worker, factory_compare.money_by_master);
            factory.Compare(factory, factory_compare);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                double earnings = Convert.ToDouble(textBox3.Text);
                factory.CountEarnings(earnings);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!", "Error");
            }
        }
    }
}
