namespace P03Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DEFAULT_POWER = 100;
        public Warrior(string name) 
            : base(name, DEFAULT_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {base.Name} hit for {base.Power} damage";
        }
    }
}
