using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Random rdm = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int index = rdm.Next(words.Length);
                string firstWord = words[i];
                string secondWord = words[index];
                words[index] = firstWord;
                words[i] = secondWord;
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
