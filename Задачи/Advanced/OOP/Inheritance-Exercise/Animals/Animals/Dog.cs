namespace Animals
{
    public class Dog : Animal
    {
        private const string SOUND = "Woof!";

        public Dog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return SOUND;
        }
    }
}
