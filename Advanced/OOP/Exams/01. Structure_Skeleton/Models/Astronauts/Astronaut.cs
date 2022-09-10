using System;

using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Astronauts.Contracts;
using System.Text;
using System.Linq;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const int OxygenDecrease = 10;

        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;

            this.Bag = new Backpack();
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
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen != 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen -= OxygenDecrease;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var items = "none";

            if (this.Bag.Items.Any())
            {
                items = string.Join(", ", this.Bag.Items);
            }

            sb.AppendLine($"Name: {this.Name}")
              .AppendLine($"Oxygen: {this.Oxygen}")
              .AppendLine($"Bag items: {items}");

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
