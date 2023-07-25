using System;
using System.Linq;

namespace P12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Predicate<string> isValid = x => FindSumString(x) >= n;

            string name = ProcessInput(isValid);

            Console.WriteLine(name);
        }

        private static string ProcessInput(Predicate<string> isValid)
        {
            return Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .ToList()
                               .Find(isValid);
        }

        static int FindSumString(string text)
        {
            int sum = 0;

            foreach (var symbol in text)
            {
                sum += symbol;
            }

            return sum;
        }
    }
}
