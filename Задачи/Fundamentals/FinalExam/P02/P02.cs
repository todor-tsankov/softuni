using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02
{
    class P02
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentMessage = Console.ReadLine();

                Match validMatch = pattern.Match(currentMessage);

                if (validMatch.Success)
                {
                    string command = validMatch.Groups[1].Value;
                    string message = validMatch.Groups[2].Value;

                    int[] asciiValues = message.Where(i => char.IsLetter(i))
                                               .Select(i => (int)i)
                                               .ToArray();

                    string printValues = string.Join(" ", asciiValues);

                    Console.WriteLine($"{command}: {printValues}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
