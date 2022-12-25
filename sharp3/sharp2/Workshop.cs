using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp2
{
    public class Workshop
    {
        public int number { get; set; }
        public int places { get; set; }
        public int MaxCapacity { get; set; }
        public int Master_MaxCapacity { get; set; }
        public int Worker_MaxCapacity { get; set; }
        public int now_master { get; set; }
        public int now_worker { get; set; }
        public const int master_details = 10;
        public const int worker_details = 5;
        public const int detail_cost = 60;
        public const int detail_sell_cost = 150;


        public Workshop(int number, int places, int MaxCapacity, int Master_MaxCapacity, int Worker_MaxCapacity, int now_master, int now_worker)
        {
            this.number = number;
            this.places = places;
            this.MaxCapacity = MaxCapacity;
            this.Master_MaxCapacity = Master_MaxCapacity;
            this.Worker_MaxCapacity = Worker_MaxCapacity;
            this.now_master = now_master;
            this.now_worker = now_worker;
        }
    }
}
