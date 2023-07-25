using System;
using System.Collections.Generic;
using System.Linq;

namespace P04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            ReadInputNumbers(n, numbers);
            PrintNumberWhichAppearsEvenTimes(numbers);
        }

        private static void PrintNumberWhichAppearsEvenTimes(Dictionary<int, int> numbers)
        {
            foreach (var (number, times) in numbers)
            {
                if (times % 2 == 0)
                {
                    Console.WriteLine(number);
                    break;
                }
            }
        }

        private static void ReadInputNumbers(int n, Dictionary<int, int> numbers)
        {
            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber] = 0;
                }

                numbers[currentNumber]++;
            }
        }
    }
}
