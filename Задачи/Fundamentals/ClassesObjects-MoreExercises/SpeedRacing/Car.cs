using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    class Car
    {
        public Car(string[] informationParts)
        {
            Model = informationParts[0];
            FuelAmount = double.Parse(informationParts[1]);
            FuelConsumptionPerKM = double.Parse(informationParts[2]);
            TraveledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKM { get; set; }
        public double TraveledDistance { get; set; }

        public bool CanTheCarMove(double desiredDistance)
        {
            if (desiredDistance * FuelConsumptionPerKM <= FuelAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
