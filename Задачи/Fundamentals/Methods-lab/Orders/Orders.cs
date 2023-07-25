using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintPrice(product, quantity);
        }

        static void PrintPrice(string product, int quantity)
        {
            double price = quantity;

            switch (product)
            {
                case "coffee":
                    price *= 1.50;
                    break;
                case "water":
                    price *= 1.00;
                    break;
                case "coke":
                    price *= 1.40;
                    break;
                case "snacks":
                    price *= 2.00;
                    break;
            }

            Console.WriteLine(price.ToString("f2"));
        }
    }
}
