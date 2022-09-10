using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] {1, 9, 10};
        var targetSum = 27;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var bestCoinsDictionary = new Dictionary<int, int>();
        var sortedCoins = coins.OrderByDescending(c => c)
                               .ToList();

        var bestCoinsCounter = int.MaxValue;

        for (int i = sortedCoins.Count - 1; i >= 0; i--)
        {
            var currentDictionary = new Dictionary<int, int>();
            var currentCoinsCounter = 0;
            var currentSum = targetSum;
            var currentIndex = i;

            while (currentSum > 0 && currentIndex >= 0)
            {
                var coin = coins[currentIndex];

                if (currentSum - coin >= 0)
                {
                    var count = currentSum / coin;

                    currentCoinsCounter += count;
                    currentSum -= coin * count;

                    if (!currentDictionary.ContainsKey(coin))
                    {
                        currentDictionary[coin] = 0;
                    }

                    currentDictionary[coin] += count;
                }

                currentIndex--;
            }

            if (currentCoinsCounter < bestCoinsCounter && currentSum == 0)
            {
                bestCoinsCounter = currentCoinsCounter;
                bestCoinsDictionary = currentDictionary;
            }
        }

        if (bestCoinsDictionary.Count == 0)
        {
            throw new Exception("Error");
        }

        return bestCoinsDictionary;
    }
}