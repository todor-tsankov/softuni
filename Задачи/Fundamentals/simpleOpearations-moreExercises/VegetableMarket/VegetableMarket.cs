using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            int kilosVegetables = Int16.Parse(Console.ReadLine());
            int kilosFruit = Int16.Parse(Console.ReadLine());

            double earningsVegetables = priceVegetables * kilosVegetables / 1.94;
            double earningsFruit = priceFruit * kilosFruit / 1.94;
            double total = earningsVegetables + earningsFruit;

            Console.WriteLine(total.ToString("0.00"));
        }
    }
}
