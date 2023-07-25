using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 15;

            if (minutes >= 60)
            {
                hours = hours + minutes / 60;
                minutes = minutes % 60;
                

                if (hours >= 24)
                {
                    hours = hours - 24;
                }
            }
            else if (hours >= 24)
            {
                hours = hours - 23;

            }

            Console.WriteLine($"{hours}:{minutes.ToString("D2")}");
        }
    }
}
