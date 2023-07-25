using System;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double ADD_FUEL_CONSUMPTION = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + ADD_FUEL_CONSUMPTION, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            try
            {
                base.Drive(distance);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Bus needs refueling");
            }
        }

        public override void DriveEmpty(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption - ADD_FUEL_CONSUMPTION);

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException("Bus needs refueling");
            }

            this.FuelQuantity -= neededFuel;
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
            return $"Bus: {base.FuelQuantity:f2}";
        }
    }
}
