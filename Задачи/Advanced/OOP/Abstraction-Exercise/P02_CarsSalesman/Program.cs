using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        static void Main()
        {

            var engineCount = int.Parse(Console.ReadLine());
            var engines = ReadEngines(engineCount);

            int carCount = int.Parse(Console.ReadLine());
            var cars = ReadCars(engines, carCount);

            PrintResult(cars);
        }

        private static List<Engine> ReadEngines(int engineCount)
        {
            var engines = new List<Engine>();

            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = parameters[0];
                var power = int.Parse(parameters[1]);

                var displacement = -1;

                Engine currentEngine = CreateEngine(parameters, model, power, ref displacement);
                engines.Add(currentEngine);
            }

            return engines;
        }

        private static Engine CreateEngine(string[] parameters, string model, int power, ref int displacement)
        {
            Engine currentEngine;
            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                currentEngine = new Engine(model, power, displacement);
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];

                currentEngine = new Engine(model, power, efficiency);
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];

                currentEngine = new Engine(model, power, int.Parse(parameters[2]), efficiency);
            }
            else
            {
                currentEngine = new Engine(model, power);
            }

            return currentEngine;
        }

        private static List<Car> ReadCars(List<Engine> engines, int carCount)
        {
            var cars = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = parameters[0];
                var engineModel = parameters[1];
                var engine = engines.FirstOrDefault(x => x.Model == engineModel);

                Car currentCar  = CreateCar(parameters, model, engine);
                cars.Add(currentCar);
            }

            return cars;
        }

        private static Car CreateCar(string[] parameters, string model, Engine engine)
        {
            Car currentCar;
            if (parameters.Length == 3 && int.TryParse(parameters[2], out int weight))
            {
                currentCar = new Car(model, engine, weight);
            }
            else if (parameters.Length == 3)
            {
                var color = parameters[2];

                currentCar = new Car(model, engine, color);
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];

                currentCar = new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                currentCar = new Car(model, engine);
            }

            return currentCar;
        }

        private static void PrintResult(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

    }

}
