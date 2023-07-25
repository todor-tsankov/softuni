using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock2
{
    class Clock2
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            while (hours <= 23)
            {
                Console.WriteLine($"{hours} : {minutes} : {seconds}");
                seconds++;
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }

                if (minutes > 59)
                {
                    minutes = 0;
                    hours++;
                }

                

            }
        }
    }
}
