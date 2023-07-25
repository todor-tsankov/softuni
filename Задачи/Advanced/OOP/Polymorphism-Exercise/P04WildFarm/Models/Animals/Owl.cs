using System;

namespace P04WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const string SOUND = "Hoot Hoot";
        private const double WEIGHT_GAIN_PER_PIECE = 0.25;

        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new InvalidOperationException($"{nameof(Owl)} does not eat {foodType}!");
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
