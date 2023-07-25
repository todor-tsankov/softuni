namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;
        private const int OxygenDecrease = 5;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= OxygenDecrease;
        }
    }
}
