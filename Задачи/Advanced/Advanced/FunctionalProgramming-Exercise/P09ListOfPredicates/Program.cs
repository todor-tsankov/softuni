using System;
using System.Collections.Generic;
using System.Linq;

namespace P09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            for (int i = 1; i <= n; i++)
            {
                if (isValid(dividers, i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        static bool isValid(int[] dividers, int n)
        {
            foreach (var item in dividers)
            {
                if (n % item != 0)
                {
                    return false;
                }
            }

            return true;
        }

    }

}
