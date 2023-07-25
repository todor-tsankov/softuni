namespace P03Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DEFAULT_POWER = 80;
        public Druid(string name) 
            : base(name, DEFAULT_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {base.Name} healed for {base.Power}";
        }
    }
}
