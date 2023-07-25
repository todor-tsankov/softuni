using System.Collections.Generic;

using SnakeGame.Models;
using SnakeGame.Common;
using SnakeGame.Models.Contracts;
using SnakeGame.Factories.Contracts;

namespace SnakeGame.Factories
{
    public class SnakeFactory : ISnakeFactory
    {
        public IList<IPoint> ProduceSnake()
        {
            var firstSegment = new Point(Constants.SnakeInitialRow, Constants.SnakeInitialCol);

            var snake = new List<IPoint>
            {
                firstSegment
            };

            return snake;
        }
    }
}
