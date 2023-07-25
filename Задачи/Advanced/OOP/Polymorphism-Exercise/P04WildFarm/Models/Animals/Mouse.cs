using System;

namespace P04WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const string SOUND = "Squeak";
        private const double WEIGHT_GAIN_PER_PIECE = 0.10;

        public Mouse(string name, double weight, int foodEaten, string region) 
            : base(name, weight, foodEaten, region)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Fruit")
            {
                throw new InvalidOperationException($"{nameof(Mouse)} does not eat {foodType}!");
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
