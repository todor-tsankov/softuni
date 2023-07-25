using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterShopping
{
    class EasterShopping
    {
        static void Main(string[] args)
        {
            List<string> shopList = Console.ReadLine().Split().ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine().Split();
                string operation = commandParts[0];

                if (operation == "Include")
                {
                    string shop = commandParts[1];
                    shopList.Add(shop);
                }
                else if (operation == "Visit")
                {
                    string firstOrLast = commandParts[1];
                    int numberOfShops = int.Parse(commandParts[2]);
                    Visit(shopList, firstOrLast, numberOfShops);
                }
                else if (operation == "Prefer")
                {
                    int firstIndex = int.Parse(commandParts[1]);
                    int secondIndex = int.Parse(commandParts[2]);

                    if (firstIndex >= 0 && firstIndex < shopList.Count && secondIndex >= 0 && secondIndex < shopList.Count)
                    {
                        string firstShop = shopList[firstIndex];
                        shopList[firstIndex] = shopList[secondIndex];
                        shopList[secondIndex] = firstShop;
                    }
                }
                else if (operation == "Place")
                {
                    int index = int.Parse(commandParts[2]);

                    if (index >= 0 && index < shopList.Count)
                    {
                        string shop = commandParts[1];
                        shopList.Insert(index + 1, shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopList));
        }

        static void Visit(List<string> shopList, string firstOrLast, int numberOfShops)
        {
            if (numberOfShops <= shopList.Count)
            {
                if (firstOrLast == "first")
                {
                    for (int i = 0; i < numberOfShops; i++)
                    {
                        shopList.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfShops; i++)
                    {
                        shopList.RemoveAt(shopList.Count - 1);
                    }   
                }
            }
        }
    }
}
