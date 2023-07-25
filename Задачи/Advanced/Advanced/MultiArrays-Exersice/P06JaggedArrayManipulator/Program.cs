using System;
using System.Linq;

namespace P06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var jaggedArray = new double[rows][];

            ReadJaggedArray(rows, jaggedArray);
            MakeModifications(rows, jaggedArray);

            ReadCommandsAndMakeChanges(jaggedArray);
            Print(jaggedArray);
        }

        private static void Print(double[][] jaggedArray)
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void ReadCommandsAndMakeChanges(double[][] jaggedArray)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var commandParts = command.Split();
                var op = commandParts[0];

                var row = int.Parse(commandParts[1]);
                var column = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);

                if (row >= 0
                       && row < jaggedArray.Length
                       && column >= 0
                       && column < jaggedArray[row].Length)
                {
                    if (op == "Add")
                    {

                        jaggedArray[row][column] += value;
                    }
                    else if (op == "Subtract")
                    {
                        jaggedArray[row][column] -= value;
                    }
                }

            }
        }

        private static void MakeModifications(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(i => i * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(i => i * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(i => i / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(i => i / 2).ToArray();
                }
            }
        }

        private static void ReadJaggedArray(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse)
                                        .ToArray();

                jaggedArray[row] = currentRow;
            }
        }
    }
}
