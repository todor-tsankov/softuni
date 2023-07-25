using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse
{
    class NewHouse
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = numberFlowers;

            switch (flowerType)
            {
                case "Roses":
                    if (numberFlowers > 80)
                    {
                        price *= 0.9;
                    }
                    price *= 5;
                    break;
                case "Dahlias":
                    if (numberFlowers > 90)
                    {
                        price *= 0.85;
                    }
                    price *= 3.8;
                    break;   
                case "Tulips":
                    if (numberFlowers > 80)
                    {
                        price *= 0.85;
                    }
                    price *= 2.8;
                    break;
                case "Narcissus":
                    if (numberFlowers < 120)
                    {
                        price *= 1.15;
                    }
                    price *= 3;
                    break;
                case "Gladiolus":
                    if (numberFlowers < 80)
                    {
                        price *= 1.2;
                    }
                    price *= 2.5;
                    break;
               
            }
            double diff = Math.Abs(budget - price);

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {flowerType} and {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {diff:f2} leva more."); 
                 
            }
            

        }
    }
}
