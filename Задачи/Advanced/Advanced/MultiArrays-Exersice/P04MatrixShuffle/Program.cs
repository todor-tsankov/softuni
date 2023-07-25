using System;
using System.Linq;

namespace P04MatrixShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = ReadArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = ReadMatrixFromConsole(rows, cols);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var commandParts = command.Split();

                if (commandParts.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var swap = commandParts[0];

                var row1 = int.Parse(commandParts[1]);
                var col1 = int.Parse(commandParts[2]);
                var row2 = int.Parse(commandParts[3]);
                var col2 = int.Parse(commandParts[4]);

                if (swap != swap 
                    || row1 < 0 
                    || row2 < 0 
                    || col1 < 0 
                    || col2 < 0
                    || row1 >= rows
                    || row2 >= rows
                    || col1 >= cols
                    || col2 >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var saveFirst = matrix[row1, col1];

                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = saveFirst;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        static int[] ReadArray()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        static string[,] ReadMatrixFromConsole(int rows, int cols)
        {
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
