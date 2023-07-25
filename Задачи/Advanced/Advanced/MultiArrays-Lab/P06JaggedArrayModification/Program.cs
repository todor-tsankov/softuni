using System;
using System.Linq;

namespace P06JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new int[rows][];

            ReadJaggedArrray(rows, jaggedArray);
            ModificateJaggedArray(jaggedArray);

            Print(rows, jaggedArray);
        }

        private static void Print(int rows, int[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                var output = string.Join(" ", jaggedArray[row]);

                Console.WriteLine(output);
            }
        }

        private static void ModificateJaggedArray(int[][] jaggedArray)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var commandParts = command.Split();

                var commandType = commandParts[0];

                var row = int.Parse(commandParts[1]);
                var col = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);

                if (row < 0
                    || col < 0
                    || row >= jaggedArray.Length
                    || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (commandType == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (commandType == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }
        }

        private static void ReadJaggedArrray(int rows, int[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                jaggedArray[row] = currentRow;
            }
        }
    }
}
