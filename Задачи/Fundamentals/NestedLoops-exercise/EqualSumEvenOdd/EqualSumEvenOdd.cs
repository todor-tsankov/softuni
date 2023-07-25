using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumEvenOdd
{
    class EqualSumEvenOdd
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                int evenSum = 0;
                int oddSum = 0;
                for (int j = 0; j < $"{i}".Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        oddSum += int.Parse ( $"{i}"[j] + "");
                    }
                    else
                    {
                        evenSum += int.Parse($"{i}"[j] + "");
                    }
                }

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
