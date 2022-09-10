using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            var forces = new Dictionary<string, int>();
            var people = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] inputParts = input.Split(" | ");   // NEEDS TO BE  " | ", " -> "
                string forceSide;
                string forceUser;

                if (input.Contains('|'))
                {
                    forceSide = inputParts[0];
                    forceUser = inputParts[1];

                    if (!people.ContainsKey(forceUser))
                    {
                        people[forceUser] = forceSide;

                        if (!forces.ContainsKey(forceSide))
                        {
                            forces[forceSide] = 0;
                        }

                        forces[forceSide]++;
                    }
                }
                else
                {
                    inputParts = input.Split(" -> ");
                    forceUser = inputParts[0];
                    forceSide = inputParts[1];
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                    if (people.ContainsKey(forceUser))
                    {
                        forces[people[forceUser]]--;
                        people[forceUser] = forceSide;

                        if (!forces.ContainsKey(forceSide))
                        {
                            forces[forceSide] = 0;
                        }

                        forces[forceSide]++;
                    }
                    else
                    {
                        people[forceUser] = forceSide;

                        if (!forces.ContainsKey(forceSide))
                        {
                            forces[forceSide] = 0;
                        }

                        forces[forceSide]++;
                    }
                }
            }

            var filterForces = forces.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            foreach (var f in filterForces)
            {
                if (f.Value <= 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {f.Key}, Members: {f.Value}");

                var filterUsers = people.Where(i => i.Value == f.Key).OrderBy(i => i.Key);

                foreach (var item in filterUsers)
                {
                    Console.WriteLine($"! {item.Key}");
                }
            }
        }
    }
}
