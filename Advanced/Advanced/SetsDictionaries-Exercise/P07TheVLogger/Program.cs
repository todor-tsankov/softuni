using System;
using System.Collections.Generic;
using System.Linq;

namespace P07TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new List<Vlogger>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Statistics")
                {
                    break;
                }

                var inputParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var vlogername = inputParts[0];
                var joinedOrFollowed = inputParts[1];

                if (joinedOrFollowed == "joined")
                {
                    if (!vlogger.Any(i => i.Name == vlogername))
                    {
                        vlogger.Add(new Vlogger(vlogername));
                    }
                }
                else if (joinedOrFollowed == "followed")
                {
                    var secondVlogger = inputParts[2];

                    var firstVloggerIndex = vlogger.FindIndex(i => i.Name == vlogername);
                    var secondVloggerIndex = vlogger.FindIndex(i => i.Name == secondVlogger);

                    if (firstVloggerIndex != secondVloggerIndex
                        && firstVloggerIndex >= 0
                        && secondVloggerIndex >= 0)
                    {
                        if (!vlogger[secondVloggerIndex].Followers.Contains(vlogername))
                        {
                            vlogger[secondVloggerIndex].Followers.Add(vlogername);
                            vlogger[firstVloggerIndex].FollowingCount++;
                        }
                    }
                }
            }

            vlogger = PrintOutput(vlogger);
        }

        private static List<Vlogger> PrintOutput(List<Vlogger> vlogger)
        {
            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            vlogger = vlogger.OrderByDescending(i => i.Followers.Count)
                             .ThenBy(i => i.FollowingCount)
                             .ToList();

            Console.WriteLine($"1. {vlogger[0].Name} : {vlogger[0].Followers.Count} followers, {vlogger[0].FollowingCount} following");

            foreach (var item in vlogger[0].Followers)
            {
                Console.WriteLine($"*  {item}");
            }

            for (int i = 1; i < vlogger.Count; i++)
            {
                var current = vlogger[i];

                Console.WriteLine($"{i + 1}. {current.Name} : {current.Followers.Count} followers, {current.FollowingCount} following");
            }

            return vlogger;
        }
    }

    class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            FollowingCount = 0;
            Followers = new SortedSet<string>();
        }
        public string Name { get; set; }
        public int FollowingCount { get; set; }

        public SortedSet<string> Followers { get; set; }
    }
}
