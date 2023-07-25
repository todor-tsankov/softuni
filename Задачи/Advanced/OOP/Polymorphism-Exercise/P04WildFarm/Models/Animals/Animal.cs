namespace P04WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private const int DEFAULT_FOOD_EATEN = 0;
        public Animal(string name, double weight, int foodEaten = DEFAULT_FOOD_EATEN)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract void Feed(string foodType, int quantity);
        public abstract string ProduceSound();

        public abstract override string ToString();
    }
}
