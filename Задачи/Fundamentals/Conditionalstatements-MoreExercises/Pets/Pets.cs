using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    class Pets
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodLeftKilos = int.Parse(Console.ReadLine());
            double dogFoodPerDay = double.Parse(Console.ReadLine());
            double catFoodPerDay = double.Parse(Console.ReadLine());
            double turtleFoodPerDay = double.Parse(Console.ReadLine()) / 1000;

            double totalFoodNeeded = (dogFoodPerDay + catFoodPerDay + turtleFoodPerDay) * days;
            double diff = Math.Abs(totalFoodNeeded - foodLeftKilos);

            if (totalFoodNeeded <=foodLeftKilos)
            {
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");
            }

        }
    }
}
