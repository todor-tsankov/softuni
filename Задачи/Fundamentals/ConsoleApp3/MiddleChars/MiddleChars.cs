using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleChars
{
    class MiddleChars
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            MiddleCharacterPrinter(inputString);
        }

        static void MiddleCharacterPrinter(string inputString)
        {
            int length = inputString.Length;

            if (length % 2 == 0)
            {
                Console.WriteLine((char)(inputString[length / 2 - 1]) + "" + (char)inputString[length / 2]);

            }
            else
            {
                Console.WriteLine((char)(inputString[length / 2]));
            }
        }
    }
}
