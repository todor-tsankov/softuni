using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var commandInfoArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries)
                                             .ToArray();
                try
                {
                    ProcessCommand(commandInfoArgs);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ProcessCommand(string[] commandInfoArgs)
        {
            var cmdType = commandInfoArgs[0];
            var teamName = commandInfoArgs[1];

            if (cmdType == "Team")
            {
                AddTeam(teamName);
            }
            else if (cmdType == "Add")
            {
                AddPlayer(commandInfoArgs, teamName);
            }
            else if (cmdType == "Remove")
            {
                RemovePlayer(commandInfoArgs, teamName);
            }
            else if (cmdType == "Rating")
            {
                PrintRating(teamName);
            }
        }

        private void PrintRating(string teamName)
        {
            var currentTeam = this.teams.FirstOrDefault(t => t.Name == teamName);

            if (currentTeam == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            Console.WriteLine(currentTeam);
        }

        private void RemovePlayer(string[] commandInfoArgs, string teamName)
        {
            var playerName = commandInfoArgs[2];

            var team = this.teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            team.RemovePlayer(playerName);
        }

        private void AddPlayer(string[] commandInfoArgs, string teamName)
        {
            var currentTeam = this.teams.FirstOrDefault(t => t.Name == teamName);

            if (currentTeam == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }

            var playerName = commandInfoArgs[2];

            var endurance = int.Parse(commandInfoArgs[3]);
            var sprint = int.Parse(commandInfoArgs[4]);
            var dribble = int.Parse(commandInfoArgs[5]);
            var passing = int.Parse(commandInfoArgs[6]);
            var shooting = int.Parse(commandInfoArgs[7]);

            var currentPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            currentTeam.AddPlayer(currentPlayer);
        }

        private void AddTeam(string teamName)
        {
            var currrentTeam = new Team(teamName);

            this.teams.Add(currrentTeam);
        }
    }
}
