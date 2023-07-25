using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity <= tankCapacity)
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.tankCapacity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException();
            }

            this.FuelQuantity -= neededFuel;
        }

        public virtual void DriveEmpty(double distance)
        {
        }

        public abstract void Refuel(double litres);
    }
}
