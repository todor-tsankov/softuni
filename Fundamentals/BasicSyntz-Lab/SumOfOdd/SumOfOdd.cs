using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOdd
{
    class SumOfOdd
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i < n * 2; i += 2)
            {
                Console.WriteLine(i);
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
