using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());

            double volume = a * b * h;
            int numberAstronauts = (int)(volume / (4 * (averageHeight + 0.4)));

            if (numberAstronauts >= 3 && numberAstronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {numberAstronauts} astronauts.");
            }
            else if (numberAstronauts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
