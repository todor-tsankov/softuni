using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            var dimestions = ReadInputNumbers();

            var rows = dimestions[0];
            var cols = dimestions[1];

            var matrix = GetMatrix(rows, cols);
            var sum = ProcessCommands(rows, cols, matrix);

            Console.WriteLine(sum);
        }

        private static long ProcessCommands(int rows, int cols, int[,] matrix)
        {
            var sum = 0L;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Let the Force be with you")
                {
                    break;
                }

                var ivoCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];

                var evilCoordinates = ReadInputNumbers();

                var evilRow = evilCoordinates[0];
                var evilCol = evilCoordinates[1];

                DestroyStars(rows, cols, matrix, ref evilRow, ref evilCol);
                CollectStars(matrix, ref sum, ref ivoRow, ref ivoCol);
            }

            return sum;
        }

        private static void CollectStars(int[,] matrix, ref long sum, ref int ivoRow, ref int ivoCol)
        {
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private static void DestroyStars(int rows, int cols, int[,] matrix, ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < rows && evilCol >= 0 && evilCol < cols)
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static int[,] GetMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            var value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            return matrix;
        }

        private static int[] ReadInputNumbers()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
        }
    }
}
