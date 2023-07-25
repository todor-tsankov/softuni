using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology_Fundamentals_Retake_Mid_Exam___16_April_2019
{
    class EasterCozonacs
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceFlourKg = double.Parse(Console.ReadLine());

            double pricePackEggs = priceFlourKg * 0.75;
            double priceMilk = priceFlourKg * 0.25 * 1.25;
            double priceOneKozunak = priceFlourKg + pricePackEggs + priceMilk;
            int countColouredEggs = 0;
            int counter = 1;

            while (budget >= priceOneKozunak)
            {
                if (counter % 3 == 0)
                {
                    countColouredEggs -= counter - 2;
                }

                    countColouredEggs += 3;

                budget -= priceOneKozunak;
                counter++;
            }

            Console.WriteLine($"You made {counter - 1} cozonacs! Now you have {countColouredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
