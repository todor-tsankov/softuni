using System;
using System.Collections.Generic;

namespace P04CitiesByCountryAndContinent
{
    class Program
    {
        static void Main(string[] args)
        {
            var continetsCountriesCities = new Dictionary<string, Dictionary<string, List<string>>>();

            var n = int.Parse(Console.ReadLine());

            ReadInputFromconsole(continetsCountriesCities, n);
            Print(continetsCountriesCities);
        }

        private static void Print(Dictionary<string, Dictionary<string, List<string>>> continetsCountriesCities)
        {
            foreach (var (continent, countries) in continetsCountriesCities)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, citiesList) in countries)
                {
                    var cities = string.Join(", ", citiesList);

                    Console.WriteLine($"{country} -> {cities}");
                }
            }
        }

        private static void ReadInputFromconsole(Dictionary<string, Dictionary<string, List<string>>> continetsCountriesCities, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var continentCountryCity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var continent = continentCountryCity[0];
                var country = continentCountryCity[1];
                var city = continentCountryCity[2];

                if (!continetsCountriesCities.ContainsKey(continent))
                {
                    continetsCountriesCities[continent] = new Dictionary<string, List<string>>();
                }

                if (!continetsCountriesCities[continent].ContainsKey(country))
                {
                    continetsCountriesCities[continent][country] = new List<string>();
                }

                continetsCountriesCities[continent][country].Add(city);
            }
        }
    }
}
