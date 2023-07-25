using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using AquaShop.Utilities;
using System;
using System.Collections.Generic;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Decorations;
using System.Linq;
using AquaShop.Models.Fish;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private IList<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if ((aquarium.GetType().Name.StartsWith("Freshwater") && fishType.StartsWith("Freshwater"))
                || aquarium.GetType().Name.StartsWith("Saltwater") && fishType.StartsWith("Saltwater"))
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return string.Format(OutputMessages.UnsuitableWater);
        }

        public string CalculateValue(string aquariumName)
        {
            var value = 0M;
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                value += fish.Price;
            }

            foreach (var decoration in aquarium.Decorations)
            {
                value += decoration.Price;
            }

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            this.decorations.Remove(decoration);
            aquarium.AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aq in this.aquariums)
            {
                sb.AppendLine(aq.GetInfo());
            }

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
