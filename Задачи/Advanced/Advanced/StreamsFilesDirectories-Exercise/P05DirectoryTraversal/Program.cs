using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace P05DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryName = Console.ReadLine();

            var files = Directory.GetFiles(directoryName);

            var filesDictionary = new Dictionary<string, Dictionary<string, double>>();

            FillDictionaryWithAllFiles(files, filesDictionary);
            filesDictionary = OrderDictionary(filesDictionary);

            var linesOfTheTextDocument = new List<string>();
            FillListWithAllFiles(filesDictionary, linesOfTheTextDocument);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            File.WriteAllText($"{path}" + @"\report.txt", string.Join(Environment.NewLine, linesOfTheTextDocument));
        }

        private static void FillListWithAllFiles(Dictionary<string, Dictionary<string, double>> filesDictionary, List<string> linesOfTheTextDocument)
        {
            foreach (var (ext, currentFilesDict) in filesDictionary)
            {
                linesOfTheTextDocument.Add(ext);

                var ordered = filesDictionary[ext].OrderByDescending(i => i.Value)
                                                           .ToDictionary(i => i.Key, i => i.Value);

                foreach (var (name, size) in ordered)
                {
                    linesOfTheTextDocument.Add($"--{name} - {size}kb");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, double>> OrderDictionary(Dictionary<string, Dictionary<string, double>> filesDictionary)
        {
            filesDictionary = filesDictionary.OrderByDescending(i => i.Value.Count)
                                                         .ThenBy(i => i.Key)
                                                         .ToDictionary(i => i.Key, i => i.Value);
            return filesDictionary;
        }

        private static void FillDictionaryWithAllFiles(string[] files, Dictionary<string, Dictionary<string, double>> filesDictionary)
        {
            foreach (var file in files)
            {
                var currentFileInfo = new FileInfo(file);

                var name = currentFileInfo.Name;
                var ext = currentFileInfo.Extension;
                var size = currentFileInfo.Length * 1.0 / 1024;

                if (!filesDictionary.ContainsKey(ext))
                {
                    filesDictionary[ext] = new Dictionary<string, double>();
                }

                filesDictionary[ext][name] = size;
            }
        }
    }
}
