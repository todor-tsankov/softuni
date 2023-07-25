using System;
using System.Linq;

using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using System.Collections.Generic;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            BonusCheck(attackPlayer);
            BonusCheck(enemyPlayer);

            HealthBonus(attackPlayer);
            HealthBonus(enemyPlayer);

            var counter = 0;

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                if (counter % 2 == 0)
                {
                    Attack(attackPlayer, enemyPlayer);
                }
                else
                {
                    Attack(enemyPlayer, attackPlayer);
                }

                counter++;
            }
        }

        private static void Attack(IPlayer attcker, IPlayer attacked)
        {
            var damage = attcker.CardRepository.Cards.Sum(c => c.DamagePoints);

            attacked.TakeDamage(damage);
        }

        private static void HealthBonus(IPlayer attackPlayer)
        {
            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }
        }

        private static void BonusCheck(IPlayer player)
        {
            if (player.GetType() == typeof(Beginner))
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
