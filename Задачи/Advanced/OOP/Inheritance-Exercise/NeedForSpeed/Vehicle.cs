﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

            this.DefaultFuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption => this.DefaultFuelConsumption;

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            var exhaustedFuel = this.FuelConsumption * kilometers;

            this.Fuel -= exhaustedFuel;
        }
    }
}
