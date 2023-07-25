using System;
using System.Collections.Generic;

namespace P04MatchingBrackets
{
    class P04MatchingBrackets
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (currentChar == '(')
                {
                    indexes.Push(i);
                }
                else if (currentChar == ')')
                {
                    var startIndex = indexes.Pop();

                    var outputString = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(outputString);
                }
            }
        }
    }
}
