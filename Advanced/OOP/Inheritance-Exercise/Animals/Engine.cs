using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        private const string END_COMMAND = "Beast!";
        private List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            ReadInputAnimals();

            animals.ForEach(Console.WriteLine);
        }

        private void ReadInputAnimals()
        {
            while (true)
            {
                var animalType = Console.ReadLine();

                if (animalType == END_COMMAND)
                {
                    break;
                }

                var animalInfoArgs = Console.ReadLine()
                                            .Split();

                try
                {
                    var currentAnimal = CreateAnimal(animalInfoArgs, animalType);

                    animals.Add(currentAnimal);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private Animal CreateAnimal(string[] animalInfoArgs, string animalType)
        {
            var name = animalInfoArgs[0];
            var age = int.Parse(animalInfoArgs[1]);

            Animal animal = null;

            if (animalType == "Cat")
            {
                var gender = animalInfoArgs[2];

                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Dog")
            {
                var gender = animalInfoArgs[2];

                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                var gender = animalInfoArgs[2];

                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
