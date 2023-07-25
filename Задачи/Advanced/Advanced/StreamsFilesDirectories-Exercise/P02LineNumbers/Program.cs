using System;
using System.IO;

namespace P02LineNumbers
{
    class Program
    {
        static void Main()
        {
            var inputTextLines = File.ReadAllLines("text.txt");

            var length = inputTextLines.Length;

            var outputTextLines = new string[length];

            for (int i = 0; i < length; i++)
            {
                var currentLine = inputTextLines[i];

                var countLetters = FindCountLetters(currentLine);
                var countPunctuation = FindCountPunctuation(currentLine);

                outputTextLines[i] = $"Line {i + 1}: {currentLine} ({countLetters})({countPunctuation})";
            }

            File.WriteAllLines(@"..\..\..\output.txt", outputTextLines);

            static int FindCountLetters(string currentLine)
            {
                var counter = 0;

                foreach (var symbol in currentLine)
                {
                    if (char.IsLetter(symbol))
                    {
                        counter++;
                    }
                }

                return counter;
            }

            static int FindCountPunctuation(string currentLine)
            {
                var counter = 0;

                foreach (var symbol in currentLine)
                {
                    if (char.IsPunctuation(symbol))
                    {
                        counter++;
                    }
                }

                return counter;
            }
        }
    }
}
