using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)this.models;

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }
    }
}
