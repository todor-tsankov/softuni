using System;
using System.Linq;

namespace P03PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfSquareMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];

            ReadMatrixFromTheConsole(sizeOfSquareMatrix, matrix);
            PrintSumOfPrimaryDiagonalOfSquareMatrix(sizeOfSquareMatrix, matrix);
        }

        private static void PrintSumOfPrimaryDiagonalOfSquareMatrix(int sizeOfSquareMatrix, int[,] matrix)
        {
            var sum = 0;

            for (int i = 0; i < sizeOfSquareMatrix; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }

        private static void ReadMatrixFromTheConsole(int sizeOfSquareMatrix, int[,] matrix)
        {
            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                for (int col = 0; col < sizeOfSquareMatrix; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
