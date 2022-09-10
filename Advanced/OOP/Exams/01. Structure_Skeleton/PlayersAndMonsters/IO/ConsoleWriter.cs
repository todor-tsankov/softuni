﻿using System;

using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
