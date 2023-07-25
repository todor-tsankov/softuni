using System;
using System.IO;

namespace StreamsFilesDrectories_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            using var inputReader = new StreamReader(@"Input.txt");
            using var outputWriter = new StreamWriter(@"Output.txt");

            var counter = 0;

            while (true)
            {
                string currentLine = inputReader.ReadLine();

                if (currentLine == null)
                {
                    break;
                }

                if (counter % 2 != 0)
                {
                    outputWriter.WriteLine(currentLine);
                }

                counter++;
            }

            outputWriter.Flush();
        }
    }
}
