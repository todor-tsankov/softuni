using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegEx_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string regexForNames = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection filteredNames = Regex.Matches(names, regexForNames);

            foreach (Match match in filteredNames)
            {
                Console.Write(match.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
