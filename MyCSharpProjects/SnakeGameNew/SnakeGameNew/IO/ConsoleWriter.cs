using System;

using SnakeGame.IO.Contracts;

namespace SnakeGame.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(char ch)
        {
            Console.Write(ch);
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(char ch)
        {
            Console.WriteLine(ch);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
