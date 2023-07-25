using System;
using System.Collections.Generic;
using System.Linq;

namespace P03SimpleCalculator
{
    class P03SimpleCalculator
    {
        static void Main()
        {
            var inputArray = Console.ReadLine()
                                    .Split()
                                    .Reverse();

            var stack = new Stack<string>(inputArray);

            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var operat = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                var result = 0;

                if (operat == "+")
                {
                    result = firstNumber + secondNumber;
                }
                else
                {
                    result = firstNumber - secondNumber;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
