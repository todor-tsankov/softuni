using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork
{
    class TeamWork
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> listOfTeams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] newTeam = Console.ReadLine().Split('-');
                string author = newTeam[0];
                string name = newTeam[1];
                int nameIndex = listOfTeams.FindIndex(j => j.Name == name);
                int authorIndex = listOfTeams.FindIndex(k => k.Creator == author);

                if (nameIndex >= 0)
                {
                    Console.WriteLine($"Team {name} was already created!");
                }
                else if (authorIndex >= 0)
                {
                    Console.WriteLine($"{author} cannot create another team!");
                }
                else
                {
                    listOfTeams.Add(new Team(author, name));
                    Console.WriteLine($"Team {name} has been created by {author}!");
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] commandParts = command.Split("->"); // should be "->"
                string user = commandParts[0];
                string team = commandParts[1];
                int userIndex = listOfTeams.FindIndex(i => i.Members.Contains(user));
                int teamIndex = listOfTeams.FindIndex(j => j.Name == team);

                if (teamIndex < 0)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if(userIndex >= 0)
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
                else
                {
                    listOfTeams[teamIndex].Members.Add(user);
                }
            }

            listOfTeams = listOfTeams.OrderByDescending(i => i.Members.Count).ThenBy(i => i.Name).ToList();

            for (int i = 0; i < listOfTeams.Count; i++)
            {
               listOfTeams[i].Members.Sort();
            }

            foreach (var team in listOfTeams)
            {
                if (team.Members.Count > 1)
                {
                    Console.WriteLine($"{team.Name}");
                    Console.WriteLine($"- {team.Creator}");

                    foreach (var member in team.Members)
                    {
                        if (member != team.Creator)
                        {
                            Console.WriteLine($"-- {member}");
                        }
                    }
                }
                
            }
            Console.WriteLine("Teams to disband:");

            foreach (var team in listOfTeams)
            {

                if (team.Members.Count <= 1)
                {
                    Console.WriteLine(team.Name);
                }
            }
        }
    }

    class Team
    {
        public Team(string author, string name)
        {
            Creator = author;
            Name = name;
            Members = new List<string>();
            Members.Add(author);
        }
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

    }
}
