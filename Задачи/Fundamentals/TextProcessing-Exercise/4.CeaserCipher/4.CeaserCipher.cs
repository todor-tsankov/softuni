using System;

namespace _4.CeaserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine().ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = (char)(characters[i] + 3);
            }

            Console.WriteLine(new string(characters));
        }
    }
}
