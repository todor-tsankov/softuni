namespace P04WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string region, string breed) 
            : base(name, weight, foodEaten, region)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
