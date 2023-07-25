using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague
    {
        static void Main()
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int numberFans = int.Parse(Console.ReadLine());
            double a = 0;
            double b = 0;
            double v = 0;
            double g = 0;
            double allPercent = 0;

            for (int i = 0; i < numberFans; i++)
            {
                string fan = Console.ReadLine();
                switch (fan)
                {
                    case "A":
                        a++;
                        break;
                    case "B":
                        b++;
                        break;
                    case "V":
                        v++;
                        break;
                    case "G":
                        g++;
                        break;
                }
            }

            a = (double)a / (double)numberFans * 100;
            b = (double)b / (double)numberFans * 100;
            v = (double)v / (double)numberFans * 100;
            g = (double)g / (double)numberFans * 100;
            allPercent = (double)numberFans / (double)stadiumCapacity * 100;

            Console.WriteLine($"{a:f2}%");
            Console.WriteLine($"{b:f2}%");
            Console.WriteLine($"{v:f2}%");
            Console.WriteLine($"{g:f2}%");
            Console.WriteLine($"{allPercent:f2}%");

        }
    }
}
