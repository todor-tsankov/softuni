using System;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite.IO
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
