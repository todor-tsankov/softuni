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
            var productList = new Dictionary<string, Product>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] commandParts = command.Split();
                string name = commandParts[0];
                double price = double.Parse(commandParts[1]);
                int quantity = int.Parse(commandParts[2]);

                if (!productList.ContainsKey(name))
                {
                    productList[name] = new Product(price, quantity);
                }
                else
                {
                    productList[name].Quantity += quantity;
                    productList[name].Price = price;
                }
            }

            foreach (var item in productList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Price * item.Value.Quantity:f2}");
            }
        }
    }

    class Product
    {
        public Product(double price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
