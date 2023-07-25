using System;

namespace P04SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            ReadMatrix(n, matrix);

            var symbol = Console.ReadLine()[0];

            FindSymbolCoordinatesInMatrix(n, matrix, symbol);

        }

        private static void FindSymbolCoordinatesInMatrix(int n, char[,] matrix, char symbol)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");

                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }

        private static void ReadMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine()
                                        .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
