using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, int>();
            var lenguages = new Dictionary<string, int>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] commandParts = command.Split('-');
                string username = commandParts[0];
                string lenguageOrBan = commandParts[1];

                if (lenguageOrBan != "banned")
                {
                    int points = int.Parse(commandParts[2]);

                    if (!lenguages.ContainsKey(lenguageOrBan))
                    {
                        lenguages[lenguageOrBan] = 0;
                    }

                    lenguages[lenguageOrBan]++;

                    if (!people.ContainsKey(username))
                    {
                        people[username] = points;
                    }
                    else
                    {
                        if (points > people[username])
                        {
                            people[username] = points;
                        }
                    }
                }
                else
                {
                    people.Remove(username);
                }
            }

            Console.WriteLine("Results:");
            var filterPeople = people.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            foreach (var person in filterPeople)
            {
                Console.WriteLine($"{person.Key} | {person.Value}");
            }

            Console.WriteLine("Submissions:");
            var filterLenguages = lenguages.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            foreach (var lenguage in filterLenguages)
            {
                Console.WriteLine($"{lenguage.Key} - {lenguage.Value}");
            }
        }
    }
}
