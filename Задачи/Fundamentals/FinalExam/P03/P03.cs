using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    class P03
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> people = new Dictionary<string, List<string>>();
            int countUnlikedMeals = 0;

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commandParts = command.Split('-');

                string commandType = commandParts[0];
                string guest = commandParts[1];
                string meal = commandParts[2];

                if (commandType == "Like")
                {
                    if (!people.ContainsKey(guest))
                    {
                        people[guest] = new List<string>();
                    }

                    if (!people[guest].Contains(meal))
                    {
                        people[guest].Add(meal);
                    }
                }
                else if (commandType == "Unlike")
                {
                    if (!people.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (people[guest].Contains(meal))
                        {
                            people[guest].Remove(meal);
                            countUnlikedMeals++;

                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                }

                command = Console.ReadLine();
            }

            var sortedGuests = people.OrderByDescending(i => i.Value.Count).ThenBy(i => i.Key);

            foreach (var guest in sortedGuests)
            {
                string guestName = guest.Key;
                string meals = string.Join(", ", guest.Value);

                Console.WriteLine($"{guest.Key}: {meals}");
            }

            Console.WriteLine($"Unliked meals: {countUnlikedMeals}");
        }
    }
}
