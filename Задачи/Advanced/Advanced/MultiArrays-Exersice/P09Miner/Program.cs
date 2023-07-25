using System;
using System.Linq;

namespace P09Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfTheField = int.Parse(Console.ReadLine());

            var movementCommands = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();

            var field = new char[sizeOfTheField, sizeOfTheField];

            var rowS = 0;
            var colS = 0;
            var numberCoalsAtBeginning = 0;
            var numberCoalsCollected = 0;

            ReadInputField(sizeOfTheField, field, ref rowS, ref colS, ref numberCoalsAtBeginning);

            for (int i = 0; i < movementCommands.Length; i++)
            {
                var currentCommand = movementCommands[i];

                var successMove = false;
                field[rowS, colS] = '*';

                if (currentCommand == "up" && rowS - 1 >= 0)
                {
                    successMove = true;

                    rowS--;
                }
                else if (currentCommand == "down" && rowS + 1 < sizeOfTheField)
                {
                    successMove = true;

                    rowS++;
                }
                else if (currentCommand == "left" && colS - 1 >= 0)
                {
                    successMove = true;

                    colS--;
                }
                else if (currentCommand == "right" && colS + 1 < sizeOfTheField)
                {
                    successMove = true;

                    colS++;
                }

                if (successMove)
                {
                    var foundChar = field[rowS, colS];

                    if (foundChar == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowS}, {colS})");

                        return;
                    }
                    else if (foundChar == 'c')
                    {
                        numberCoalsCollected++;

                        if (numberCoalsCollected == numberCoalsAtBeginning)
                        {
                            Console.WriteLine($"You collected all coals! ({rowS}, {colS})");

                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"{numberCoalsAtBeginning - numberCoalsCollected} coals left. ({rowS}, {colS})");
        }

        private static void ReadInputField(int sizeOfTheField, char[,] field, ref int rowS, ref int colS, ref int numCoals)
        {
            for (int row = 0; row < sizeOfTheField; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                for (int col = 0; col < sizeOfTheField; col++)
                {
                    var currentChar = currentRow[col][0];

                    field[row, col] = currentChar;

                    if (currentChar == 's')
                    {
                        rowS = row;
                        colS = col;
                    }

                    if (currentChar == 'c')
                    {
                        numCoals++;
                    }
                }
            }
        }
    }
}
