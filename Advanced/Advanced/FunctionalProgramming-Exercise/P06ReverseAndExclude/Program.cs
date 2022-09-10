using System;
using System.Linq;

namespace P06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .Reverse()
                                 .ToArray();

            var n = int.Parse(Console.ReadLine());

            numbers = numbers.Where(x => x % n != 0)
                             .ToArray();

            var result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }
}
