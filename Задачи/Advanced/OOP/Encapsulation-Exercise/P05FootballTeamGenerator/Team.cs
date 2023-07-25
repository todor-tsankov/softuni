using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public int Rating => this.GetRating();
        internal void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        internal void RemovePlayer(string playerName)
        {
            var index = this.players.FindIndex(p => p.Name == playerName);

            if (index < 0)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.RemoveAt(index);
        }

        private int GetRating()
        {
            if (this.players.Any())
            {
                var average = players.Average(p => p.Stats);

                return (int)Math.Round(average);
            }

            return 0;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}
