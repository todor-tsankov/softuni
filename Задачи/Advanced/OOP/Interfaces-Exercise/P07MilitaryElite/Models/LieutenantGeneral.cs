using System.Linq;
using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IEnumerable<IPrivate> privatesToAdd) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
            this.AddPrivates(privatesToAdd);
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<IPrivate>) this.privates;

        public void AddPrivates(IEnumerable<IPrivate> privatesToAdd)
        {
            foreach (var @private in privatesToAdd)
            {
                this.privates.Add(@private);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in this.privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            return sb.ToString()
                     .Trim();
        }
    }
}
