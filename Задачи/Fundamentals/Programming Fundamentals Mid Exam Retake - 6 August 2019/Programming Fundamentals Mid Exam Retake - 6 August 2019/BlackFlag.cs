using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureJunt
{
    class TreasureHunt
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double collectedPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                double currentPlunder = dailyPlunder;
                collectedPlunder += currentPlunder;

                if (i % 3 == 0)
                {
                    collectedPlunder += dailyPlunder * 0.5;
                }

                if (i % 5 == 0)
                {
                    collectedPlunder *= 0.7;
                }

            }

            if (collectedPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {collectedPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {collectedPlunder / expectedPlunder * 100:f2}% of the plunder.");
            }
        }
    }
}
