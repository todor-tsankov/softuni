using System;
using System.Collections.Generic;
using System.Text;

namespace CarSelesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();

            var n = int.Parse(Console.ReadLine());

            ReadEngines(engines, n);

            n = int.Parse(Console.ReadLine());

            ReadCars(engines, n, cars);

            var printResult = CarsToString(cars);

            Console.WriteLine(printResult);
        }

        private static string CarsToString(List<Car> cars)
        {
            var result = new StringBuilder();

            foreach (var car in cars)
            {
                var engine = car.Engine;

                result.AppendLine($"{car.Model}:");
                result.AppendLine($"  {engine.Model}:");
                result.AppendLine($"    Power: {engine.Power}");
                result.AppendLine($"    Displacement: {engine.Displacement}");
                result.AppendLine($"    Efficiency: {engine.Efficiency}");
                result.AppendLine($"  Weight: {car.Weight}");
                result.AppendLine($"  Color: {car.Color}");
            }

            return result.ToString();
        }

        private static void ReadCars(List<Engine> engines, int n, List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineModel = carInfo[1];

                var engine = engines.Find(e => e.Model == engineModel);

                var currentCar = new Car(model, engine);

                if (carInfo.Length == 3)
                {
                    if (double.TryParse(carInfo[2], out double result))
                    {
                        currentCar.Weight = carInfo[2];
                    }
                    else
                    {
                        currentCar.Color = carInfo[2];
                    }
                }

                if (carInfo.Length == 4)
                {
                    currentCar.Weight = carInfo[2];
                    currentCar.Color = carInfo[3];
                }

                cars.Add(currentCar);
            }
        }

        private static void ReadEngines(List<Engine> engines, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = engineInfo[1];

                var currentEngine = new Engine(model, power);

                if (engineInfo.Length == 3)
                {
                    if (double.TryParse(engineInfo[2], out double result))
                    {
                        currentEngine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        currentEngine.Efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    currentEngine.Displacement = engineInfo[2];
                    currentEngine.Efficiency = engineInfo[3];
                }

                engines.Add(currentEngine);
            }
        }
    }
}
