using System;

namespace _2.AsciiSumator2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = Console.ReadLine()[0];
            char secondSymbol = Console.ReadLine()[0];
            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currentNumber = input[i];

                if (currentNumber > firstSymbol && currentNumber < secondSymbol)
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
