using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCataloge
{
    class VehicleCataloge
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();
            string command = string.Empty;
            int horseAverageCars = 0;
            int horseAverageTrucks = 0;
            int counterCars = 0;
            int counterTrucks = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();
                string type = commandParts[0].ToLower();
                string model = commandParts[1];
                string color = commandParts[2].ToLower();
                int horsePower = int.Parse(commandParts[3]);

                if (type == "car")
                {
                    horseAverageCars += horsePower;
                    counterCars++;
                    catalogue.Add(new Vehicle("Car", model, color, horsePower));

                }
                else if (type == "truck")
                {
                    horseAverageTrucks += horsePower;
                    counterTrucks++;
                    catalogue.Add(new Vehicle("Truck", model, color, horsePower));
                }

            }

            string modelCar = string.Empty;

            while ((modelCar = Console.ReadLine()) != "Close the Catalogue")
            {
                int indexInCatalogue = catalogue.FindIndex(i => i.Model == modelCar);

                Console.WriteLine($"Type: {catalogue[indexInCatalogue].Type}");
                Console.WriteLine($"Model: {catalogue[indexInCatalogue].Model}");
                Console.WriteLine($"Color: {catalogue[indexInCatalogue].Color}");
                Console.WriteLine($"Horsepower: {catalogue[indexInCatalogue].HorsePower}");
            }

            if (horseAverageCars > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {horseAverageCars * 1.0 / counterCars:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (horseAverageTrucks > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {horseAverageTrucks * 1.0 / counterTrucks:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

    }

}
