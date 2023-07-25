using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<Repair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, IEnumerable<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();

            AddReapirs(repairs);
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<Repair>) this.repairs;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {base.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var rep in this.repairs)
            {
                sb.AppendLine("  " + rep.ToString());
            }

            return sb.ToString()
                     .Trim();
        }

        private void AddReapirs(IEnumerable<Repair> repairs)
        {
            foreach (var repair in repairs)
            {
                this.repairs.Add(repair);
            }
        }
    }
}
