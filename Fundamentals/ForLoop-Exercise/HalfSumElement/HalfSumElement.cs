using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSumElement
{
    class HalfSumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
            }

            sum -= max;
            
            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            { 
                int diff = Math.Abs(sum - max);
                 Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
