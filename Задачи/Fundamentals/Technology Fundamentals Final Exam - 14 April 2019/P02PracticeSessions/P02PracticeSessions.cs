using System;
using System.Collections.Generic;
using System.Linq;

namespace P02PracticeSessions
{
    class P02PracticeSessions
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> roads = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split("->");
                string commandType = commandArgs[0];
                string road = commandArgs[1];

                if (commandType == "Add")
                {
                    if (!roads.ContainsKey(road))
                    {
                        roads[road] = new List<string>();
                    }

                    string racer = commandArgs[2];
                    roads[road].Add(racer);
                }
                else if (commandType == "Move")
                {
                    string racer = commandArgs[2];
                    string nextRoad = commandArgs[3];

                    if (roads[road].Contains(racer))
                    {
                        roads[road].Remove(racer);
                        roads[nextRoad].Add(racer);
                    }
                }
                else if (commandType == "Close")
                {
                    if (roads.ContainsKey(road))
                    {
                        roads.Remove(road);
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");

            var sortedRoads = roads.OrderByDescending(i => i.Value.Count).ThenBy(i => i.Key);

            foreach (var ro in sortedRoads)
            {
                var sortedRacers = ro.Value;

                Console.WriteLine(ro.Key);

                foreach (var racer in sortedRacers)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
