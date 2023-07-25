using System;
using System.IO;
using System.Linq;

namespace StreamsFilesDirectories_Exercise
{
    class Program
    {
        static void Main()
        {
            using var inputReader = new StreamReader("text.txt");

            var punctuationSigns = new char[] { '-', ',', '.', '!', '?' };
            var counter = 0;

            while (true)
            {
                var currentLine = inputReader.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                   var replacedAndReversed = currentLine.Replace('-', '@')
                                                        .Replace(',', '@')
                                                        .Replace('.', '@')
                                                        .Replace('!', '@')
                                                        .Replace('?', '@')
                                                        .Split(" ")
                                                        .Reverse()
                                                        .ToArray();

                    Console.WriteLine(string.Join(" ", replacedAndReversed));
                }

                counter++;
            }
        }
    }
}
