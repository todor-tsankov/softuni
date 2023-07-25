using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> listCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfoParts = Console.ReadLine().Split();
                listCars.Add(new Car(carInfoParts));
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();
                string carModel = commandParts[1];
                double distance = double.Parse(commandParts[2]);
                int indexOfCar = listCars.FindIndex(i => i.Model == carModel);
                Car currentCar = listCars[indexOfCar];

                if (currentCar.CanTheCarMove(distance))
                {
                    currentCar.TraveledDistance += distance;
                    currentCar.FuelAmount -= distance * currentCar.FuelConsumptionPerKM;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in listCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
