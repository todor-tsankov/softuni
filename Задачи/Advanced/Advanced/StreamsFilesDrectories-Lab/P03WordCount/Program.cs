using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using var wordsReader = new StreamReader("words.txt");
            using var textReader = new StreamReader("text.txt");
            using var outputWriter = new StreamWriter("Output.txt");

            var words = new Dictionary<string, int>();

            var wordsArray = wordsReader.ReadToEnd()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var splitChars = new char[]{' ', '.', ',', '-', '!', '?', '\"', '\'', ';', ':', '(', ')'};
            var textWords = textReader.ReadToEnd().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            var wordsDictionary = new Dictionary<string, int>();

            foreach (var word in wordsArray)
            {
                var currentWord = word.ToLower();

                if (!wordsDictionary.ContainsKey(currentWord))
                {
                    wordsDictionary[currentWord] = 0;
                }
            }

            foreach (var word in textWords)
            {
                var currentWord = word.ToLower();

                if (wordsDictionary.ContainsKey(currentWord))
                {
                    wordsDictionary[currentWord]++;
                }
            }

            wordsDictionary = wordsDictionary.OrderByDescending(i => i.Value)
                                             .ToDictionary(i => i.Key, i => i.Value);

            foreach (var (word, count) in wordsDictionary)
            {
                outputWriter.WriteLine($"{word} - {count}");
            }
        }
    }
}
