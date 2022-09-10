using System;
using System.Collections.Generic;

namespace P09TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var text = string.Empty;
            var textStates = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine()
                                     .Split();

                var commandType = cmdArgs[0];

                if (commandType == "1")
                {
                    textStates.Push(text);

                    text += cmdArgs[1];
                }
                else if (commandType == "2")
                {
                    textStates.Push(text);
                    var count = int.Parse(cmdArgs[1]);

                    text = text.Substring(0, text.Length - count);  // check for - 1
                }
                else if (commandType == "3")
                {
                    var index = int.Parse(cmdArgs[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (commandType == "4")
                {
                    text = textStates.Pop();
                }
            }
        }
    }
}
