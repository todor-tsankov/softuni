using System;

namespace P04WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const string SOUND = "ROAR!!!";
        private const double WEIGHT_GAIN_PER_PIECE = 1.00;
        public Tiger(string name, double weight, int foodEaten, string region, string breed) 
            : base(name, weight, foodEaten, region, breed)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                throw new InvalidOperationException($"{nameof(Tiger)} does not eat {foodType}!");
            }

            base.FoodEaten += quantity;
            base.Weight += quantity * WEIGHT_GAIN_PER_PIECE;
        }

        public override string ProduceSound()
        {
            return SOUND;
        }

        public override string ToString()
        {
            return $"{nameof(Tiger)} [{base.Name}, {base.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
