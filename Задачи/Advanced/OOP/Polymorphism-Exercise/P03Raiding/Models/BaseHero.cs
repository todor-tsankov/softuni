using System;

namespace P03Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                /*if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }*/

                this.name = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.power = value;
            }
        }

        public abstract string CastAbility();
    }
}
