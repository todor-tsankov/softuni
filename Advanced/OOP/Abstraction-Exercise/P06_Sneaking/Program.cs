using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            ReadRoom(rows);

            var moves = Console.ReadLine()
                               .ToCharArray();

            var samPosition = FindSamsPosition();
            ProcessMoves(moves, samPosition);
        }

        private static void ProcessMoves(char[] moves, int[] samPosition)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();
                var enemyPosition = GetEnemy(samPosition);

                IsSamDead(samPosition, enemyPosition);
                room[samPosition[0]][samPosition[1]] = '.';

                MoveSam(moves, samPosition, i);
                room[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        enemyPosition[0] = samPosition[0];
                        enemyPosition[1] = j;
                    }
                }

                if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && samPosition[0] == enemyPosition[0])
                {
                    room[enemyPosition[0]][enemyPosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintMatrix();
                    Environment.Exit(0);
                }
            }
        }

        private static void IsSamDead(int[] samPosition, int[] enemyPosition)
        {
            if (samPosition[1] < enemyPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'd' && enemyPosition[0] == samPosition[0])
            {
                Printresult(samPosition);
            }
            else if (enemyPosition[1] < samPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == samPosition[0])
            {
                Printresult(samPosition);
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';

                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void MoveSam(char[] moves, int[] samPosition, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void Printresult(int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

            PrintMatrix();
            Environment.Exit(0);
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] GetEnemy(int[] samPosition)
        {
            var enemyPosition = new int[2];

            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    enemyPosition[0] = samPosition[0];
                    enemyPosition[1] = j;
                }
            }

            return enemyPosition;
        }

        private static int[] FindSamsPosition()
        {
            var samPosition = new int[2];
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            return samPosition;
        }

        private static void ReadRoom(int rows)
        {
            room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                                   .ToCharArray();

                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
