using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyEvenByOdds
{
    class MultiplyEvenByOdds
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            number = Math.Abs(number);
            string numberInString = number.ToString();
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < numberInString.Length; i++)
            {
                if (int.Parse(numberInString[i]+ " ") % 2 == 0)
                {
                    sumOdd += int.Parse(numberInString[i].ToString());
                }
                else
                {
                    sumEven += int.Parse(numberInString[i].ToString());
                }
            }

            return sumEven * sumOdd;
        }

    }
}
