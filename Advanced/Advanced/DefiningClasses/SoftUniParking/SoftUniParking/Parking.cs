using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count { get => cars.Count; }

        public string AddCar(Car car)
        {
            var matchingCar = cars.FirstOrDefault(c => c.RegistrationNumber == car.RegistrationNumber);

            if (matchingCar != null)
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (carToRemove == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            var car = cars.First(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                var carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

                if (carToRemove != null)
                {
                    cars.Remove(carToRemove);
                }
            }
        }
    }
}
