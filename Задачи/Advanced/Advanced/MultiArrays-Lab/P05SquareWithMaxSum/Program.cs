using System;
using System.Linq;

namespace P05SquareWithMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = ReadInputLineFromConsole();

            var rows = rowsAndColumns[0];
            var cols = rowsAndColumns[1];

            var matrix = new int[rows, cols];
            ReadMatrix(rows, cols, matrix);

            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            FindMaxSum(rows, cols, matrix, ref maxSum, ref maxRow, ref maxCol);
            PrintResult(matrix, maxSum, maxRow, maxCol);
        }

        private static void PrintResult(int[,] matrix, int maxSum, int maxRow, int maxCol)
        {
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static void FindMaxSum(int rows, int cols, int[,] matrix, ref int maxSum, ref int maxRow, ref int maxCol)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var currentSum = matrix[row, col]
                                     + matrix[row, col + 1]
                                     + matrix[row + 1, col] +
                                     +matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
        }

        private static void ReadMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ReadInputLineFromConsole();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        static int[] ReadInputLineFromConsole()
        {
            return Console.ReadLine()
                          .Split(", ")
                          .Select(int.Parse)
                          .ToArray();
        }
    }
}
