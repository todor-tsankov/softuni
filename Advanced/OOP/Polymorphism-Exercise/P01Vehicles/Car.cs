using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double ADDITIONAL_SUMMER_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.FuelConsumption += ADDITIONAL_SUMMER_CONSUMPTION;
        }

        public override void Drive(double distance)
        {
            try
            {
                base.Drive(distance);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Car needs refueling");
            }
        }

        public override void Refuel(double litres)
        {
            if (litres <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (base.FuelQuantity + litres > base.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litres} fuel in the tank");
            }

            base.FuelQuantity += litres;
        }

        public override string ToString()
        {
            return $"Car: {base.FuelQuantity:f2}";
        }
    }
}
