using System;
using System.IO;

namespace P04MergefFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using var firstFileReader = new StreamReader("Input1.txt");
            using var secondFileReader = new StreamReader("Input2.txt");
            using var outputwriter = new StreamWriter("Output.txt");

            bool escape = false;

            while (!escape)
            {
                var firstFileCurrentLine = firstFileReader.ReadLine();
                var secondFileCurrentLine = secondFileReader.ReadLine();

                escape = true;

                if (firstFileCurrentLine != null)
                {
                    outputwriter.WriteLine(firstFileCurrentLine);

                    escape = false;
                }

                if (secondFileCurrentLine != null)
                {
                    outputwriter.WriteLine(secondFileCurrentLine);

                    escape = false;
                }
            }
        }
    }
}
