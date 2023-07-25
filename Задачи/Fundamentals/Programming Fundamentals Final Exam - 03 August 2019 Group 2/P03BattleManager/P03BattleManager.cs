using System;
using System.Collections.Generic;
using System.Linq;

namespace P03BattleManager
{
    class P03BattleManager
    {
        static void Main(string[] args)
        {
            Dictionary<string, Soldier> soldiers = new Dictionary<string, Soldier>();
            string command = Console.ReadLine();

            while (command != "Results")
            {
                string[] commandParts = command.Split(':');
                string typeCmd = commandParts[0];

                if (typeCmd == "Add")
                {
                    string personName = commandParts[1];
                    int health = int.Parse(commandParts[2]);
                    int energy = int.Parse(commandParts[3]);

                    if (!soldiers.ContainsKey(personName))
                    {
                        soldiers[personName] = new Soldier(health, energy);
                    }
                    else
                    {
                        soldiers[personName].Health += health;
                    }

                }
                else if (typeCmd == "Attack")
                {
                    string attackerName = commandParts[1];
                    string defenderName = commandParts[2];
                    int damage = int.Parse(commandParts[3]);

                    if (soldiers.ContainsKey(attackerName) && soldiers.ContainsKey(defenderName))
                    {
                        soldiers[defenderName].Health -= damage;
                        soldiers[attackerName].Energy--;

                        if (soldiers[defenderName].Health <= 0)
                        {
                            soldiers.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        if (soldiers[attackerName].Energy <= 0)
                        {
                            soldiers.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (typeCmd == "Delete")
                {
                    string username = commandParts[1];

                    if (username == "All")
                    {
                        soldiers.Clear();
                    }
                    else
                    {
                        soldiers.Remove(username);
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"People count: {soldiers.Count}");

            var sortedSoldiers = soldiers.OrderByDescending(i => i.Value.Health)
                                         .ThenBy(i => i.Key);

            foreach (var soldier in sortedSoldiers)
            {
                string name = soldier.Key;
                int healht = soldier.Value.Health;
                int energy = soldier.Value.Energy;

                Console.WriteLine($"{name} - {healht} - {energy}");
            }
        }
    }

    class Soldier
    {
        public Soldier(int health, int energy)
        {
            Health = health;
            Energy = energy;
        }
        public int Health { get; set; }
        public int Energy { get; set; }
    }
}
