using SnakeGame.Models.Contracts;

namespace SnakeGame.Core.Contracts
{
    public interface IRandomPointGenerator
    {
        IPoint ProduceRandomPoint();
    }
}
