using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            ReadInputCars(cars,n);

            var command = Console.ReadLine();
            PrintResult(cars, command);
        }

        private static void PrintResult(List<Car> cars, string command)
        {
            Func<Car, bool> firstCheck;
            Func<Car, bool> secondCheck;

            if (command == "fragile")
            {
                firstCheck = c => c.Cargo.Type == "fragile";
                secondCheck = c => c.Tires.Any(t => t.Pressure < 1);
            }
            else
            {
                firstCheck = c => c.Cargo.Type == "flamable";
                secondCheck = c => c.Engine.Power > 250;
            }

            cars.Where(firstCheck)
                .Where(secondCheck)
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }

        private static void ReadInputCars(List<Car> cars, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var currentCarInfo = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = currentCarInfo[0];

                var engineSpeed = double.Parse(currentCarInfo[1]);
                var enginePower = double.Parse(currentCarInfo[2]);

                var engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = double.Parse(currentCarInfo[3]);
                var cargoType = currentCarInfo[4];

                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new List<Tire>();

                AddTires(currentCarInfo, tires);

                var currentCar = new Car(model, engine, cargo, tires);

                cars.Add(currentCar);
            }
        }

        private static void AddTires(string[] currentCarInfo, List<Tire> tires)
        {
            for (int j = 5; j <= 12; j += 2)
            {
                var tirePressure = double.Parse(currentCarInfo[j]);
                var tireAge = int.Parse(currentCarInfo[j + 1]);

                var currentTire = new Tire(tirePressure, tireAge);

                tires.Add(currentTire);
            }
        }
    }
}
