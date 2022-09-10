using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02MessageEncypter
{
    class P02MessageEncypter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"([@\*])(?<tag>[A-Z][a-z]{2,})\1:\s\[(?<first>[A-Za-z]+)\]\|\[(?<second>[A-Za-z]+)\]\|\[(?<third>[A-Za-z]+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match message = Regex.Match(input, pattern);

                string encryptedMessage = string.Empty;

                if (message.Success)
                {
                    string tag = message.Groups["tag"].Value;

                    string first = string.Join("", message.Groups["first"]
                                                          .Value
                                                          .Select(i => (int)i)
                                                          .ToArray());

                    string second = string.Join("", message.Groups["second"]
                                                           .Value
                                                           .Select(i => (int)i)
                                                           .ToArray());

                    string third = string.Join("", message.Groups["third"]
                                                          .Value
                                                          .Select(i => (int)i)
                                                          .ToArray());

                    encryptedMessage = $"{tag}: {first} {second} {third}";
                }
                else
                {
                    encryptedMessage = "Valid message not found!";
                }

                Console.WriteLine(encryptedMessage);
            }
        }
    }
}
