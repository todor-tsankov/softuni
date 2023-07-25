using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["motes"] = 0,
                ["fragments"] = 0

            };
            var junkMaterials = new Dictionary<string, int>();
            string winner = string.Empty;
            bool notFoundWinner = true;

            while (notFoundWinner)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string item = input[i + 1].ToLower();

                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        keyMaterials[item] += quantity;

                        if (keyMaterials[item] >= 250)
                        {
                            winner = item;
                            notFoundWinner = false;
                            keyMaterials[item] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(item))
                        {
                            junkMaterials[item] = 0;
                        }

                        junkMaterials[item] += quantity;
                    }
                }
            }

            string winnerMessage = string.Empty;

            switch (winner)
            {
                case "shards":
                    winnerMessage = "Shadowmourne obtained!";
                    break;
                case "fragments":
                    winnerMessage = "Valanyr obtained!";
                    break;
                case "motes":
                    winnerMessage = "Dragonwrath obtained!";
                    break;
            }

            keyMaterials = keyMaterials
                            .OrderByDescending(i => i.Value)
                            .ThenBy(i => i.Key)
                            .ToDictionary(i => i.Key, i => i.Value);

            junkMaterials = junkMaterials
                            .OrderBy(i => i.Key)
                            .ToDictionary(i => i.Key, i => i.Value);

            Console.WriteLine(winnerMessage);

            foreach (var item in keyMaterials)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
