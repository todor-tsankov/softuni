using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split( new char[]{' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
            decimal sum = 0;

            foreach (var word in words)
            {
                List<char> separeted = word.ToCharArray().ToList();

                char firstLetter = separeted[0];
                char secondLetter = separeted[separeted.Count - 1];

                separeted.RemoveAt(0);
                separeted.RemoveAt(separeted.Count - 1);

                double number = double.Parse(string.Join("",separeted));
                double currentSum = 0;

                if (char.IsUpper(firstLetter))
                {
                    currentSum += number / (firstLetter - 64);
                }
                else if(char.IsLower(firstLetter))
                {
                    currentSum += number * (firstLetter - 96);
                }

                if (char.IsUpper(secondLetter))
                {
                    currentSum -= (secondLetter - 64);
                }
                else if(char.IsLower(secondLetter))
                {
                    currentSum += (secondLetter - 96);
                }

                sum += (decimal)currentSum;
            }

            Console.WriteLine(sum.ToString("f2"));
        }
    }
}
