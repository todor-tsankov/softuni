using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03WordCount
{
    class Program
    {
        static void Main()
        {
            var punctuationSignsAndSpace = new char[] { ' ', '-', ',', '.', '!', '?' }; 

            var words = File.ReadAllLines("words.txt");

            var textWords = File.ReadAllText("text.txt")
                                .Split(punctuationSignsAndSpace, StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            var wordsDictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsDictionary[word] = 0;
            }

            foreach (var textWord in textWords)
            {
                var textWordToLower = textWord.ToLower();

                if (wordsDictionary.ContainsKey(textWordToLower))
                {
                    wordsDictionary[textWordToLower]++;
                }
            }

            using var actualWriter = new StreamWriter(@"..\..\..\actualResult.txt");
            using var expectedWriter = new StreamWriter(@"..\..\..\expectedResult.txt");

            foreach (var (word, times) in wordsDictionary)
            {
                actualWriter.WriteLine($"{word}-{times}");
            }

            wordsDictionary = wordsDictionary.OrderByDescending(i => i.Value)
                                             .ToDictionary(i => i.Key, i => i.Value);

            foreach (var (word, times) in wordsDictionary)
            {
                expectedWriter.WriteLine($"{word}-{times}");
            }
        }
    }
}
