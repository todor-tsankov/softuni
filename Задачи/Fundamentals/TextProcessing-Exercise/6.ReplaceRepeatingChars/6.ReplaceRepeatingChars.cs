using System;
using System.Linq;

namespace _6.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] == input[i])
                {
                    input[i - 1] = '\0';
                }
            }

            Console.WriteLine(new string(input.Where(i => i != '\0').ToArray()));
        }
    }
}
