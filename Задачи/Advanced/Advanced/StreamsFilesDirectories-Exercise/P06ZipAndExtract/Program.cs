using System;
using System.IO;
using System.IO.Compression;

namespace P06ZipAndExtract
{
    class Program
    {
        static void Main()
        {
            var directoryToBeZipped = @".";
            var compressedFilePath =  @"..\..\..\copyMeArchive.zip";
            var extractedFilePath = @"..\..\..\OutputFolder";

            ZipFile.CreateFromDirectory(directoryToBeZipped, compressedFilePath);
            ZipFile.ExtractToDirectory(compressedFilePath, extractedFilePath);
        }
    }
}
