using System;
using System.Linq;

namespace P02KnightHonour
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> addsSirAndPrints = name => Console.WriteLine("Sir " + name);

            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList()
                   .ForEach(addsSirAndPrints);
        }
    }
}
