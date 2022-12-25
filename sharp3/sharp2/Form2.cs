using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp2
{
    public partial class Form2 : Form
    {
        public Form1 myform { get; set; }
        public List<Workshop> Workshops { get; set; }
        public List<Master> Masters { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Person> Persons { get; set; }

        public Form2(Form1 form1, List<Workshop> Workshops, List<Master> Masters, List<Worker> Workers, List<Person> Persons)
        {
            this.myform = form1;
            this.Workshops = this.myform.Workshops;
            this.Masters = this.myform.Masters;
            this.Workers = this.myform.Workers;
            this.Persons = this.myform.Persons;
            InitializeComponent();
        }

        private void GetAll1()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            foreach (var workshop in Workshops)
            {
                dataGridView1.Rows.Add(workshop.number, workshop.places, workshop.MaxCapacity, workshop.Master_MaxCapacity, workshop.Worker_MaxCapacity, workshop.now_master, workshop.now_worker, Workshop.master_details, Workshop.worker_details, Workshop.detail_cost, Workshop.detail_sell_cost);
            }
            foreach (var master in Masters)
            {
                dataGridView2.Rows.Add(master.name, master.surname, master.patronymic, master.number, master.workshop_number, Master.salary, master.courses);
            }
            foreach (var worker in Workers)
            {
                dataGridView3.Rows.Add(worker.name, worker.surname, worker.patronymic, worker.number, worker.workshop_number, Worker.salary, worker.university);
            }
        }

        public void MastersFile()
        {
            File.CreateText($"FactoryData\\Masters.txt").Close();
            foreach (var master in Masters)
            {
                File.AppendAllText($"FactoryData\\Masters.txt",
                    $"{master.name} " +
                    $"{master.surname} " +
                    $"{master.patronymic} " +
                    $"{master.number} " +
                    $"{master.workshop_number} " +
                    $"{Master.salary} " +
                    $"{master.courses}\n");
            }
        }

        private void WorkersFile()
        {
            File.CreateText($"FactoryData\\Workers.txt").Close();
            foreach (var worker in Workers)
            {
                File.AppendAllText($"FactoryData\\Workers.txt",
                    $"{worker.name} " +
                    $"{worker.surname} " +
                    $"{worker.patronymic} " +
                    $"{worker.number} " +
                    $"{worker.workshop_number} " +
                    $"{Worker.salary} " +
                    $"{worker.university}\n");
            }
        }

        private void AddMaster(Master newmaster)
        {

                if (String.IsNullOrWhiteSpace(TBname.Text.ToString()) || String.IsNullOrWhiteSpace(TBsurname.Text.ToString()) || String.IsNullOrWhiteSpace(TBpatronymic.Text.ToString()) || !TBcourses.Text.All(char.IsNumber) ||
                    String.IsNullOrWhiteSpace(TBnumber.Text.ToString()) || String.IsNullOrWhiteSpace(TBworkshop.Text.ToString()) || String.IsNullOrWhiteSpace(TBcourses.Text.ToString()) || TBnumber.Text.Length != 10)
                {
                    MessageBox.Show("Ошибка!", "Error");
                    return;
                }
                newmaster.name = TBname.Text;
                newmaster.surname = TBsurname.Text;
                newmaster.patronymic = TBpatronymic.Text;
                newmaster.number = TBnumber.Text;
                newmaster.workshop_number = Convert.ToInt32(TBworkshop.Text);
                newmaster.courses = Convert.ToInt32(TBcourses.Text);
                foreach (var master in Masters)
                {
                    if (master.number == newmaster.number)
                    {
                        MessageBox.Show("Налоговый номер уже занят!", "Error");
                        return;
                    }
                }
                foreach (var workshop in Workshops)
                {
                    if (workshop.number == newmaster.workshop_number)
                    {
                        if (workshop.now_master + 1 > workshop.Master_MaxCapacity || workshop.places - 1 < 0)
                        {
                            MessageBox.Show("В цеху нет места для мастера!", "Error");
                            return;
                        }
                        Masters.Add(newmaster);
                        workshop.now_master++;
                        workshop.places--;
                        GetAll1();
                        MastersFile();
                    }
                }
            }


        private void AddWorker(Worker newworker)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(TBname.Text.ToString()) || String.IsNullOrWhiteSpace(TBsurname.Text.ToString()) || String.IsNullOrWhiteSpace(TBpatronymic.Text.ToString()) || String.IsNullOrWhiteSpace(CBuniversity.Text.ToString()) ||
                    String.IsNullOrWhiteSpace(TBnumber.Text.ToString()) || String.IsNullOrWhiteSpace(TBworkshop.Text.ToString()) || TBnumber.Text.Length != 10)
                {
                    MessageBox.Show("Ошибка!", "Error");
                    return;
                }
                newworker.name = TBname.Text;
                newworker.surname = TBsurname.Text;
                newworker.patronymic = TBpatronymic.Text;
                newworker.number = TBnumber.Text;
                newworker.workshop_number = Convert.ToInt32(TBworkshop.Text);
                switch (CBuniversity.Text)
                {
                    case "Да" :
                        {
                            newworker.university = true;
                            break;
                        }
                    case "Нет":
                        {
                            newworker.university = false;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Ошибка", "Error");
                            return;
                        }
                }
                foreach (var worker in Workers)
                {
                    if (worker.number == newworker.number)
                    {
                        MessageBox.Show("Налоговый номер уже занят!", "Error");
                        return;
                    }
                }
                foreach (var workshop in Workshops)
                {
                    if (workshop.number == newworker.workshop_number)
                    {
                        if (workshop.now_worker + 1 > workshop.Worker_MaxCapacity || workshop.places - 1 < 0)
                        {
                            MessageBox.Show("В цеху нет места для рабочего!", "Error");
                            return;
                        }
                        Workers.Add(newworker);
                        workshop.now_worker++;
                        workshop.places--;
                        GetAll1();
                        WorkersFile();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master newmaster = new Master();
            AddMaster(newmaster);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetAll1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Worker newworker = new Worker();
            AddWorker(newworker);
        }

        private void RemoveMaster(string masternumber)
        {
            foreach (var master in Masters)
            {
                try
                {
                    if (masternumber == master.number)
                    {
                        foreach (var workshop in Workshops)
                        {
                            if (master.workshop_number == workshop.number)
                            {
                                if (workshop.now_master - 1 < 0)
                                {
                                    MessageBox.Show("В цеху нет мастеров!");
                                    return;
                                }
                                workshop.now_master--;
                                workshop.places++;
                                Masters.Remove(master);
                                GetAll1();
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Error");
                }
            }
            MessageBox.Show("Ошибка!", "Error");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveMaster(TBnumber.Text.ToString());
        }

        private void RemoveWorker(string workernumber)
        {
            foreach (var worker in Workers)
            {
                try
                {
                    if (workernumber == worker.number)
                    {
                        foreach (var workshop in Workshops)
                        {
                            if (worker.workshop_number == workshop.number)
                            {
                                if (workshop.now_worker - 1 < 0)
                                {
                                    MessageBox.Show("В цеху нет рабочих!");
                                    return;
                                }
                                workshop.now_worker--;
                                workshop.places++;
                                Workers.Remove(worker);
                                GetAll1();
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Error");
                }
            }
            MessageBox.Show("Ошибка!", "Error");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveWorker(TBnumber.Text.ToString());
        }
    }
}
