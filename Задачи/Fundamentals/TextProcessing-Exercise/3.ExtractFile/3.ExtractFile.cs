using System;

namespace _3.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split("\\");
            string[] fileAndExtension = path[path.Length -1].Split(".");
            string file = fileAndExtension[0];
            string ext = fileAndExtension[1];

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {ext}");

        }
    }
}
