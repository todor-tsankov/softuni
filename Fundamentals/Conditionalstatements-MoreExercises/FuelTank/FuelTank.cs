using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelTank
{
    class FuelTank
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double litres = double.Parse(Console.ReadLine());

            if (litres >= 25)
            {
                switch (fuelType)
                {
                    case "Diesel":                        
                    case "Gasoline":                        
                    case "Gas":
                        Console.WriteLine($"You have enough {fuelType.ToLower()}.");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;
                }
            }
            else if (litres < 25)
            {     switch (fuelType)
                {
                    case "Diesel":
                    case "Gasoline":
                    case "Gas":
                        Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;
                }
            }
        }   
    }
}
