﻿using System;
using ExplicitInterfaces.IO.Contracts;

namespace ExplicitInterfaces.IO.ConsoleIO
{
    public class ConsoleReader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
