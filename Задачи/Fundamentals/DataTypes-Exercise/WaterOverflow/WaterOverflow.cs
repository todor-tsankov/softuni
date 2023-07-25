using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int allWaterLitres = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                int currentLitres = int.Parse(Console.ReadLine());

                if (allWaterLitres + currentLitres > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    allWaterLitres += currentLitres;
                }
            }

            Console.WriteLine(allWaterLitres);
        }
    }
}
