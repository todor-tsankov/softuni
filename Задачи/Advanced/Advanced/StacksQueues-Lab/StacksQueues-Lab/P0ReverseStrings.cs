using System;
using System.Collections.Generic;

namespace StacksQueues_Lab
{
    class P0ReverseStrings
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var inputStack = new Stack<char>(input);

            var output = string.Join(string.Empty, inputStack);
            Console.WriteLine(output);
        }
    }
}
