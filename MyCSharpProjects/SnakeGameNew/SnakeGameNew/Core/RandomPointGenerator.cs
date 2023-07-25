using System;
using System.Linq;
using System.Collections.Generic;

using SnakeGame.Models;
using SnakeGame.Common;
using SnakeGame.Core.Contracts;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Core
{
    public class RandomPointGenerator : IRandomPointGenerator
    {
        private readonly ICollection<IPoint> snake;
        private readonly Random randomIndexGenerator;

        public RandomPointGenerator(ICollection<IPoint> snake, Random randomIndexGenerator)
        {
            this.snake = snake;
            this.randomIndexGenerator = randomIndexGenerator;
        }

        public IPoint ProduceRandomPoint()
        {
            var freeSpaces = new List<IPoint>();

            for (int row = Constants.MinRowIndex; row <= Constants.MaxRowIndex; row++)
            {
                for (int col = Constants.MinColIndex; col <= Constants.MaxColIndex; col++)
                {
                    var isValid = this.snake.Any(p => p.Row == row && p.Col == col);

                    if (!isValid)
                    {
                        var point = new Point(row, col);

                        freeSpaces.Add(point);
                    }
                }
            }

            var index = this.randomIndexGenerator.Next(0, freeSpaces.Count);

            return freeSpaces[index];
        }
    }
}
