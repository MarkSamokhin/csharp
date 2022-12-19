using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sharp2
{
    internal static class Extension
    {
        public static void CountEarnings(this Factory factory, double earnings)
        {
            try
            {
                MessageBox.Show("Возможный доход (найм рабочих) = " + factory.money_by_worker*(earnings/factory.worker_salary) + "\nВозможный доход (найм мастеров) = " + factory.money_by_master*(earnings/factory.master_salary) + "\nВозможный доход (найм рабочих и мастеров поровну) = " + (factory.money_by_worker*(earnings/2/factory.worker_salary)+factory.money_by_master*(earnings/2/factory.master_salary)), "Примерный доход");
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!, Error");
            }
        }
    }
}
