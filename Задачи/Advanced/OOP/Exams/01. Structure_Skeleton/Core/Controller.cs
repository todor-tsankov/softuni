using System;
using System.Linq;
using System.Text;

using SpaceStation.Repositories;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Astronauts;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int planetsExplored;

        private IMission mission;
        private AstronautRepository astronauts;
        private PlanetRepository planets;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            var astronauts = this.astronauts.Models.Where(a => a.Oxygen > 60)
                                                   .ToList();

            if (!astronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, astronauts);

            var deadAstronauts = astronauts.Where(a => !a.CanBreath)
                                           .Count();

            this.planetsExplored++;
            return string.Format(OutputMessages.PlanetExplored, planet.Name, deadAstronauts);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.planetsExplored} planets were explored!")
              .AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
