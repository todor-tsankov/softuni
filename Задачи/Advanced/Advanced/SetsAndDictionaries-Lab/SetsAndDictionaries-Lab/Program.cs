using System;
using System.Collections.Generic;

namespace SetsAndDictionaries_Lab
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var numbersDictionary = new Dictionary<string, int>();

            foreach (var number in numbers)
            {
                if (!numbersDictionary.ContainsKey(number))
                {
                    numbersDictionary[number] = 0;
                }

                numbersDictionary[number]++;
            }

            foreach (var (number, times) in numbersDictionary)
            {
                Console.WriteLine($"{number} - {times} times");
            }
        }
    }
}
