using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Planets;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    if (!planet.Items.Any())
                    {
                        return;
                    }

                    var item = planet.Items.First();
                    planet.Items.Remove(item);

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                }
            }
        }
    }
}
