using System;
using System.Collections;
using System.Linq;

namespace P05PrintEvenNumbers
{
    class P05PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            var intArr = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .Where(i => i % 2 == 0);

            var output = string.Join(", ", intArr);
            Console.WriteLine(output);
        }
    }
}
