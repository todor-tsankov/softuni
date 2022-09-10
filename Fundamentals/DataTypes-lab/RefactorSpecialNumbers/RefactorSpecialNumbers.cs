using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
           
            bool isSpecial = false;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int sumDigits = 0;

                while (currentNumber != 0)
                {
                    sumDigits += currentNumber % 10;
                    currentNumber /= 10;
                }

                isSpecial = (sumDigits == 5) || (sumDigits == 7) || (sumDigits == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }

        }
    }
}
