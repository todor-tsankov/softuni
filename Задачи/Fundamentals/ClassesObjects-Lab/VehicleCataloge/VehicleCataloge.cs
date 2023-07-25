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
            string command = string.Empty;
            Catalog catalog = new Catalog();
            catalog.Cars = new List<Car>();
            catalog.Trucks = new List<Truck>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParts = command.Split('/');

                    if (commandParts[0] == "Car")
                    {
                        catalog.Cars.Add(new Car(commandParts));
                    }
                    else
                    {
                        catalog.Trucks.Add(new Truck(commandParts));
                    }
            }

            catalog.Cars = catalog.Cars.OrderBy(i => i.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(i => i.Brand).ToList();

            if (catalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
            }

            foreach (var item in catalog.Cars)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
            }

            if (catalog.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
            }

            foreach (var item in catalog.Trucks)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }
        }
    }

    class Truck
    {
        public Truck(string[] commandParts)
        {
            Brand = commandParts[1];
            Model = commandParts[2];
            Weight = commandParts[3];
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    class Car
    {
        public Car(string[] commandParts)
        {
            Brand = commandParts[1];
            Model = commandParts[2];
            HorsePower = commandParts[3];
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class Catalog
    {

        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
