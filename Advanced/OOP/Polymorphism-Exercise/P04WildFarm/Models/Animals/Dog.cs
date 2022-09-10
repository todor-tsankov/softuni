using System;

namespace P04WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const string SOUND = "Woof!";
        private const double WEIGHT_GAIN_PER_PIECE = 0.40;
        public Dog(string name, double weight, int foodEaten, string region) 
            : base(name, weight, foodEaten, region)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new InvalidOperationException($"{nameof(Dog)} does not eat {foodType}!");
            }

            base.FoodEaten += quantity;
            base.Weight += quantity * WEIGHT_GAIN_PER_PIECE;
        }

        public override string ProduceSound()
        {
            return SOUND;
        }
    }
}
