using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            var first = CreateVehicle();
            var second = CreateVehicle();
            var third = CreateVehicle();

            SwitchVehicles(first, second, third, out Car car, out Bus bus, out Truck truck);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandInfo = ReadInputLine();

                var cmdType = commandInfo[0];
                var vehicle = commandInfo[1];
                var amount = double.Parse(commandInfo[2]);

                try
                {
                    SwitchCommand(car, bus, truck, cmdType, vehicle, amount);

                    if (cmdType == "Drive" || cmdType == "DriveEmpty")
                    {
                        Console.WriteLine($"{vehicle} travelled {amount} km");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void SwitchCommand(Car car, Bus bus, Truck truck, string cmdType, string vehicle, double amount)
        {
            if (vehicle == "Car")
            {
                ExecuteCommand(car, cmdType, amount);
            }
            else if (vehicle == "Truck")
            {
                ExecuteCommand(truck, cmdType, amount);
            }
            else if (vehicle == "Bus")
            {
                ExecuteCommand(bus, cmdType, amount);
            }
        }

        private static void SwitchVehicles(Vehicle first, Vehicle second, Vehicle third, out Car car, out Bus bus, out Truck truck)
        {
            if (first is Car)
            {
                car = (Car)first;
            }
            else if (second is Car)
            {
                car = (Car)second;
            }
            else
            {
                car = (Car)third;
            }

            if (first is Truck)
            {
                truck = (Truck)first;
            }
            else if (second is Truck)
            {
                truck = (Truck)second;
            }
            else
            {
                truck = (Truck)third;
            }

            if (first is Bus)
            {
                bus = (Bus)first;
            }
            else if (second is Bus)
            {
                bus = (Bus)second;
            }
            else
            {
                bus = (Bus)third;
            }
        }

        private static void ExecuteCommand(Vehicle vehicle, string cmdType, double amount)
        {
            if (cmdType == "Drive")
            {
                vehicle.Drive(amount);
            }
            else if (cmdType == "Refuel")
            {
                vehicle.Refuel(amount);
            }
            else if (cmdType == "DriveEmpty")
            {
                vehicle.DriveEmpty(amount);
            }
        }

        public Vehicle CreateVehicle()
        {
            var vehicleInfo = ReadInputLine();

            var type = vehicleInfo[0];

            var fuelQuantity = double.Parse(vehicleInfo[1]);
            var fuelConsumption = double.Parse(vehicleInfo[2]);
            var tankCapacity = double.Parse(vehicleInfo[3]);

            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }

        private static string[] ReadInputLine()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }
    }
}
