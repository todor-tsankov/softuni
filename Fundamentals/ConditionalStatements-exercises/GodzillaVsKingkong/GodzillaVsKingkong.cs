using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodzillaVsKingkong
{
    class GodzillaVsKingkong
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberStatics = int.Parse(Console.ReadLine());
            double priceCloth1Static = double.Parse(Console.ReadLine());
            
            double decor = budget * 0.1;
            double totalPriceCloths = numberStatics * priceCloth1Static;

            if (numberStatics >= 150)
            {
                totalPriceCloths  = totalPriceCloths * 0.9;
            }
            double totalPrice = totalPriceCloths + decor;
            double moneyLeft = budget - totalPrice;

            if (budget >= totalPrice)                 
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(moneyLeft * (-1)):f2} leva more.");
            }
        }
    }
}
