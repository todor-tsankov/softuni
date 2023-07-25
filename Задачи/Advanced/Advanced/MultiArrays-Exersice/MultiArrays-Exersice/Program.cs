using System;
using System.Linq;

namespace MultiArrays_Exersice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfMatrix, sizeOfMatrix];


            ReadMatrix(sizeOfMatrix, matrix);

            var primarySum = PrimaryDiagonalSum(matrix, sizeOfMatrix);
            var secondarySum = SecondaryDiagonalSum(matrix, sizeOfMatrix);

            var absoluteValue = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(absoluteValue);
        }

        private static int SecondaryDiagonalSum(int[,] matrix, int sizeOfMatrix)
        {
            var secondarySum = 0;

            for (int i = sizeOfMatrix - 1; i >= 0; i--)
            {
                var currentRow = sizeOfMatrix - i - 1;

                secondarySum += matrix[currentRow, i];
            }

            return secondarySum;
        }

        private static void ReadMatrix(int sizeOfMatrix, int[,] matrix)
        {
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static int PrimaryDiagonalSum(int[,] matrix, int sizeOfMatrix)
        {
            var primarySum = 0;

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                primarySum += matrix[i, i];
            }

            return primarySum;
        }
    }
}
