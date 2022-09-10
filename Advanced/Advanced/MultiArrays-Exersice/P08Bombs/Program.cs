using System;
using System.Linq;

namespace P08Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());
            var matrix = new int[sizeOfMatrix, sizeOfMatrix];

            ReadMatrix(sizeOfMatrix, matrix);

            var bombs = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                var rowAndCol = bombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries);

                var row = int.Parse(rowAndCol[0]);
                var col = int.Parse(rowAndCol[1]);

                var bombValue = matrix[row, col];

                if (bombValue <= 0)
                {
                    continue;
                }

                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        if (r >= 0 && r < sizeOfMatrix && c >= 0 && c < sizeOfMatrix)
                        {
                            if (matrix[r, c] > 0)
                            {
                                matrix[r, c] -= bombValue;
                            }
                        }
                    }
                } 
            }

            var activeCellsCount = 0;
            var sum = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    activeCellsCount++;

                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {activeCellsCount}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void ReadMatrix(int sizeOfMatrix, int[,] matrix)
        {
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
