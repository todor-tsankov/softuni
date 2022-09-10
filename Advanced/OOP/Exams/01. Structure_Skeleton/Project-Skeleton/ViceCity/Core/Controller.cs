using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private ICollection<IPlayer> civilPllayers;
        private Queue<IGun> guns;

        public Controller()
        {
            this.guns = new Queue<IGun>();
            this.mainPlayer = new MainPlayer();
            this.civilPllayers = new List<IPlayer>();
        }

        public string AddGun(string type, string name)
        {
            IGun gun;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Enqueue(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (!this.guns.Any())
            {
                return "There are no guns in the queue!";
            }

            var gun = this.guns.Dequeue();

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var player = this.civilPllayers.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            this.civilPllayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var gangNeighbourhood = new GangNeighbourhood();

            gangNeighbourhood.Action(this.mainPlayer, this.civilPllayers);

            var sb = new StringBuilder();

            if (this.mainPlayer.LifePoints == 100 && this.civilPllayers.All(c => c.LifePoints == 50))
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine($"A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {this.civilPllayers.Where(p => !p.IsAlive).Count()} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPllayers.Where(p => p.IsAlive).Count()}!");
            }

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
