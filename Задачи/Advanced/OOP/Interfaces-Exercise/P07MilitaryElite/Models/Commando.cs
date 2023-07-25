using System.Text;
using System.Collections.Generic;

using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;


namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, IEnumerable<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
            this.AddMissions(missions);
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) this.missions;

        private void AddMissions(IEnumerable<Mission> missions)
        {
            foreach (var mission in missions)
            {
                this.missions.Add(mission);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {base.Corps.ToString()}");
            sb.AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString()
                     .Trim();
        }
    }
}
