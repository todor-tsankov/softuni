using System;
using System.IO;

namespace P06FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0d;
            var files = Directory.GetFiles("TestFolder");

            foreach (var item in files)
            {
                var fileInfo = new FileInfo(item);

                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            Console.WriteLine(sum);
        }
    }
}
