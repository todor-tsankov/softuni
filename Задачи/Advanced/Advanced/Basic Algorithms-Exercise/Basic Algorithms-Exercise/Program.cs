using System;
using System.Linq;

namespace Basic_Algorithms_Exercise
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var sum = FindSum(numbers, 0);

            Console.WriteLine(sum);
        }

        static int FindSum(int[] numbers, int currentIndex)
        {
            var sum = 0;

            if (currentIndex == numbers.Length)
            {
                return sum;
            }

            sum += numbers[currentIndex];
            sum += FindSum(numbers, ++currentIndex);

            return sum;
        }
    }
}
