using System;
using System.IO;
using SnakeGame.Common;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Core
{
    public class SnakePrinter
    {
        public int PrintInitialInfoScreen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  This is a simple snake game by Toshko (version 1.1)");
            Console.WriteLine();
            Console.WriteLine("  Powered by lidl, myprotein, stenataSu");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Controls: UP, DOWN, LEFT, RIGHT");
            Console.WriteLine();
            Console.Write("  Choose difficult: 1-10:  ");

            var difficulty = int.Parse(Console.ReadLine());

            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Press any key to start...");
            Console.ReadKey();
            Console.Clear();

            if (difficulty < 1 || difficulty > 10)
            {
                difficulty = 1;
            }

            return difficulty;
        }

        public void PrintStats(int points)
        {
            Console.SetCursorPosition(Constants.MIN_COL_INDEX, Constants.PLAYABLE_ROWS_COUNT + 3);
            Console.WriteLine($"Current points: {points}");
        }

        public void PrintSegment(ISnakeSegment snakeSegment)
        {
            Console.SetCursorPosition(snakeSegment.Col, snakeSegment.Row);
            Console.Write(Constants.SNAKE_CHAR);
        }

        public void EraseSegment(ISnakeSegment snakeSegment)
        {
            Console.SetCursorPosition(snakeSegment.Col, snakeSegment.Row);
            Console.Write(Constants.DEFAULT_INSIDE_CHAR);
        }

        public void PrintPoint(IPoint point)
        {
            Console.SetCursorPosition(point.Col, point.Row);
            Console.Write(Constants.POINT_CHAR);
        }

        public void PrintEndResult(string[] highscore, bool newHighscore, int newHighscoreInt)
        {
            Console.SetCursorPosition(0 , Constants.MAX_ROW_INDEX + 5);

            if (newHighscore)
            {
                Console.CursorVisible = true;
                Console.Write("   New Highscore, please enter your name: ");

                var name = Console.ReadLine();
                var dateStr = DateTime.Now.ToString("dd/MM/yyyy:mm/hh");

                var str = $"{name} {dateStr} {newHighscoreInt}";

                File.WriteAllText(Constants.HIGHSCORE_FILE_PATH, str);
            }
            else
            {
                Console.WriteLine("   Game over!");
                Console.WriteLine();
                Console.WriteLine($"   HighScore ->  Name: {highscore[0]}, Date: {highscore[1]}, Points {highscore[2]}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"   Press escape to exit...");

                Console.CursorVisible = false;

                while (true)
                {
                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            }
        }

        public void PrintInititalField(char[,] field)
        {
            for (int row = 0; row < Constants.PLAYABLE_ROWS_COUNT + 2; row++)
            {
                for (int col = 0; col < Constants.PLAYABLE_COLS_COUNT + 2; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
