using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelTank_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double quantityFuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            bool card = clubCard == "Yes";
            double totalPrice = quantityFuel;

            switch (fuelType)
            {
                case "Gas":                   
                    if (card)
                    {
                        totalPrice *= 0.85;
                    }
                    else
                    {
                        totalPrice *= 0.93;
                    }
                    break;
                case "Gasoline":
                    if (card)
                    {
                        totalPrice *= 2.04;
                    }
                    else
                    {
                        totalPrice *= 2.22;
                    }                    
                    break;
                case "Diesel":
                    if (card)
                    {
                        totalPrice *= 2.21; 
                    }
                    else 
                    {
                        totalPrice *= 2.33;
                    }
                    break;
            }

            if (quantityFuel >= 20 && quantityFuel <= 25)
            {
                totalPrice *= 0.92;
            }
            else if (quantityFuel > 25)
            {
                totalPrice *= 0.90;
            }

            Console.WriteLine($"{totalPrice:f2} lv.");


        }
    }
}

