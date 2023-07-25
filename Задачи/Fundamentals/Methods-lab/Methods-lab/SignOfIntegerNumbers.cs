using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_lab
{
    class SignOfIntegerNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SignOfInteger(number);
        }

        static void SignOfInteger(int number)
        {
            string result = string.Empty;

            if (number > 0)
            {
                result = "positive";
            }
            else if (number < 0)
            {
                result = "negative";
            }
            else
            {
                result = "zero";
            }

            Console.WriteLine($"The number {number} is {result}."); ;
        }
    }
}
