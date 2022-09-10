using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class LeftAndRightSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    sumLeft += currentNumber;
                }
                else
                {
                    sumRight += currentNumber;
                }
            }

            int diff = Math.Abs(sumLeft - sumRight);
            if (diff == 0)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }
            else
            {
                Console.WriteLine("No, diff = " + diff);
            }

        }
    }
}
