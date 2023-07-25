using System;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359([ -])2\1\d{3}\1\d{4}\b";
            string phones = Console.ReadLine();

            MatchCollection validPhones = Regex.Matches(phones, regex);

            Console.WriteLine(string.Join(", ", validPhones));
        }
    }
}
