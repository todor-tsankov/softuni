using System;
using System.IO;

namespace P02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var inputReader = new StreamReader("Input.txt");
            using var outputwriter = new StreamWriter("Output.txt");

            var counter = 1;

            while (true)
            {
                var currentLine = inputReader.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                outputwriter.WriteLine($"{counter}. {currentLine}");

                counter++;
            }
        }
    }
}
