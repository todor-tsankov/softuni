using System;
using System.Numerics;
using System.Diagnostics;

using SortingAlgorithms.Models;
using SortingAlgorithms.Core.Contracts;
using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            var testsCount = 1;
            var numbersCount = 100000;

            var random = new Random();

            var firstSorter = new RadixSorter();
            var secondSorter = new QuickSorter();

            BigInteger firstSorterSum = 0;
            BigInteger secondSorterSum = 0;

            for (int i = 0; i < testsCount; i++)
            {
                var firstArr = new int[numbersCount];
                var secondArr = new int[numbersCount];

                FillArrays(numbersCount, random, firstArr, secondArr);

                var stopwatch = new Stopwatch();

                firstSorterSum += this.TestSort(firstSorter, firstArr, stopwatch);

                secondSorterSum += this.TestSort(secondSorter, secondArr, stopwatch);

                //Console.WriteLine(string.Join(" ", firstArr));
            }

            Console.WriteLine($"{firstSorter.GetType().Name} Total: {firstSorterSum}");
            Console.WriteLine($"{secondSorter.GetType().Name} Total: {secondSorterSum}");
        }

        private BigInteger TestSort(ISorter sorter, int[] firstArr, Stopwatch stopwatch)
        {
            stopwatch.Start();

            sorter.Sort(firstArr);
            stopwatch.Stop();

            var sum = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            return sum;
        }

        private static void FillArrays(int numbersCount, Random random, int[] firstArr, int[] secondArr)
        {
            for (int j = 0; j < numbersCount; j++)
            {
                var current = random.Next(0, 100);

                firstArr[j] = current;
                secondArr[j] = current;
            }
        }
    }
}
