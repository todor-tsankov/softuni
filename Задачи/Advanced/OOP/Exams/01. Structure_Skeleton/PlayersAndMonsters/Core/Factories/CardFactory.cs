using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            if (nameof(MagicCard).StartsWith(type))
            {
                card = new MagicCard(name);
            }
            else if (nameof(TrapCard).StartsWith(type))
            {
                card = new TrapCard(name);
            }

            return card;
        }
    }
}
