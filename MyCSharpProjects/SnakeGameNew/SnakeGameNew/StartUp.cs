using System;
using System.IO;
using System.Linq;

using SnakeGame.Core;
using SnakeGame.Common;
using SnakeGame.Factories;

namespace SnakeGameNew
{
    public static class StartUp
    {
        public static void Main()
        {
            var snakeFactory = new SnakeFactory();
            var fieldFactory = new FieldFactory();

            var snake = snakeFactory.ProduceSnake();
            var field = fieldFactory.ProduceField();

            var highScoreInfo = File.ReadAllText(Constants.HighscoreFilePath)
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            var random = new Random();

            var snakeEngine = new SnakeEngine(snake, random, field, highScoreInfo);

            snakeEngine.Run();
        }
    }
}
