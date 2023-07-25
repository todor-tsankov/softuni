using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FeedTheAnimals
{
    class P05FeedTheAnimals
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> animals = new Dictionary<string, int>();
            Dictionary<string, int> areas = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while (command != "Last Info")
            {
                string[] commandArgs = command.Split(':');

                string commmandType = commandArgs[0];
                string animalName = commandArgs[1];
                int food = int.Parse(commandArgs[2]);
                string area = commandArgs[3];

                if (!areas.ContainsKey(area))
                {
                    areas[area] = 0;
                }

                if (commmandType == "Add")
                {
                    if (!animals.ContainsKey(animalName))
                    {
                        animals[animalName] = 0;
                        areas[area]++;
                    }

                    animals[animalName] += food;
                }
                else if (commmandType == "Feed")
                {
                    if (animals.ContainsKey(animalName))
                    {
                        animals[animalName] -= food;

                        if (animals[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animals.Remove(animalName);
                            areas[area]--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            var sortedAnimals = animals.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            Console.WriteLine("Animals:");

            foreach (var ani in sortedAnimals)
            {
                Console.WriteLine($"{ani.Key} -> {ani.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            var sortedAreas = areas.Where(i => i.Value > 0).OrderByDescending(i => i.Value);

            foreach (var ar in sortedAreas)
            {
                Console.WriteLine($"{ar.Key} : {ar.Value}");
            }
        }
    }
}
