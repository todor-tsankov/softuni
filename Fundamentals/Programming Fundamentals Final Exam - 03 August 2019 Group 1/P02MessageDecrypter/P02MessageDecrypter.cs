using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02MessageDecrypter
{
    class P02MessageDecrypter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^([%\$])(?<tag>[A-Z][a-z]{2,})\1:\s\[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<third>[0-9]+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match wholeMessage = Regex.Match(input, pattern);

                if (wholeMessage.Success)
                {
                    string tag = wholeMessage.Groups["tag"].Value;

                    char first = (char) int.Parse(wholeMessage.Groups["first"].Value);

                    char second = (char)int.Parse(wholeMessage.Groups["second"].Value);

                    char third = (char)int.Parse(wholeMessage.Groups["third"].Value);

                    Console.WriteLine($"{tag}: {string.Concat(first, second, third)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
