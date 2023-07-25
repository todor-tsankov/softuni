using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char firstChar = Console.ReadLine()[0];
            char secondChar = Console.ReadLine()[0];
            PrintsAllCharsInTheRange(firstChar, secondChar);
        }

        static void PrintsAllCharsInTheRange(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            
        }
    }
}
