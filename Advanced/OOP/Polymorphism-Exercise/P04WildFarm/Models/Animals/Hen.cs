namespace P04WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const string SOUND = "Cluck";
        private const double WEIGHT_GAIN_PER_PIECE = 0.35;
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void Feed(string foodType, int quantity)
        {
            base.FoodEaten += quantity;
            base.Weight += quantity * WEIGHT_GAIN_PER_PIECE;
        }

        public override string ProduceSound()
        {
            return SOUND;
        }
    }
}
