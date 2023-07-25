using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintsTheCountOfVowels(word);
        }

        static void PrintsTheCountOfVowels(string word)
        {
            int vowelsCounter = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || 
                    word[i] == 'e' || 
                    word[i] == 'i' || 
                    word[i] == 'o' || 
                    word[i] == 'u' ||
                    word[i] == 'A' || 
                    word[i] == 'E' ||
                    word[i] == 'I' || 
                    word[i] == 'O' || 
                    word[i] == 'U')
                {
                    vowelsCounter++;
                }
            }

            Console.WriteLine(vowelsCounter);
        }
    }
}
