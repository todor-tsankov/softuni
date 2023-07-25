using System;
using System.Linq;

namespace P07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Func<string, bool> lengthFilter = x => x.Length <= n;

            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Where(lengthFilter)
                   .ToList()
                   .ForEach(Console.WriteLine);
        }
    }
}
