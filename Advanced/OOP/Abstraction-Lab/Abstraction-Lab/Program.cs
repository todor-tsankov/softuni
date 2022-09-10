using System;

namespace Abstraction_Lab
{
    public class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            PrintUpperHalf(n);
            PrintLowerHalf(n);
        }

        private static void PrintUpperHalf(int n)
        {
            for (int row = 0; row < n; row++)
            {
                PrintRow(n, row);
            }
        }
        private static void PrintLowerHalf(int n)
        {
            for (int row = n - 2; row >= 0; row--)
            {
                PrintRow(n, row);
            }
        }

        static void PrintRow(int n, int currentRow)
        {
            var numberOfSpaces = n - currentRow - 1;
            var blankSpace = new string(' ', numberOfSpaces);

            Console.Write(blankSpace);

            for (int i = 0; i <= currentRow; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}

