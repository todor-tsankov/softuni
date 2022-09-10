using System;
using System.Linq;

namespace P03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> startsWithUppercase = w => char.IsUpper(w[0]);

            var words = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Where(startsWithUppercase)
                               .ToArray();

            var result = string.Join(Environment.NewLine, words);

            Console.WriteLine(result);
        }
    }
}
