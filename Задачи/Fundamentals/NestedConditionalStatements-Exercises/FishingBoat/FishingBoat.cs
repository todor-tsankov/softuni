using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingBoat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numPeople = int.Parse(Console.ReadLine());
            double price = 0.00;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                    price = 4200;
                    break;
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                   price = 2600;
                    break;
            }

            if (numPeople <= 6)
            {
                price *= 0.9;
            }
            else if (numPeople <= 11)
            {
                price *= 0.85;
            }
            else
            {
                price *= 0.75;
            }

            if (numPeople % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }

            double diff = Math.Abs(budget - price);

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
            }
        }
    }
}
