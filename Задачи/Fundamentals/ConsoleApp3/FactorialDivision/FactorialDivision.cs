using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            decimal result = (decimal) Factorial(firstNumber) / (decimal)Factorial(secondNumber);
            Console.WriteLine(result.ToString("f2"));
        }

        static BigInteger Factorial(BigInteger number)
        {
            BigInteger result = 1;

            if (number != 0)
            {
                for (BigInteger i = number; i > 0; i--)
                {
                    result *= i;
                }
            }

            return result;
        }
    }
}
