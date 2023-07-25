using System;

namespace P04WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const string SOUND = "Meow";
        private const double WEIGHT_GAIN_PER_PIECE = 0.30;

        public Cat(string name, double weight, int foodEaten, string region, string breed) 
            : base(name, weight, foodEaten, region, breed)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Meat")
            {
                throw new InvalidOperationException($"{nameof(Cat)} does not eat {foodType}!");
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
