using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceFoodPerDay = double.Parse(Console.ReadLine());
            double priceSouvenirsPerDay = double.Parse(Console.ReadLine());
            double priceHotelPerDay = double.Parse(Console.ReadLine());

            double totalFirst = priceFoodPerDay * 3 + priceHotelPerDay * 0.9 + priceHotelPerDay * 0.85 + priceHotelPerDay * 0.8 + priceSouvenirsPerDay * 3;
            double totalLitres = 420.0 / 100.0 * 7.0;
            double totalTravel = totalLitres * 1.85;
            double total = totalFirst + totalTravel;

            Console.WriteLine($"Money needed: {total:f2}");
        }
    }
}
