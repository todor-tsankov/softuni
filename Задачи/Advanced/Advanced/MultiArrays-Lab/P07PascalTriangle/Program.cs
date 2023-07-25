using System;

namespace P07PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var pascalTriangle = new long[rows][];

            rows--;
            FillPascalTriangle(rows, pascalTriangle);

            PrintTriangle(pascalTriangle);
        }

        private static void FillPascalTriangle(int rows, long[][] pascalTriangle)
        {
            if (rows >= 0)
            {
                pascalTriangle[0] = new long[] { 1 };
            }

            if (rows >= 1)
            {
                pascalTriangle[1] = new long[] { 1, 1 };
            }

            for (int row = 2; row <= rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                pascalTriangle[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }

                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;
            }
        }

        private static void PrintTriangle(long[][] pascalTriangle)
        {
            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
