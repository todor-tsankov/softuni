namespace P03Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int DEFAULT_POWER = 80;

        public Rogue(string name) 
            : base(name, DEFAULT_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {base.Name} hit for {base.Power} damage";
        }
    }
}
