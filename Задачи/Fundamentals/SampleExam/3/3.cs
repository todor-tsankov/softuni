using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeSushi = Console.ReadLine();
            string nameReastaurant = Console.ReadLine();
            int numberDishes = int.Parse(Console.ReadLine());
            char typeOrder = char.Parse(Console.ReadLine());
            bool invalidResaurant = false;

            double price = 1;

            switch (nameReastaurant)
            {
                case "Sushi Zone":
                    switch (typeSushi)
                    {
                        case "sashimi":
                            price *= 4.99;
                            break;
                        case "maki":
                            price *= 5.29;
                            break;
                        case "uramaki":
                            price *= 5.99;
                            break;
                        case "temaki":
                            price *= 4.29;
                            break;
                    }
                    break;
                case "Sushi Time":
                    switch (typeSushi)
                    {
                        case "sashimi":
                            price *= 5.49;
                            break;
                        case "maki":
                            price *= 4.69;
                            break;
                        case "uramaki":
                            price *= 4.49;
                            break;
                        case "temaki":
                            price *= 5.19;
                            break;
                    }
                    break;
                case "Sushi Bar":
                    switch (typeSushi)
                    {
                        case "sashimi":
                            price *= 5.25;
                            break;
                        case "maki":
                            price *= 5.55;
                            break;
                        case "uramaki":
                            price *= 6.25;
                            break;
                        case "temaki":
                            price *= 4.75;
                            break;
                    }
                    break;
                case "Asian Pub":
                    switch (typeSushi)
                    {
                        case "sashimi":
                            price *= 4.50;
                            break;
                        case "maki":
                            price *= 4.80;
                            break;
                        case "uramaki":
                            price *= 5.50;
                            break;
                        case "temaki":
                            price *= 5.50;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine($"{nameReastaurant} is invalid restaurant!");
                    invalidResaurant = true;
                    break;
            }

            price *= numberDishes;

            if (typeOrder == 'Y' && invalidResaurant == false)
            {
                price *= 1.20;
            }

            price = Math.Ceiling(price);
            if (invalidResaurant == false)
            {
                Console.WriteLine($"Total price: {price} lv.");
            }
        }
    }
}
