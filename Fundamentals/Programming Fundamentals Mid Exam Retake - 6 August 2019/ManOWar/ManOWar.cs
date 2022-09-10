using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManOWar
{
    class ManOWar
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maximumHealthCapacity = int.Parse(Console.ReadLine());
            string command = string.Empty;
            bool battleIsOver = false;

            while ((command = Console.ReadLine()) != "Retire" && !battleIsOver)
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Fire")
                {
                    int index = int.Parse(commandParts[1]);
                    int damage = int.Parse(commandParts[2]);
                    battleIsOver = Fire(index, damage, warShip);
                }
                else if (operation == "Defend")
                {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);
                    int damage = int.Parse(commandParts[3]);
                    battleIsOver = Defend(startIndex, endIndex, damage, pirateShip);
                }
                else if (operation == "Repair")
                {
                    int index = int.Parse(commandParts[1]);
                    int health = int.Parse(commandParts[2]);
                    Repair(index, health, pirateShip, maximumHealthCapacity);
                }
                else if (operation == "Status")
                {
                    Status(pirateShip, maximumHealthCapacity);
                }
            }

            if (!battleIsOver)
            {
                int pirateShipSum = 0;
                int warShipSum = 0;

                pirateShip.ForEach(i => pirateShipSum += i);
                warShip.ForEach(i => warShipSum += i);

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }

        }

        static bool Fire(int index, int damage, List<int> warShip)
        {
            if (index >= 0 && index < warShip.Count)
            {
                warShip[index] -= damage;

                if (warShip[index] <= 0)
                {
                    Console.WriteLine("You won! The enemy ship has sunken.");
                    return true;
                }
            }

            return false;
        }
        static bool Defend(int startIndex, int endIndex, int damage, List<int> pirateShip)
        {
            int validStart = Math.Min(startIndex, endIndex);
            int validEnd = Math.Max(startIndex, endIndex);

            if (validStart < 0 || validEnd >= pirateShip.Count)
            {
                return false;
            }

            for (int i = validStart; i <= validEnd; i++)
            {
                pirateShip[i] -= damage;

                if (pirateShip[i] <= 0)
                {
                    Console.WriteLine("You lost! The pirate ship has sunken.");
                    return true;
                }

            }

            return false;
        }
        static void Repair(int index, int health, List<int> pirateShip, int maximumHealthCapacity)
        {
            if (index > 0 || index < pirateShip.Count)
            {
                if (pirateShip[index] + health <= maximumHealthCapacity)
                {
                    pirateShip[index] += health;
                }
            }
        }
        static void Status(List<int> pirateShip, int maximumHealthCapacity)
        {
            int counter = 0;

            foreach (var section in pirateShip)
            {
                if (section < maximumHealthCapacity * 0.2)
                {
                    counter++;
                }
            }

            Console.WriteLine($"{counter} sections need repair.");
        }
    }
}
