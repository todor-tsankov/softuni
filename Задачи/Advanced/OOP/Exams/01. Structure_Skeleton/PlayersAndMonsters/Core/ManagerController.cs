namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;

        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            this.battleField = new BattleField();

            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();

            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                var playerInfo = string.Format(ConstantMessages.PlayerReportInfo, player.Username
                                                                                , player.Health
                                                                                , player.CardRepository.Count);

                sb.AppendLine(playerInfo);

                foreach (var card in player.CardRepository.Cards)
                {
                    var cardInfo = string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints);

                    sb.AppendLine(cardInfo);
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }


            return sb.ToString().TrimEnd();
        }
    }
}
