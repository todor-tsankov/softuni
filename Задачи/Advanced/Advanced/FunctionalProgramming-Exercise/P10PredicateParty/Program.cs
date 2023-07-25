using System;
using System.Linq;

namespace P10PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                var cmdParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var cmdType = cmdParts[0];
                var condition = cmdParts[1];
                var par = cmdParts[2];

                Predicate<string> filter = FilterSwitch(condition, par);

                if (cmdType == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        var currentGuest = guests[i];

                        if (filter(currentGuest))
                        {
                            guests.Insert(i, currentGuest);
                            i++;
                        }
                    }
                }
                else if (cmdType == "Remove")
                {
                    guests.RemoveAll(filter);
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> FilterSwitch(string condition, string par)
        {
            Predicate<string> filter;

            if (condition == "StartsWith")
            {
                filter = x => x.StartsWith(par);
            }
            else if (condition == "EndsWith")
            {
                filter = x => x.EndsWith(par);
            }
            else
            {
                filter = x => x.Length == int.Parse(par);
            }

            return filter;
        }
    }
}
