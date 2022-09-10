using ParallelMergeSort.Core;
using System;
using System.Diagnostics;

namespace ParallelMergeSort
{
    public class Program
    {
        public const int NumbersCount = 10_000_000;

        public static void Main()
        {
            var random = new Random();
            var testArray = new int[NumbersCount];

            for (int i = 0; i < NumbersCount; i++)
            {
                testArray[i] = random.Next(0, NumbersCount);
            }

            var firstTestArray = (int[]) testArray.Clone();
            var secondTestArray = (int[]) testArray.Clone();

            var mergeSorter = new MergeSorter();
            var asyncMergeSorter = new ThreadMergeSorter();

            var sw = new Stopwatch();

            sw.Start();
            mergeSorter.Sort(firstTestArray);

            Console.WriteLine(sw.Elapsed);
            sw.Restart();

            asyncMergeSorter.Sort(secondTestArray);

            Console.WriteLine(sw.Elapsed);

            //Console.WriteLine(string.Join(" ", firstTestArray));
            //Console.WriteLine(string.Join(" ", secondTestArray));
        }
    }
}
