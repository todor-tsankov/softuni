using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSynonyms
{
    class WordSynonyms
    {
        static void Main(string[] args)
        {
            var synonymDictionary = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!synonymDictionary.ContainsKey(word))
                {
                    synonymDictionary[word] = new List<string>();
                }

                synonymDictionary[word].Add(synonym);
            }

            foreach (var word in synonymDictionary)
            {
                Console.Write(word.Key + " - " + string.Join(", ", word.Value));
                Console.WriteLine();
            }
        }
    }
}
