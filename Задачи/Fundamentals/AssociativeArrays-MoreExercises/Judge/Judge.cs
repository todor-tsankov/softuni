using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            var contests = new List<Contest>();
            var individualStandings = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "no more time")
                {
                    break;
                }

                string[] inputParts = input.Split(" -> ");  //  " -> " 
                string username = inputParts[0];
                string contest = inputParts[1];
                int points = int.Parse(inputParts[2]);
                int contestIndex = contests.FindIndex(i => i.Name == contest);

                if (contestIndex < 0)
                {
                    contests.Add(new Contest(contest));
                    contestIndex = contests.FindIndex(i => i.Name == contest);
                }

                if (!contests[contestIndex].PeopleDictionary.ContainsKey(username))
                {
                    contests[contestIndex].PeopleDictionary.Add(username, points);
                }
                else
                {
                    if (points > contests[contestIndex].PeopleDictionary[username])
                    {
                        contests[contestIndex].PeopleDictionary[username] = points;
                    }
                }

                if (!individualStandings.ContainsKey(username))
                {
                    individualStandings[username] = 0;
                }

            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Name}: {contest.PeopleDictionary.Count} participants");
                var filterUsers = contest.PeopleDictionary.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
                int counter = 1;

                foreach (var user in filterUsers)
                {
                    Console.WriteLine($"{counter}. {user.Key} <::> {user.Value}");
                    counter++;
                    individualStandings[user.Key] += user.Value;
                }
            }

            Console.WriteLine("Individual standings:");
            var filteredStandings = individualStandings.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            int counter2 = 1;

            foreach (var person in filteredStandings)
            {
                Console.WriteLine($"{counter2}. {person.Key} -> {person.Value}");
                counter2++;
            }

        }
    }

    class Contest
    {
        public Contest(string name)
        {
            Name = name;
            PeopleDictionary = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public Dictionary<string, int> PeopleDictionary { get; set; }
    }
}
