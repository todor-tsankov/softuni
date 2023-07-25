using System;

namespace _2.CharecterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string first = words[0];
            string second = words[1];

            int sum = CharacterMultipltier(first, second);
            Console.WriteLine(sum);
        }

        static int CharacterMultipltier(string firstWord, string secondWord)
        {
            int sum = 0;
            int maxLength = Math.Max(firstWord.Length, secondWord.Length);
            int minLength = Math.Min(firstWord.Length, secondWord.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (i >= minLength)
                {
                    if (minLength == firstWord.Length)
                    {
                        sum += secondWord[i];
                    }
                    else
                    {
                        sum += firstWord[i];
                    }
                }
                else
                {
                    sum += firstWord[i] * secondWord[i];
                }
            }

            return sum;
        }
    }
}
