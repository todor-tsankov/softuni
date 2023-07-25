using System;
using System.Linq;

namespace FunctionalProgramming_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = Console.WriteLine;

            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(printName);
        }
    }
}
