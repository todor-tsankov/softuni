namespace Animals
{
    public class Frog : Animal
    {
        private const string SOUND = "Ribbit";

        public Frog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return SOUND;
        }
    }
}
