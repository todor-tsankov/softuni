namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int InitialPoints = 50;

        public CivilPlayer(string name) 
            : base(name, InitialPoints)
        {
        }
    }
}
