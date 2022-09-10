using System;
using System.Linq;

namespace P10Radioactive
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            var rows = rowsAndColumns[0];
            var cols = rowsAndColumns[1];

            var field = new char[rows, cols];

            var rowPlayer = 0;
            var colPlayer = 0;

            ReadInput(rows, cols, field, ref rowPlayer, ref colPlayer);
            field[rowPlayer, colPlayer] = '.';

            var commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                var win = false;

                if (currentCommand == 'U')
                {
                    rowPlayer--;

                    if (rowPlayer < 0)
                    {
                        rowPlayer++;

                        win = true;
                    }
                }
                else if (currentCommand == 'D')
                {
                    rowPlayer++;

                    if (rowPlayer >= rows)
                    {
                        rowPlayer--;

                        win = true;
                    }
                }
                else if (currentCommand == 'L')
                {
                    colPlayer--;

                    if (colPlayer < 0)
                    {
                        colPlayer++;

                        win = true;
                    }
                }
                else if (currentCommand == 'R')
                {
                    colPlayer++;

                    if (colPlayer >= cols)
                    {
                        colPlayer--;

                        win = true;
                    }
                }

                SpreadBunnies(field, rows, cols);

                if (win)
                {
                    PrintFinalsState(field, rows, cols);

                    Console.WriteLine($"won: {rowPlayer} {colPlayer}");

                    return;
                }
                else if (field[rowPlayer, colPlayer] == 'B')
                {
                    PrintFinalsState(field, rows, cols);

                    Console.WriteLine($"dead: {rowPlayer} {colPlayer}");

                    return;
                }
                
            }
        }

        private static void ReadInput(int rows, int cols, char[,] field, ref int rowPlayer, ref int colPlayer)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }
        }

        private static void SpreadBunnies(char[,] field, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'B')
                    {
                        if (col - 1 >= 0)
                        {
                            if (field[row, col - 1] != 'B')
                            {
                                field[row, col - 1] = 'b';
                            }
                        }

                        if (col + 1 < cols)
                        {
                            if (field[row, col + 1] != 'B')
                            {
                                field[row, col + 1] = 'b';
                            }
                        }

                        if (row - 1 >= 0)
                        {
                            if (field[row - 1, col] != 'B')
                            {
                                field[row - 1, col] = 'b';
                            }
                        }

                        if (row + 1 < rows)
                        {
                            if (field[row + 1, col] != 'B')
                            {
                                field[row + 1, col] = 'b';
                            }
                        }
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (field[r, c] == 'b')
                    {
                        field[r, c] = 'B';
                    }
                }
            }
        }

        private static void PrintFinalsState(char[,] field, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
