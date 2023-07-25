using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociativeArrays_Exercise
{
    class CountCharsInString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var charDictionary = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (currentChar == ' ')
                {
                    continue;
                }

                if (!charDictionary.ContainsKey(currentChar))
                {
                    charDictionary[currentChar] = 0;
                }

                charDictionary[currentChar]++;
            }

            foreach (var character in charDictionary)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
