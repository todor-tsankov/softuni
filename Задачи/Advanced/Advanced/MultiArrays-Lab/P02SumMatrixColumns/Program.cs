using System;
using System.Linq;

namespace P02SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = ReadRowFromConsole(',', ' ');

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = new int[rows, cols];

            ReadMatrixFromConsole(rows, cols, matrix);
            PrintSumOfColumnsMatrix(rows, cols, matrix);
        }

        private static void PrintSumOfColumnsMatrix(int rows, int cols, int[,] matrix)
        {
            for (int c = 0; c < cols; c++)
            {
                var sum = 0;

                for (int r = 0; r < rows; r++)
                {
                    sum += matrix[r, c];
                }

                Console.WriteLine(sum);
            }
        }

        private static void ReadMatrixFromConsole(int rows, int cols, int[,] matrix)
        {
            for (int r = 0; r < rows; r++)
            {
                var currentRow = ReadRowFromConsole();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }
        }

        static int[] ReadRowFromConsole(params char[] separators)
        {
            var result = Console.ReadLine()
                                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            return result;
        }
    }
}
