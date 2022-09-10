using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04AnimaSanctuary
{
    class P04AnimaSanctuary
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalWeight = 0;

            string firstPattern = @"n:([^;]+);t([^;]+);c--([A-Za-z ]+)";
            string secondPattern = @"[A-Za-z\s]";
            string digitPattern = @"[0-9]";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, firstPattern);

                if (match.Success)
                {
                    MatchCollection nameParts = Regex.Matches(match.Groups[1].Value, secondPattern);
                    string name = string.Join("", nameParts);

                    MatchCollection kindParts = Regex.Matches(match.Groups[2].Value, secondPattern);
                    string kind = string.Join("", kindParts);

                    MatchCollection countryParts = Regex.Matches(match.Groups[3].Value, secondPattern);
                    string country = string.Join("", countryParts);

                    Console.WriteLine($"{name} is a {kind} from {country}");

                    MatchCollection nameDigits = Regex.Matches(match.Groups[1].Value, digitPattern);
                    int nameWeight = nameDigits.Select(i => int.Parse(i.Value)).Sum();

                    MatchCollection kindDigits = Regex.Matches(match.Groups[2].Value, digitPattern);
                    int kindWeight = kindDigits.Select(i => int.Parse(i.Value)).Sum();

                    totalWeight += nameWeight + kindWeight;
                }
            }

            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
        }
    }
}
