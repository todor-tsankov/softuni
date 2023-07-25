using System;
using System.Collections.Generic;

namespace P03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var uniqueElements = new SortedSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentCompund = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in currentCompund)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
