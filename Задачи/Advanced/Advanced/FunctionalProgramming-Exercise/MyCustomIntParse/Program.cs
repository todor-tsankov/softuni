using System;
using System.Diagnostics;

namespace MyCustomIntParse
{
    class Program
    {
        static void Main()
        {
            int number = MyIntParse(Console.ReadLine());

            Console.WriteLine(number);

            Program.Main();
        }

        static int MyIntParse(string someString)
        {
            int number = 0;
            int counter = 1;

            int length = someString.Length;
            int endIndex = 0;

            bool isNegative = false;

            if (someString[0] == '-')
            {
                isNegative = true;

                endIndex++;
            }

            for (int i = length - 1; i >= endIndex; i--)
            {
                char currentSymbol = someString[i];

                if (!char.IsDigit(currentSymbol))
                {
                    throw new FormatException("Input string was not in the correct format");
                }

                int positionNumber = currentSymbol - 48;

                number += positionNumber * counter;
                counter *= 10;
            }

            return isNegative ? number * -1 : number ;
        }
    }
}
