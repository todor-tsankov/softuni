using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumDigits = 0;
                int number = i;

                while (number != 0)
                {
                    sumDigits += number % 10;
                    number /= 10;
                }

                bool special = sumDigits == 5 || sumDigits == 7 || sumDigits == 11;

                Console.WriteLine($"{i} -> {special}");
            }
        }
    }
}
