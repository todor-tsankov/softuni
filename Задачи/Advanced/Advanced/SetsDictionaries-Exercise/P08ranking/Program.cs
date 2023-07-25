using System;
using System.Collections.Generic;
using System.Linq;

namespace P08ranking
{
    class Program
    {
        static void Main()
        {
            var contests = new Dictionary<string, string>();
            var candidates = new Dictionary<string, Dictionary<string, int>>();

            ReadContests(contests);
            ReadSubmissions(contests, candidates);

            var max = candidates.Max(i => i.Value.Values.Sum());
            var user = candidates.First(i => i.Value.Values.Sum() == max);

            Console.WriteLine($"Best candidate is {user.Key} with total {max} points.");

            candidates = candidates.OrderBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);

            foreach (var (name, submissions) in candidates)
            {
                Console.WriteLine($"{name}");

                foreach (var (conest, points) in submissions)
                {
                    Console.WriteLine($"#  {conest} -> {points}");
                }
            }
        }

        private static void ReadSubmissions(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> candidates)
        {
            while (true)
            {
                var submission = Console.ReadLine();

                if (submission == "end of submissions")
                {
                    break;
                }

                var submissionParts = submission.Split("=>");

                var contest = submissionParts[0];
                var password = submissionParts[1];
                var username = submissionParts[2];
                var points = int.Parse(submissionParts[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates[username] = new Dictionary<string, int>();
                    }

                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username][contest] = points;
                    }

                    if (candidates[username][contest] > points)
                    {
                        candidates[username][contest] = points;
                    }
                }
            }
        }

        private static void ReadContests(Dictionary<string, string> contests)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                var contestAndPassword = input.Split(":");

                var contest = contestAndPassword[0];
                var password = contestAndPassword[1];

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = password;
                }
            }
        }
    }
}
