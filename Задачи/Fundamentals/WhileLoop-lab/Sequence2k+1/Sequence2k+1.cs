using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int number = 1;

            while (number <= n)
            {
                Console.WriteLine(number);
                number = number * 2 + 1;
            }
        }
    }
}
