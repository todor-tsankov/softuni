namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DEFAULT_GENDER = "Male";
        private const string SOUND = "MEOW";

        public Tomcat(string name, int age)
            : base(name, age, DEFAULT_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return SOUND;
        }
    }
}