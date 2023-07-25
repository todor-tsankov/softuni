using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureJunt
{
    class TreasureHunt
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split('|').ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Loot")
                {
                    Loot(commandParts, chest);
                }
                else if (operation == "Drop")
                {
                    int index = int.Parse(commandParts[1]);
                    Drop(index , chest);
                }
                else if (operation == "Steal")
                {
                    int count = int.Parse(commandParts[1]);
                    Steal(count, chest);
                }
            }

            double averageGain = 0;

            foreach (var item in chest)
            {
                averageGain += item.Length;
            }

            averageGain /= chest.Count;

            if (chest.Count != 0)
            {
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }

        static void Loot(string[]commandParts, List<string> chest)
        {
            for (int i = 1; i < commandParts.Length; i++)
            {
                string currentItem = commandParts[i];

                if (!chest.Contains(currentItem))
                {
                    chest.Insert(0, currentItem);
                }
            }
        }

        static void Drop(int index, List<string> chest)
        {
            if (index >= 0 && index < chest.Count)
            {
                string currentElement = chest[index];
                chest.Add(currentElement);
                chest.RemoveAt(index);
            }
        }
        static void Steal(int count, List<string> chest)
        {
            List<string> stolenItems = new List<string>();

            for (int i = chest.Count - 1; i >= 0; i--)
            {
                if (count > 0)
                {
                    stolenItems.Add(chest[i]);
                    chest.RemoveAt(i);
                    count--;
                }
            }

            stolenItems.Reverse();
            Console.WriteLine(string.Join(", ", stolenItems));
        }
    }
}
