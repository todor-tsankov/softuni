using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBoxes
{
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Box> listBoxes = new List<Box>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParts = command.Split();
                listBoxes.Add(new Box(commandParts));
            }

            listBoxes = listBoxes.OrderByDescending(o => o.PriceForBox).ToList();

            foreach (var item in listBoxes)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item} - ${item.Price:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.PriceForBox:f2}");
            }
        }
    }


    class Box
    {
        public Box(string[] commandParts)
        {
            SerialNumber = int.Parse(commandParts[0]);
            Item = commandParts[1];
            ItemQuantity = int.Parse(commandParts[2]);
            Price = double.Parse(commandParts[3]);
            PriceForBox = ItemQuantity * Price;
        }
        public int SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox  { get; set; }
        public double Price { get; set; }

    }
}
