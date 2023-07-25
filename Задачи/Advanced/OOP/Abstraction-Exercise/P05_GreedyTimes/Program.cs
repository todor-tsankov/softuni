using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main()
        {
            var capacityOfTheBag = long.Parse(Console.ReadLine());
            var itemQuantityPairs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            var gold = 0L;
            var gems = 0L;
            var cash = 0L;

            ProcessInput(capacityOfTheBag, itemQuantityPairs, bag, ref gold, ref gems, ref cash);
            PrintResult(bag);
        }

        private static void ProcessInput(long capacityOfTheBag, string[] itemQuantityPairs, Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long gems, ref long cash)
        {
            for (int currentPair = 0; currentPair < itemQuantityPairs.Length; currentPair += 2)
            {
                var pair = itemQuantityPairs[currentPair];
                var quantity = long.Parse(itemQuantityPairs[currentPair + 1]);

                var itemType = string.Empty;

                itemType = GetType(pair, itemType);

                var cont = false;

                if (itemType == "" || capacityOfTheBag < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    cont = true;
                }

                if (cont)
                {
                    continue;
                }

                cont = Add(bag, quantity, itemType, cont);

                if (cont)
                {
                    continue;
                }

                AddItemTypeIfNeeded(bag, itemType);
                AddPairIfPossible(bag, pair, itemType);

                bag[itemType][pair] += quantity;
                IncreaseItemTypeQuantity(ref gold, ref gems, ref cash, quantity, itemType);
            }
        }

        private static bool Add(Dictionary<string, Dictionary<string, long>> bag, long quantity, string itemType, bool cont)
        {
            switch (itemType)
            {
                case "Gem":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (quantity > bag["Gold"].Values.Sum())
                            {
                                cont = true;
                            }
                        }
                        else
                        {
                            cont = true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                    {
                        cont = true;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (quantity > bag["Gem"].Values.Sum())
                            {
                                cont = true;
                            }
                        }
                        else
                        {
                            cont = true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                    {
                        cont = true;
                    }
                    break;
            }

            return cont;
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var (name, collection) in bag)
            {
                Console.WriteLine($"<{name}> ${collection.Values.Sum()}");

                var sortedItemPairs = collection.OrderByDescending(y => y.Key).ThenBy(y => y.Value);

                foreach (var (itemName, itemQuantity) in sortedItemPairs)
                {
                    Console.WriteLine($"##{itemName} - {itemQuantity}");
                }
            }
        }

        private static void IncreaseItemTypeQuantity(ref long gold, ref long gems, ref long cash, long quantity, string itemType)
        {
            if (itemType == "Gold")
            {
                gold += quantity;
            }
            else if (itemType == "Gem")
            {
                gems += quantity;
            }
            else if (itemType == "Cash")
            {
                cash += quantity;
            }
        }

        private static void AddPairIfPossible(Dictionary<string, Dictionary<string, long>> bag, string pair, string itemType)
        {
            if (!bag[itemType].ContainsKey(pair))
            {
                bag[itemType][pair] = 0;
            }
        }

        private static void AddItemTypeIfNeeded(Dictionary<string, Dictionary<string, long>> bag, string itemType)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }
        }

        private static string GetType(string name, string itemType)
        {
            if (name.Length == 3)
            {
                itemType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
    }
}