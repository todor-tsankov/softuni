using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        private const string SOUND = "DJAAF";
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ExplainSelf())
              .AppendLine(SOUND);

            return sb.ToString()
                     .Trim();
        }
    }
}
