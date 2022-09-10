using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            var playerCards = new CardRepository();

            if (type == nameof(Beginner))
            {
                player = new Beginner(playerCards, username);
            }
            else if (type == nameof(Advanced))
            {
                player = new Advanced(playerCards, username);
            }

            return player;
        }
    }
}
