using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new List<List<Tire>>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            ReadInputTires(tires);
            ReadInputEngines(engines);
            ReadInputCars(tires, engines, cars);

            FindAndPrintSpecialCars(cars);
        }

        private static void FindAndPrintSpecialCars(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var currentCar = cars[i];

                if (IsSpecial(currentCar))
                {
                    currentCar.Drive(20);

                    PrintCarInfo(currentCar);
                }
            }
        }

        private static void PrintCarInfo(Car currentCar)
        {
            var printInfo = new StringBuilder();

            printInfo.AppendLine($"Make: {currentCar.Make}");
            printInfo.AppendLine($"Model: {currentCar.Model}");
            printInfo.AppendLine($"Year: {currentCar.Year}");
            printInfo.AppendLine($"HorsePowers: {currentCar.Engine.HorsePower}");
            printInfo.AppendLine($"FuelQuantity: {currentCar.FuelQuantity}");

            Console.WriteLine(printInfo.ToString());
        }

        private static bool IsSpecial(Car currentCar)
        {
            var tiresTotalPressure = currentCar.Tires.Select(i => i.Pressure)
                                                     .Sum();

            return currentCar.Year >= 2017 && currentCar.Engine.HorsePower > 330 && tiresTotalPressure > 9 && tiresTotalPressure < 10;
        }

        private static void ReadInputCars(List<List<Tire>> tires, List<Engine> engines, List<Car> cars)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = carInfo[0];
                var model = carInfo[1];
                var year = int.Parse(carInfo[2]);

                var fuelQuantity = double.Parse(carInfo[3]);
                var fuelConsumption = double.Parse(carInfo[4]);

                var engineIndex = int.Parse(carInfo[5]);
                var tiresIndex = int.Parse(carInfo[6]);

                var currentEngine = engines[engineIndex];

                var currentTires = new Tire[]
                {
                    tires[tiresIndex][0],
                    tires[tiresIndex][1],
                    tires[tiresIndex][2],
                    tires[tiresIndex][3]
                };

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, currentEngine, currentTires);

                cars.Add(currentCar);
            }
        }

        private static void ReadInputEngines(List<Engine> engines)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                var engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }
        }

        private static void ReadInputTires(List<List<Tire>> tires)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                var tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                tires.Add(new List<Tire>());

                for (int i = 0; i < tiresInfo.Length - 1; i += 2)
                {
                    var year = int.Parse(tiresInfo[i]);
                    var pressure = double.Parse(tiresInfo[i + 1]);
                    var tiresLen = tires.Count;

                    tires[tiresLen - 1].Add(new Tire(year, pressure));
                }
            }
        }
    }
}
