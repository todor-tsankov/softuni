using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = ReadArray();

            var rows = rowsAndColumns[0];
            var cols = rowsAndColumns[1];

            var matrix = ReadMatrixFromConsole(rows, cols);

            var bestMatrixQueue = new Queue<int>();
            var sum = int.MinValue;
            
            FindLargestSum(matrix, rows, cols, ref bestMatrixQueue, ref sum);
            Print(bestMatrixQueue, sum);
        }

        private static void Print(Queue<int> bestMatrixQueue, int sum)
        {
            Console.WriteLine($"Sum = {sum}");

            for (int i = 0; i < 9; i++)
            {
                if (i == 3 || i == 6)
                {
                    Console.WriteLine();
                }

                Console.Write(bestMatrixQueue.Dequeue() + " ");
            }
        }

        static int[] ReadArray()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        static int[,] ReadMatrixFromConsole(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = ReadArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

        static void FindLargestSum(int[,] matrix, int rows, int cols, ref Queue<int> bestMatrixQueue, ref int maxSum) 
        {
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentSum = 0;
                    var currentMatrixString = new Queue<int>();

                    for (int r = row; r < row + 3; r++)
                    {
                        for (int c = col; c < col + 3; c++)
                        {
                            currentSum += matrix[r, c];
                            currentMatrixString.Enqueue(matrix[r, c]);
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestMatrixQueue = currentMatrixString;
                    }
                }
            }
        }
    }
}
