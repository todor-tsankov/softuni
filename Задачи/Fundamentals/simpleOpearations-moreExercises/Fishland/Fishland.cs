using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishland
{
    class Fishland
    {
        static void Main(string[] args)
        {
            double priceMackerel = double.Parse(Console.ReadLine());
            double priceSprat = double.Parse(Console.ReadLine());
            double kilosPalm = double.Parse(Console.ReadLine());
            double kilosHorse = double.Parse(Console.ReadLine());
            double kilosMussels = double.Parse(Console.ReadLine());

            double pricePalm = priceMackerel * 1.6;
            double priceHorse = priceSprat * 1.8;
            double priceMussels = 7.5;

            double totalPalm = kilosPalm * pricePalm;
            double totalHorse = kilosHorse * priceHorse;
            double totalMussels = kilosMussels * priceMussels;
            double total = totalHorse + totalPalm + totalMussels;

            Console.WriteLine(total.ToString("0.00"));
        }
    }
}
