using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double ADDITIONAL_SUMMER_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += ADDITIONAL_SUMMER_CONSUMPTION;
        }

        public override void Drive(double distance)
        {
            try
            {
                base.Drive(distance);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Truck needs refueling");
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

            base.FuelQuantity += 0.95 * litres;
        }

        public override string ToString()
        {
            return $"Truck: {base.FuelQuantity:f2}";
        }
    }
}
