using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            List<string> wordsList = Console.ReadLine().Split().ToList();
            Dictionary<string, int> wordsOccurances = new Dictionary<string, int>();

            foreach (var item in wordsList)
            {
                string currentWord = item.ToLowerInvariant();

                if (!wordsOccurances.ContainsKey(currentWord))
                {
                    wordsOccurances[currentWord] = 0;
                }

                wordsOccurances[currentWord]++;
            }

            var evenWords = wordsOccurances.Where(i => i.Value % 2 != 0).ToDictionary(i => i.Key, i => i.Value);
            Console.WriteLine(string.Join(" ", evenWords.Keys));
        }
    }
}
