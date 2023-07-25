using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiTrip
{
    class SkiTrip
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string opinion = Console.ReadLine();
            int nights = days - 1;
            double price = 0;
            switch (roomType)
            {
                case "room for one person":
                    price = nights * 18.0;
                    break;
                case "apartment":
                    price = nights * 25.0;
                    if (nights < 10)
                    {
                        price *= 0.70;
                    }
                    else if (nights <= 15)
                    {
                        price *= 0.65;
                    }
                    else
                    {
                        price *= 0.5;
                    }
                    break;
                case "president apartment":
                    price = nights * 35.0;
                    if (nights < 10)
                    {
                        price *= 0.90;
                    }
                    else if (nights <= 15)
                    {
                        price *= 0.85;
                    }
                    else
                    {
                        price *= 0.8;
                    }
                    break;
            }

            switch (opinion)
            {
                case "positive":
                    price *= 1.25;
                    break;
                case "negative":
                    price *= 0.90;
                    break;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
