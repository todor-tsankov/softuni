using System;

namespace SnakeGame.IO.Contracts
{
    public interface IReader
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
