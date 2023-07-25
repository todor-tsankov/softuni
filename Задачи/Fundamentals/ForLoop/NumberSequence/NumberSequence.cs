using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequence
{
    class NumberSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentMax = int.MinValue;
            int currentMin = int.MaxValue;
            int number = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number > currentMax)
                {
                    currentMax = number;
                }

                if (number < currentMin)
                {
                    currentMin = number;
                }
            }

            Console.WriteLine($"Max number: {currentMax}");
            Console.WriteLine($"Min number: {currentMin}");
        }
    }
}
