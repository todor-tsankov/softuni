using System;
using System.Collections.Generic;
using System.Linq;

namespace P08ParenthesisSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine();

            var stack = new Stack<char>();

            var isBalanced = true;

            for (int i = 0; i < sequence.Length; i++)
            {
                var currentChar = sequence[i];

                if (currentChar == '(' ||
                    currentChar == '[' ||
                    currentChar == '{' )
                {
                    stack.Push(currentChar);
                }
                else if (currentChar == ')' && stack.Any())
                {
                    var lastOpeningChar = stack.Pop();

                    if (lastOpeningChar != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (currentChar == ']' && stack.Any())
                {
                    var lastOpeningChar = stack.Pop();

                    if (lastOpeningChar != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (currentChar == '}' && stack.Any())
                {
                    var lastOpeningChar = stack.Pop();

                    if (lastOpeningChar != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
