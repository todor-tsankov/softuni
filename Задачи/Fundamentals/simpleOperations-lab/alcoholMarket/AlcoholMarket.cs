using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholMarket
{
    class Program
    {
        static void Main()
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double beerLitres = double.Parse(Console.ReadLine());
            double wineLitres = double.Parse(Console.ReadLine());
            double brendyLitres = double.Parse(Console.ReadLine());
            double whiskeyLitres = double.Parse(Console.ReadLine());

            double priceBrendy = 0.5 * priceWhiskey;
            double priceBeer = 0.2 * priceBrendy;
            double priceWine = 0.6 * priceBrendy;

            double finalBrendy = priceBrendy * brendyLitres;
            double finalBeer = priceBeer * beerLitres;
            double finalWine = priceWine * wineLitres;
            double finalWhiskey = priceWhiskey * whiskeyLitres;

            double finalPrice = finalBeer + finalBrendy + finalWhiskey + finalWine;
            Console.WriteLine(finalPrice.ToString("0.00"));





        }
    }
}
