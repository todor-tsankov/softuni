using System;

namespace P02
{
    class P02
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var countCommands = int.Parse(Console.ReadLine());

            var pRow = 0;
            var pCol = 0;

            var matrix = new char[size, size];
            ReadMatrix(size, ref pRow, ref pCol, matrix);

            matrix[pRow, pCol] = '-';

            var success = false;

            for (int i = 0; i < countCommands; i++)
            {
                var direction = Console.ReadLine();

                MovePlayer(size, ref pRow, ref pCol, direction);

                var nextChar = matrix[pRow, pCol];

                if (nextChar == 'F')
                {
                    success = true;
                    break;
                }
                else if (nextChar == 'B')
                {
                    MovePlayer(size, ref pRow, ref pCol, direction);

                    if (matrix[pRow, pCol] == 'F')
                    {
                        success = true;
                        break;
                    }
                }
                else if (nextChar == 'T')
                {
                    direction = ChangeDirection(direction);

                    MovePlayer(size, ref pRow, ref pCol, direction);

                    if (matrix[pRow, pCol] == 'F')
                    {
                        success = true;
                        break;
                    }
                }

                matrix[pRow, pCol] = '-';
            }

            Print(size, pRow, pCol, matrix, success);
        }

        private static void Print(int size, int pRow, int pCol, char[,] matrix, bool success)
        {
            if (success)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            matrix[pRow, pCol] = 'f';

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static string ChangeDirection(string direction)
        {
            if (direction == "up")
            {
                direction = "down";
            }
            else if (direction == "down")
            {
                direction = "up";
            }
            else if (direction == "left")
            {
                direction = "right";
            }
            else if (direction == "right")
            {
                direction = "left";
            }

            return direction;
        }

        private static void MovePlayer(int size, ref int pRow, ref int pCol, string direction)
        {
            if (direction == "up")
            {
                if (pRow - 1 >= 0)
                {
                    pRow--;
                }
                else
                {
                    pRow = size - 1;
                }
            }
            else if (direction == "down")
            {
                if (pRow + 1 < size)
                {
                    pRow++;
                }
                else
                {
                    pRow = 0;
                }
            }
            else if (direction == "left")
            {
                if (pCol - 1 >= 0)
                {
                    pCol--;
                }
                else
                {
                    pCol = size - 1;
                }
            }
            else if (direction == "right")
            {
                if (pCol + 1 < size)
                {
                    pCol++;
                }
                else
                {
                    pCol = 0;
                }
            }
        }

        private static void ReadMatrix(int size, ref int pRow, ref int pCol, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    var currentChar = currentRow[col];

                    if (currentChar == 'f')
                    {
                        pRow = row;
                        pCol = col;
                    }

                    matrix[row, col] = currentChar;
                }
            }
        }
    }
}
