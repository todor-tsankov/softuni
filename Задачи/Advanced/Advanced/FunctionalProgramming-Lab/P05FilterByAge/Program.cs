using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var currentPerson = Console.ReadLine()
                                           .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[currentPerson[0]] = int.Parse(currentPerson[1]);
            }

            var olderOrYounger = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<KeyValuePair<string, int>, bool> ageFilter;

            if (olderOrYounger == "younger")
            {
                ageFilter = x => x.Value < age;
            }
            else
            {
                ageFilter = x => x.Value > age;
            }

            people = people.Where(ageFilter)
                           .ToDictionary(i => i.Key, i => i.Value);

            if (format == "name")
            {
                people.Keys.ToList().ForEach(Console.WriteLine);
            }
            else if (format == "age")
            {
                people.Values.ToList().ForEach(Console.WriteLine);
            }
            else if(format == "name age")
            {
                foreach (var (name, personAge) in people)
                {
                    Console.WriteLine($"{name} - {personAge}");
                }
            }
        }

    }
}
