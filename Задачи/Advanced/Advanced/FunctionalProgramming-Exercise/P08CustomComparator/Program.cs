using System;
using System.Linq;

namespace P08CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Array.Sort(numbers, Comparator);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Comparator(int x, int y)
        {
            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x > y)
            {
                return 1;
            }
            else if (x < y)
            {
                return -1;
            }

            return 0;
        }

    }
}
