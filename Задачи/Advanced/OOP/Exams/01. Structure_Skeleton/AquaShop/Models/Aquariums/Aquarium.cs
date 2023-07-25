using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        private Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public Aquarium(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.GetComfort();

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;


        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            var fishInfo = "none";

            if (this.fish.Count != 0)
            {
                var fishNames = this.fish.Select(f => f.Name);

                fishInfo = string.Join(", ", fishNames);
            }

            sb.AppendLine($"Fish: {fishInfo}")
              .AppendLine($"Decorations: {this.decorations.Count}")
              .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString()
                     .TrimEnd();
        }


        private int GetComfort()
        {
            var comfort = 0;

            foreach (var item in this.decorations)
            {
                comfort += item.Comfort;
            }

            return comfort;
        }
    }
}
