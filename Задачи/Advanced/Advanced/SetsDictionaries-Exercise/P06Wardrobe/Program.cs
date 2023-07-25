using System;
using System.Collections.Generic;

namespace P06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Dictionary<string, Dictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            ReadInput(clothes, n);

            var colorAndItem = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var colorToBeFound = colorAndItem[0];
            var itemToBeFound = colorAndItem[1];

            Print(clothes, colorToBeFound, itemToBeFound);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> clothes, string colorToBeFound, string itemToBeFound)
        {
            foreach (var (color, items) in clothes)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (itemName, count) in items)
                {
                    if (color == colorToBeFound && itemName == itemToBeFound)
                    {
                        Console.WriteLine($"* {itemName} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itemName} - {count}");
                    }
                }
            }
        }

        private static void ReadInput(Dictionary<string, Dictionary<string, int>> clothes, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var colorAndClothes = Console.ReadLine().Split(" -> ");

                var color = colorAndClothes[0];
                var currentClothes = colorAndClothes[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, int>();
                }

                foreach (var item in currentClothes)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color][item] = 0;
                    }

                    clothes[color][item]++;
                }
            }
        }
    }
}
