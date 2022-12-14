using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private readonly string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        private Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public Team(string name)
            : this()
        {
            this.name = name;
        }

        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
