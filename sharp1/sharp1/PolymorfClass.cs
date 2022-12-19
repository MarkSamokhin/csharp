using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp1
{
    internal class PolymorfClass : Worker
    {
        public PolymorfClass() { }
        public override void ToString()
        {
            Console.WriteLine("Я рабочий!");
        }
    }
}
