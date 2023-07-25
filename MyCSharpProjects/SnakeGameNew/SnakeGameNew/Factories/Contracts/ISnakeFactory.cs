using System.Collections.Generic;

using SnakeGame.Models.Contracts;

namespace SnakeGame.Factories.Contracts
{
    public interface ISnakeFactory
    {
        IList<IPoint> ProduceSnake();
    }
}
