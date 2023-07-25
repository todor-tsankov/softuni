using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine()
                                         .Split();

                var cmd = commandArgs[0];

                if (cmd == "1")
                {
                    var x = commandArgs[1];

                    stack.Push(x);
                }
                else if (cmd == "2")
                {
                    stack.Pop();
                }
                else if (cmd == "3")
                {
                    Console.WriteLine(stack.Max());
                }
                else if (cmd == "4")
                {
                    Console.WriteLine(stack.Min());
                }
            }

            var output = string.Join(", ", stack);

            Console.WriteLine(output);
        }
    }
}
