using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    class ToyShop
    {
        static void Main()
        {
            double priceTrip = double.Parse(Console.ReadLine());
            int numPuzzles = int.Parse(Console.ReadLine()); 
            int numDolls = int.Parse(Console.ReadLine()); 
            int numBears = int.Parse(Console.ReadLine()); 
            int numMinions = int.Parse(Console.ReadLine()); 
            int numTrucks = int.Parse(Console.ReadLine());

            double pricePuzzles = numPuzzles * 2.60;
            double priceDolls = numDolls * 3.00;
            double priceBears = numBears * 4.10;
            double priceMinions = numMinions * 8.20;
            double priceTrucks = numTrucks * 2.00;

            int numberToys = numTrucks + numPuzzles + numMinions + numDolls + numBears;
            double total = priceBears + priceDolls + priceMinions + pricePuzzles + priceTrucks;
            if (numberToys >= 50)
            {
                total*= 0.75;
            }

            double earnings = total * 0.9;
            double moneyLeft = earnings - priceTrip;
            if (earnings >= priceTrip)
            {
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                moneyLeft = Math.Abs(moneyLeft);
                Console.WriteLine($"Not enough money! {moneyLeft:f2} lv needed.");
            }

        }
    }
}
