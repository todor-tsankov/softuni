using System;
using System.Collections.Generic;
using System.Text;

namespace P05FootballTeamGenerator
{
    public class Player
    {
        private string name;

        private readonly int endurance;
        private readonly int sprint;
        private readonly int dribble;
        private readonly int passing;
        private readonly int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;

            ValidateSkill("Endurance", endurance);
            ValidateSkill("Sprint", sprint);
            ValidateSkill("Dribble", dribble);
            ValidateSkill("Passing", passing);
            ValidateSkill("Shooting", shooting);

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
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
        public double Stats => GetStats();

        private void ValidateSkill(string skillName, int skill)
        {
            if (skill < 0 || skill > 100)
            {
                throw new ArgumentException($"{skillName} should be between 0 and 100.");
            }
        }
        private double GetStats()
        {
            return (endurance + sprint + dribble + passing + shooting) / 5.0;
        }
    }
}
