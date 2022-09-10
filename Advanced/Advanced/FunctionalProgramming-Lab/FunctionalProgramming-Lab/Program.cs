using System;
using System.Linq;

namespace FunctionalProgramming_Lab
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                                 .Split(", ")
                                 .Select(int.Parse)
                                 .Where(n => n % 2 == 0)
                                 .OrderBy(n => n)
                                 .ToArray();

            var result = string.Join(", ", numbers);

            Console.WriteLine(result);
        }
    }
}
