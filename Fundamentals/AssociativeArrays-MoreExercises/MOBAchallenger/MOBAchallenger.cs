using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAchallenger
{
    class MOBAchallenger
    {
        static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Season end")
                {
                    break;
                }

                if (input.Contains("->"))
                {
                    string[] inputParts = input.Split(" -> "); // " -> "
                    string player = inputParts[0];
                    string position = inputParts[1];
                    int skill = int.Parse(inputParts[2]);
                    int playerIndex = playerList.FindIndex(i => i.Name == player);

                    if (playerIndex < 0)
                    {
                        playerList.Add(new Player(player));
                        playerIndex = playerList.FindIndex(i => i.Name == player);
                    }

                    if (!playerList[playerIndex].PositionAndSkill.ContainsKey(position) 
                          || skill > playerList[playerIndex].PositionAndSkill[position])
                    {
                        playerList[playerIndex].PositionAndSkill[position] = skill;
                    }

                    playerList[playerIndex].TotalSkill = playerList[playerIndex].PositionAndSkill.Values.Sum();

                }
                else
                {
                    string[] inputParts = input.Split(" vs "); // " vs "
                    string firstPlayer = inputParts[0];
                    string secondPlayer = inputParts[1];
                    int firstIndex = playerList.FindIndex(i => i.Name == firstPlayer);
                    int secondIndex = playerList.FindIndex(i => i.Name == secondPlayer);

                    if (firstIndex < 0 || secondIndex < 0)
                    {
                        break;
                    }

                    if (AtLeastOneCommonPoisition(playerList[firstIndex], playerList[secondIndex]))
                    {
                        if (playerList[firstIndex].TotalSkill > playerList[secondIndex].TotalSkill)
                        {
                            playerList.RemoveAt(secondIndex);
                        }
                        else if (playerList[firstIndex].TotalSkill < playerList[secondIndex].TotalSkill)
                        {
                            playerList.RemoveAt(firstIndex);
                        }
                    }
                }
            }

            var filteredPlayers = playerList.OrderByDescending(i => i.TotalSkill).ThenBy(i => i.Name);

            foreach (var player in filteredPlayers)
            {
                Console.WriteLine($"{player.Name}: {player.TotalSkill} skill");
                var filteredPosiotions = player.PositionAndSkill.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

                foreach (var position in filteredPosiotions)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }

        static bool AtLeastOneCommonPoisition(Player first, Player second)
        {
            foreach (var position in first.PositionAndSkill)
            {
                foreach (var pos in second.PositionAndSkill)
                {
                    if (position.Key == pos.Key)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Player
    {
        public Player(string name)
        {
            Name = name;
            TotalSkill = 0;
            PositionAndSkill = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public int TotalSkill { get; set; }

        public Dictionary<string, int> PositionAndSkill { get; set; }

    }
}
