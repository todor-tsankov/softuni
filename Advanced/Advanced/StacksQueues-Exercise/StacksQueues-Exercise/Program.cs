using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksQueues_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputElements = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

            var inputIntegers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

            var push = inputElements[0];
            var pop = inputElements[1];
            var find = inputElements[2];

            var stack = new Stack<int>();

            for (int i = 0; i < push; i++)
            {
                stack.Push(inputIntegers[i]);
            }

            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(find))
            {
                Console.WriteLine("true");
            }
            else if(!stack.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
