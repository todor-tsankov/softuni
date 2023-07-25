using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class Clock
    {
        static void Main(string[] args)
        {
            int minutes = 0;
            int hours = 0;

            while (hours < 24)
            {
                Console.WriteLine($"{hours}:{minutes}");
                minutes++;

                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }
            }
        }
    }
}
