using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Exercise
{
    class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }

            PrintsTheSmallestNumber(numbers);
        }

        static void PrintsTheSmallestNumber(double[] numbers)
        {
            double minNumber = double.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}
