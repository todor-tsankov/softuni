using System;
using System.Linq;

namespace P04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var start = numbers[0];
            var end = numbers[1];

            var filter = Console.ReadLine();

            Predicate<int> evenOdd;
            evenOdd = FilterSwitch(filter);

            for (int i = start; i <= end; i++)
            {
                if (evenOdd(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Predicate<int> FilterSwitch(string filter)
        {
            Predicate<int> evenOdd;

            if (filter == "even")
            {
                evenOdd = x => x % 2 == 0;
            }
            else
            {
                evenOdd = x => x % 2 != 0;
            }

            return evenOdd;
        }
    }
}
