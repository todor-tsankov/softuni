using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        private const string SOUND = "MEEOW";
        public Cat(string name, string favouriteFood) 
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
