using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerKegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            double maxVolume = int.MinValue;
            string nameOfKegWithMaxVolume = string.Empty;

            for (int i = 0; i < numberOfKegs; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentVolume = Math.PI * radius * radius * height;

                if (currentVolume > maxVolume)
                {
                    nameOfKegWithMaxVolume = name;
                    maxVolume = currentVolume;
                }
            }

            Console.WriteLine(nameOfKegWithMaxVolume);
        }
    }
}
