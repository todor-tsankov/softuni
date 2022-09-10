using System.Linq;
using System.Collections.Generic;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            var guns = mainPlayer.GunRepository.Models.ToList();

            foreach (var person in civilPlayers)
            {
                if (!guns.Any())
                {
                    break;
                }

                while (person.IsAlive)
                {
                    if (!guns.Any())
                    {
                        break;
                    }

                    var gun = guns.First();

                    if (!gun.CanFire)
                    {
                        guns.Remove(gun);

                        continue;
                    }

                    var bullets = gun.Fire();
                    person.TakeLifePoints(bullets);
                }
            }

            foreach (var person in civilPlayers)
            {
                if (!person.IsAlive)
                {
                    continue;
                }

                guns = person.GunRepository.Models.ToList();

                while (mainPlayer.IsAlive)
                {
                    if (!guns.Any())
                    {
                        break;
                    }

                    var gun = guns.First();

                    if (!gun.CanFire)
                    {
                        guns.Remove(gun);

                        continue;
                    }

                    var bullets = gun.Fire();
                    mainPlayer.TakeLifePoints(bullets);
                }
            }
        }
    }
}
