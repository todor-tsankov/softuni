using P04WildFarm.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04WildFarm.Core
{
    public class Engine
    {
        private readonly List<Animal> animals = new List<Animal>();

        public void Run()
        {
            while (true)
            {
                var animalInfoArgs = ReadInputLine();

                if (animalInfoArgs[0] == "End")
                {
                    break;
                }

                Animal currentanimal = CreateAnimal(animalInfoArgs);
                Console.WriteLine(currentanimal.ProduceSound());

                animals.Add(currentanimal);

                var foodInfoArgs = ReadInputLine();

                var foodType = foodInfoArgs[0];
                var quantity = int.Parse(foodInfoArgs[1]);

                try
                {
                    currentanimal.Feed(foodType, quantity);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }

        private static string[] ReadInputLine()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }

        private static Animal CreateAnimal(string[] animalInfoArgs)
        {
            Animal currentAnimal = null;

            var type = animalInfoArgs[0];
            var name = animalInfoArgs[1];
            var weight = double.Parse(animalInfoArgs[2]);

            if (type == "Owl")
            {
                var wingSize = double.Parse(animalInfoArgs[3]);

                currentAnimal = new Owl(name, weight, 0, wingSize);
            }
            else if (type == "Hen")
            {
                var wingSize = double.Parse(animalInfoArgs[3]);

                currentAnimal = new Hen(name, weight, 0, wingSize);
            }
            else if (type == "Mouse")
            {
                var livingRegion = animalInfoArgs[3];

                currentAnimal = new Mouse(name, weight, 0, livingRegion);
            }
            else if (type == "Dog")
            {
                var livingRegion = animalInfoArgs[3];

                currentAnimal = new Dog(name, weight, 0, livingRegion);
            }
            else if (type == "Cat")
            {
                var livingRegion = animalInfoArgs[3];
                var breed = animalInfoArgs[4];

                currentAnimal = new Cat(name, weight, 0, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                var livingRegion = animalInfoArgs[3];
                var breed = animalInfoArgs[4];

                currentAnimal = new Tiger(name, weight, 0, livingRegion, breed);
            }

            return currentAnimal;
        }
    }
}
