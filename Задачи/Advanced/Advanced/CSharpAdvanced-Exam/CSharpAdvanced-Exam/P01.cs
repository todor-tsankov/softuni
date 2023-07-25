using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced_Exam
{
    class P01
    {
        static void Main()
        {
            var firstBox = ReadInputNumbers();
            var secondBox = ReadInputNumbers();

            var claimedItems = new List<int>();

            Processboxes(firstBox, secondBox, claimedItems);
            PrintResult(firstBox, secondBox, claimedItems);
        }

        private static void Processboxes(List<int> firstBox, List<int> secondBox, List<int> claimedItems)
        {
            while (firstBox.Any() && secondBox.Any())
            {
                var currentFirst = firstBox[0];
                var currentSecond = secondBox[secondBox.Count - 1];

                var sum = currentFirst + currentSecond;

                if (sum % 2 == 0)
                {
                    firstBox.RemoveAt(0);
                    secondBox.RemoveAt(secondBox.Count - 1);

                    claimedItems.Add(sum);
                }
                else
                {
                    secondBox.RemoveAt(secondBox.Count - 1);
                    firstBox.Add(currentSecond);
                }
            }
        }

        private static void PrintResult(List<int> firstBox, List<int> secondBox, List<int> claimedItems)
        {
            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            var sum = claimedItems.Sum();

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }

        private static List<int> ReadInputNumbers()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }
    }
}
