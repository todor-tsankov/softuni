using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociativeArrays_MoreExercises
{
    class Ranking
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();
            string command;
            int maxPoints = int.MinValue;
            string bestUser = string.Empty;

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] input = command.Split(':');
                string contest = input[0];
                string password = input[1];
                contests[contest] = password;
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] input = command.Split("=>");   // needs to be "=>"
                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (points > maxPoints)
                    {
                        maxPoints = points;
                        bestUser = username;
                    }

                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username][contest] = points;
                    }
                    else
                    {
                        if (points > users[username][contest])
                        {
                            users[username][contest] = points;
                        }
                    }
                }
            }

            int totalBestPoints = users[bestUser].Values.Sum();

            Console.WriteLine($"Best candidate is {bestUser} with total {totalBestPoints} points.");
            Console.WriteLine("Ranking: ");


            var filterUsers = users
                               .OrderBy(i => i.Key)
                               .ToDictionary(i => i.Key, i => i.Value);

            foreach (var user in filterUsers)
            {
                Console.WriteLine(user.Key);
                var filter = user.Value.OrderByDescending(i => i.Value);

                foreach (var item in filter)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
