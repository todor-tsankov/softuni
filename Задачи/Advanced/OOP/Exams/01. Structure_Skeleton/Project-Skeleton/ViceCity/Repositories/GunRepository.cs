using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.First(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
    }
}
