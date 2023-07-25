using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopNumber2
{
    class TopNumber2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if (IsSumOfDigitsDivisibleByEight(i.ToString()) && IsThereAtLeastOneOddDigit(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsSumOfDigitsDivisibleByEight(string currentNumber)
        {
            int sumDigits = 0;

            for (int i = 0; i < currentNumber.Length; i++)
            {
                sumDigits += currentNumber[i];
            }

            if (sumDigits % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool IsThereAtLeastOneOddDigit(string currentNumber)
        {
            for (int i = 0; i < currentNumber.Length; i++)
            {
                if (currentNumber[i] % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
