using System;
using System.Collections.Generic;
using System.Linq;

namespace P07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfBoard = int.Parse(Console.ReadLine());

            var chessMatrix = new char[sizeOfBoard, sizeOfBoard];
            var knights = new Dictionary<Knight, int>();

            ReadInputChessMatrix(sizeOfBoard, chessMatrix);

            var numberOfKnigthsRemoved = 0;

            while (true)
            {
                for (int row = 0; row < sizeOfBoard; row++)
                {
                    for (int col = 0; col < sizeOfBoard; col++)
                    {
                        if (chessMatrix[row, col] == 'K')
                        {
                            var currentKnight = new Knight(row, col);

                            if (!knights.ContainsKey(currentKnight))
                            {

                                knights.Add(currentKnight, 0);
                            }

                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                if (chessMatrix[row - 1, col - 2] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                if (chessMatrix[row - 2, col - 1] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row - 2 >= 0 && col + 1 < sizeOfBoard)
                            {
                                if (chessMatrix[row - 2, col + 1] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row - 1 >= 0 && col + 2 < sizeOfBoard)
                            {
                                if (chessMatrix[row - 1, col + 2] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row + 1 < sizeOfBoard && col + 2 < sizeOfBoard)
                            {
                                if (chessMatrix[row + 1, col + 2] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row + 2 < sizeOfBoard && col + 1 < sizeOfBoard)
                            {
                                if (chessMatrix[row + 2, col + 1] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }
                            if (row + 1 < sizeOfBoard && col - 2 >= 0)
                            {
                                if (chessMatrix[row + 1, col - 2] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }

                            if (row + 2 < sizeOfBoard && col - 1 >= 0)
                            {
                                if (chessMatrix[row + 2, col - 1] == 'K')
                                {
                                    knights[currentKnight]++;
                                }
                            }
                        }
                    }
                }

                if (knights.Where(i => i.Value != 0).Any())
                {
                    var maxInt = -1;
                    var bestKnight = FindsBestKnight(knights, ref maxInt);

                    if (bestKnight.Row >= 0 && maxInt >= 1)
                    {
                        chessMatrix[bestKnight.Row, bestKnight.Col] = '0';
                        numberOfKnigthsRemoved++;
                    }

                    knights = new Dictionary<Knight, int>()
;
                }
                else
                {
                    break;
                }
            }
            

            Console.WriteLine(numberOfKnigthsRemoved);
        }

        private static void ReadInputChessMatrix(int sizeOfBoard, char[,] chessMatrix)
        {
            for (int row = 0; row < sizeOfBoard; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < sizeOfBoard; col++)
                {
                    chessMatrix[row, col] = currentRow[col];
                }
            }
        }

        private static Knight FindsBestKnight(Dictionary<Knight, int> knigths, ref int maxInt)
        {
            Knight max = new Knight(-1,-1);

            foreach (var knight in knigths)
            {
                if (knight.Value > maxInt)
                {
                    maxInt = knight.Value;

                    max = knight.Key;
                }
            }

            return max;
        }
    }

    class Knight
    {
        public Knight(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }


}