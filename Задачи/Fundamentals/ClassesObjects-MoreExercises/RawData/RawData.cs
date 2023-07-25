using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] carInformation = Console.ReadLine().Split();
                listOfCars.Add(new Car(carInformation));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in listOfCars)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in listOfCars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
