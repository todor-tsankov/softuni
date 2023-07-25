using System;

using SnakeGame.IO.Contracts;

namespace SnakeGame.IO
{
    public class ConsoleReader : IReader
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
