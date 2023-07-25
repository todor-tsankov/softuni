using System;
using System.Collections.Generic;
using System.Linq;

namespace P11PartyReservationModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filters = new Dictionary<string, HashSet<string>>();

            ReadInput(filters);

            guests = FilterGuests(guests, filters);

            Console.WriteLine(string.Join(" ", guests));
        }

        private static void ReadInput(Dictionary<string, HashSet<string>> filters)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Print")
                {
                    break;
                }

                ProcessInputData(filters, command);
            }
        }

        private static string[] FilterGuests(string[] guests, Dictionary<string, HashSet<string>> filters)
        {
            foreach (var (operation, param) in filters)
            {

                foreach (var par in param)
                {
                    Func<string, bool> myFunc = filterSwitch(operation, par);

                    guests = guests.Where(myFunc)
                                   .ToArray();
                }
            }

            return guests;
        }

        private static Func<string, bool> filterSwitch(string operation, string par)
        {
            Func<string, bool> myFunc = x => true;

            if (operation == "Starts with")
            {
                myFunc = x => !x.StartsWith(par);
            }
            else if (operation == "Ends with")
            {
                myFunc = x => !x.EndsWith(par);
            }
            else if (operation == "Length")
            {
                myFunc = x => x.Length != int.Parse(par);
            }
            else if (operation == "Contains")
            {
                myFunc = x => !x.Contains(par);
            }

            return myFunc;
        }

        private static void ProcessInputData(Dictionary<string, HashSet<string>> filters, string command)
        {
            var cmdParts = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

            var cmdType = cmdParts[0];
            var operation = cmdParts[1];
            var par = cmdParts[2];

            if (cmdType == "Add filter")
            {
                if (!filters.ContainsKey(operation))
                {
                    filters[operation] = new HashSet<string>();
                }

                filters[operation].Add(par);
            }
            else if (cmdType == "Remove filter")
            {
                filters[operation].Remove(par);
            }
        }
    }
}
