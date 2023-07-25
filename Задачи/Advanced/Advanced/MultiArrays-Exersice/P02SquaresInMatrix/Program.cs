using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = new string[rows, cols];
            var equalCellsCounter = 0;

            ReadMatrix(rows, cols, matrix);

            equalCellsCounter = FindNumberOfEqualCells(rows, cols, matrix, equalCellsCounter);

            Console.WriteLine(equalCellsCounter);
        }

        private static int FindNumberOfEqualCells(int rows, int cols, string[,] matrix, int equalCellsCounter)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                      && matrix[row + 1, col] == matrix[row + 1, col + 1]
                      && matrix[row, col + 1] == matrix[row + 1, col])
                    {
                        equalCellsCounter++;
                    }

                }
            }

            return equalCellsCounter;
        }

        private static void ReadMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

    }
}
