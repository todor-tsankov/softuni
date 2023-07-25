using System;
using System.Collections.Generic;
using System.Linq;

namespace P05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            string snake = Console.ReadLine();

            var snakeQueue = new Queue<char>(snake);

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var snakeMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (!snakeQueue.Any())
                        {
                            snakeQueue = new Queue<char>(snake);
                        }

                        snakeMatrix[row, col] = snakeQueue.Dequeue();
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (!snakeQueue.Any())
                        {
                            snakeQueue = new Queue<char>(snake);
                        }

                        snakeMatrix[row, col] = snakeQueue.Dequeue();
                    }
                }
            }

            Print(rows, cols, snakeMatrix);
        }

        private static void Print(int rows, int cols, char[,] snakeMatrix)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(snakeMatrix[r, c]);
                }

                Console.WriteLine();
            }
        }
    }
}
