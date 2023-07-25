using System;
using System.Collections.Generic;
using System.Linq;

namespace P02StackSum
{
    class P02StackSum
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse);

            var numbersStack = new Stack<int>(numbers);

            

            while (true)
            {
                var command = Console.ReadLine()
                                     .ToLower()
                                     .Split();

                var op = command[0];

                if (op == "add")
                {
                    var firstNumber = int.Parse(command[1]);
                    var secondNumber = int.Parse(command[2]);

                    numbersStack.Push(firstNumber);
                    numbersStack.Push(secondNumber);
                }
                else if (op == "remove")
                {
                    var count = int.Parse(command[1]);

                    if (count > numbersStack.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        numbersStack.Pop();
                    }
                }
                else
                {
                   break;
                }
            }

            var sum = numbersStack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
