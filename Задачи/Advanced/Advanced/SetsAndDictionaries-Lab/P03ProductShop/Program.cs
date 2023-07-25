using System;
using System.Collections.Generic;

namespace P03ProductShop
{
    class Program
    {
        static void Main()
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            ReadInput(shops);
            Print(shops);
        }

        private static void Print(SortedDictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var (shopName, products) in shops)
            {
                Console.WriteLine($"{shopName}->");

                foreach (var (product, cost) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {cost}");
                }
            }
        }

        private static void ReadInput(SortedDictionary<string, Dictionary<string, double>> shops)
        {
            while (true)
            {
                var shopProductPrice = Console.ReadLine()
                                              .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var shop = shopProductPrice[0];

                if (shop == "Revision")
                {
                    break;
                }

                var product = shopProductPrice[1];

                var price = double.Parse(shopProductPrice[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                if (shops[shop].ContainsKey(product))
                {
                    throw new NotImplementedException();
                }

                shops[shop][product] = price;
            }
        }
    }
}
