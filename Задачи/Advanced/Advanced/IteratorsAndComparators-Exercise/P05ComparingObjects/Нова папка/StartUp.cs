using System;
using System.Collections.Generic;

namespace P05ComparingObjects
{
    public class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();

            ReadInputPeople(people);

            var matchIndex = int.Parse(Console.ReadLine()) - 1;
            var matchPerson = people[matchIndex];

            var count = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(matchPerson) == 0)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{count} {people.Count - count} {people.Count}");
            }
        }

        static void ReadInputPeople(List<Person> people)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = inputArgs[0];
                var age = int.Parse(inputArgs[1]);
                var town = inputArgs[2];

                var currentPerson = new Person(name, age, town);

                people.Add(currentPerson);
            }
        }
    }
}
