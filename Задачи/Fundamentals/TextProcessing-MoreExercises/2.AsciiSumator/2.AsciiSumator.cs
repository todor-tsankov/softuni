using System;

namespace _2.AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            char firstSymbol = Console.ReadLine()[0];
            char secondSymbol = Console.ReadLine()[0];
            string input = Console.ReadLine();

            int startIndex = input.IndexOf(firstSymbol);
            int endIndex = input.IndexOf(secondSymbol);

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex < 0)
            {
                endIndex = input.Length - 1;
            }

            int sum = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += input[i];
            }

            Console.WriteLine(sum);

        }
    }
}
