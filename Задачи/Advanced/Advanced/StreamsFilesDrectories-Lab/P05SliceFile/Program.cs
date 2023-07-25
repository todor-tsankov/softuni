using System;
using System.IO;

namespace P05SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var filestream = new FileStream("Input.txt", FileMode.OpenOrCreate);

            var parts = 4;
            var lengthOfEachPart = (int)Math.Ceiling(filestream.Length * 1.0 / parts);

            for (int i = 1; i <= parts; i++)
            {
                var currentFileStream = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                var byteArray = new byte[lengthOfEachPart];

                filestream.Read(byteArray, 0, lengthOfEachPart);
                currentFileStream.Write(byteArray, 0, lengthOfEachPart);

                currentFileStream.Flush();
            }

        }
    }
}
