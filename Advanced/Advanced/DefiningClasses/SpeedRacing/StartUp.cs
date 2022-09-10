using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            ReadInputCars(cars, n);
            DriveCars(cars);

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.TravelledDistance}"));
        }

        private static void DriveCars(List<Car> cars)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[1];
                var amountOfKm = double.Parse(carInfo[2]);

                cars.Find(c => c.Model == model).Drive(amountOfKm);
            }
        }

        private static void ReadInputCars(List<Car> cars, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var currentCarInfo = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = currentCarInfo[0];
                var fuelAmount = double.Parse(currentCarInfo[1]);
                var fuelConsumptionFor1km = double.Parse(currentCarInfo[2]);

                var currentCar = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(currentCar);
            }
        }
    }
}
