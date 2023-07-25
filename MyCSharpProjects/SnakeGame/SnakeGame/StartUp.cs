using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using SnakeGame.Core;
using SnakeGame.Common;
using SnakeGame.Models;
using SnakeGame.Models.Contracts;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            EnsureHighscoreFileExistence();

            var highscoreInfo = File.ReadAllText(Constants.HIGHSCORE_FILE_PATH)
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            var field = CreateInitialField();
            var snake = CreateInitialSnake();

            var random = new Random();
            var snakeEngine = new SnakeEngine(field, snake, random, highscoreInfo);

            snakeEngine.Run();
        }

        private static void EnsureHighscoreFileExistence()
        {
            var exists = File.Exists(Constants.HIGHSCORE_FILE_PATH);

            if (!exists)
            {
                File.Create(Constants.HIGHSCORE_FILE_PATH);
                File.WriteAllText(Constants.HIGHSCORE_FILE_PATH, "def 0/0/0 10");
            }

            Thread.Sleep(500);
        }

        private static char[,] CreateInitialField()
        {
            var initialField = new char[Constants.PLAYABLE_ROWS_COUNT + 2, Constants.PLAYABLE_COLS_COUNT + 2];

            for (int row = 0; row < Constants.PLAYABLE_ROWS_COUNT + 2; row++)
            {
                var firstLast = Constants.DEFAULT_SIDES_CHAR;
                var middle = Constants.DEFAULT_INSIDE_CHAR;

                if (row == 0 || row == Constants.PLAYABLE_ROWS_COUNT + 1)
                {
                    firstLast = Constants.DEFAULT_EDGE_CHAR;
                    middle = Constants.DEFAULT_FLOORS_CHAR;
                }

                for (int col = 0; col < Constants.PLAYABLE_COLS_COUNT + 2; col++)
                {
                    if (col == 0 || col == Constants.PLAYABLE_COLS_COUNT + 1)
                    {
                        initialField[row, col] = firstLast;
                    }
                    else
                    {
                        initialField[row, col] = middle;
                    }
                }
            }

            return initialField;
        }

        private static IList<ISnakeSegment> CreateInitialSnake()
        {
            var firstSegment = new SnakeSegment(Constants.SNAKE_INITIAL_ROW, Constants.SNAKE_INITIAL_COL);

            var snake = new List<ISnakeSegment>
            {
                firstSegment
            };

            return snake;
        }
    }
}
