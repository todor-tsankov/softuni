using System;

using SnakeGame.Models.Contracts;

namespace SnakeGame.Core.Contracts
{
    public interface IKeyInterpreter
    {
        bool Execute(ConsoleKey key, ref ConsoleKey currentDirection, IPoint firstSegment);
    }
}
