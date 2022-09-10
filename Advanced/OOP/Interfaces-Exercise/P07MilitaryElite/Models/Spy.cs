using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString()
                     .Trim();
        }
    }
}
