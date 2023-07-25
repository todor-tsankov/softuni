using System;
using System.Linq;
using System.Collections.Generic;

using SnakeGame.Models.Contracts;
using SnakeGame.Common;

namespace SnakeGame.Models
{
    public class RandomPointGenerator
    {
        private readonly ICollection<ISnakeSegment> snake;
        private readonly Random randomIndexGenerator;

        public RandomPointGenerator(ICollection<ISnakeSegment> snake, Random randomIndexGenerator)
        {
            this.snake = snake;
            this.randomIndexGenerator = randomIndexGenerator;
        }

        public IPoint ProduceRandomPoint()
        {
            var freeSpaces = new List<IPoint>();

            for (int row = Constants.MIN_ROW_INDEX; row <= Constants.MAX_ROW_INDEX; row++)
            {
                for (int col = Constants.MIN_COL_INDEX; col <= Constants.MAX_COL_INDEX; col++)
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
