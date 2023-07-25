using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var morse = new Dictionary<string, char>()
            {
                {".-", 'A'},
                {"-...", 'B'},
                {"-.-.", 'C'},
                {"-..", 'D'},
                {".", 'E'},
                {"..-.", 'F'},
                {"--.", 'G'},
                {"....", 'H'},
                {"..", 'I'},
                {".---", 'J'},
                {"-.-", 'K'},
                {".-..", 'L'},
                {"--", 'M'},
                {"-.", 'N'},
                {"---", 'O'},
                {".--.", 'P'},
                {"--.-", 'Q'},
                {".-.", 'R'},
                {"...", 'S'},
                {"-",'T'},
                {"..-", 'U'},
                {"...-", 'V'},
                {".--", 'W'},
                {"-..-", 'X'},
                {"-.--", 'Y'},
                {"--..", 'Z'},
                {"|", ' '}
            };

            string[] letters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder decryptedText = new StringBuilder();

            foreach (var item in letters)
            {
                char currentSymbol = morse[item];
                decryptedText.Append(currentSymbol);
            }

            Console.WriteLine(decryptedText);
        }
    }
}
