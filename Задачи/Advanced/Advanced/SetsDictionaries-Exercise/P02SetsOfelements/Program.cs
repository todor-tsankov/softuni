using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SetsOfelements
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            var n = nm[0];
            var m = nm[1];

            var firstSet = new HashSet<string>();
            var secondSet = new HashSet<string>();

            var uniqueSet = new HashSet<string>();

            for (int i = 0; i < n + m; i++)
            {
                var currentNumber = Console.ReadLine();

                if (i < n)
                {
                    firstSet.Add(currentNumber);
                }
                else
                {
                    secondSet.Add(currentNumber);
                }
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }

            // Console.WriteLine(string.Join(" ", uniqueSet));
        }
    }
}
