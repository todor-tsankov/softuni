using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop
{
    class FlowerShop
    {
        static void Main(string[] args)
        {
            int numMagnolia = int.Parse(Console.ReadLine());
            int numZyumbul = int.Parse(Console.ReadLine());
            int numRoses = int.Parse(Console.ReadLine());
            int numCactuses = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double profit = (numMagnolia * 3.25 + numZyumbul * 4 + numRoses * 3.5 + numCactuses * 8) * 0.95;
            double diff = Math.Abs(profit - giftPrice);

            if (profit >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(diff)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(diff)} leva.");
            }



        }
    }
}
