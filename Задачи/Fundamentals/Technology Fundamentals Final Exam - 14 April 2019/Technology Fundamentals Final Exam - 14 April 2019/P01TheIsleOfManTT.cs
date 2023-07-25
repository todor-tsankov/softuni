using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Technology_Fundamentals_Final_Exam___14_April_2019
{
    class P01TheIsleOfManTT
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([#$%*&])([A-Za-z]+)\1=([0-9]+)!!(.+)$");

            while (true)
            {
                string input = Console.ReadLine();

                Match currentMatch = pattern.Match(input);

                if (currentMatch.Success)
                {
                    int length = int.Parse(currentMatch.Groups[3].Value);

                    string name = currentMatch.Groups[2].Value;
                    string geocode = currentMatch.Groups[4].Value;

                    if (length == geocode.Length)
                    {
                        geocode = new string(geocode.Select(i =>(char)(i + length))
                                                    .ToArray());

                        Console.WriteLine($"Coordinates found! {name} -> {geocode}");
                        break;
                    }
                }

                Console.WriteLine("Nothing found!");
            }
        }
    }
}
