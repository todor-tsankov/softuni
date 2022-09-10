using System;
using System.Text.RegularExpressions;

namespace _3.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>\d{2})(?<sep>[.\-/])(?<month>[A-Z][a-z][a-z])\k<sep>(?<year>\d{4})";
            string dates = Console.ReadLine();

            MatchCollection filteredDates = Regex.Matches(dates, regex);

            foreach (Match date in filteredDates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
