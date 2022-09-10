using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04OnTheWayToAnapurna
{
    class P04OnTheWayToAnapurna
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"^([A-Za-z0-9!@#$?]+)=(\d+)<<(.+)$");
            string input = Console.ReadLine();

            while (input != "Last note")
            {
                Match currentMatch = pattern.Match(input);

                CheckIfInputIsValidAnPrinResult(currentMatch);

                input = Console.ReadLine();
            }
        }

        private static void CheckIfInputIsValidAnPrinResult(Match currentMatch)
        {
            if (currentMatch.Success)
            {
                string geocode = currentMatch.Groups[3].Value;
                int length = int.Parse(currentMatch.Groups[2].Value);

                if (geocode.Length == length)
                {
                    string name = new string(currentMatch.Groups[1]
                                                         .Value
                                                         .Where(i => 
                                                                i != '!'
                                                             && i != '@'
                                                             && i != '#'
                                                             && i != '$'
                                                             && i != '?')
                                                        .ToArray());

                    Console.WriteLine($"Coordinates found! {name} -> {geocode}");
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
    }
}
