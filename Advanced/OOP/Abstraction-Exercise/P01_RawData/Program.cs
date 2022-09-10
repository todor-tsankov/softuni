using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    
    public class RawData
    {
        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var cars = ReadInputCars(numberOfLines);

            var command = Console.ReadLine();
            Func<Car, bool> filter = FilterSwitch(command);

            cars.Where(filter)
                .Select(car => car.Model)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static Func<Car, bool> FilterSwitch(string command)
        {
            Func<Car, bool> filter;
            if (command == "fragile")
            {
                filter = car => car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.Pressure < 1);
            }
            else
            {
                filter = car => car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250;
            }

            return filter;
        }

        public static List<Car> ReadInputCars(int lines)
        {
            var cars = new List<Car>();

            for (int i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                var engine = CreateEngine(parameters);
                var cargo = CreateCargo(parameters);
                var tires = CreateTires(parameters);

                var currentCar = new Car(model, engine, cargo, tires);
                cars.Add(currentCar);
            }

            return cars;
        }
        public static Engine CreateEngine(string[] parameters)
        {
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            return new Engine(engineSpeed, enginePower);
        }

        public static Cargo CreateCargo(string[] parameters)
        {
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            return new Cargo(cargoWeight, cargoType);
        }

        public static List<Tire> CreateTires(string[] parameters)
        {
            var tires = new List<Tire>();

            for (int i = 5; i <= 11; i += 2)
            {
                double currentPressure = double.Parse(parameters[i]);
                int currentAge = int.Parse(parameters[i + 1]);

                var currentTire = new Tire(currentAge, currentPressure);

                tires.Add(currentTire);
            }

            return tires;
        }
    }
}
