namespace P04WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten, string region) 
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = region;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
