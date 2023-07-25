using System;
using System.IO;

namespace P04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var binaryReader = new FileStream("sampleFile.jpg", FileMode.OpenOrCreate);
            using var binaryWriter = new FileStream(@"..\..\..\copyOfSampleFile.jpg", FileMode.OpenOrCreate);

            var defLength = 4096;
            var buffer = new byte[defLength];

            while (binaryReader.CanRead)
            {
                var bytes = binaryReader.Read(buffer, 0, defLength);

                if (bytes == 0)
                {
                    break;
                }
                else
                {
                    binaryWriter.Write(buffer, 0, defLength);
                }
            }
        }
    }
}
