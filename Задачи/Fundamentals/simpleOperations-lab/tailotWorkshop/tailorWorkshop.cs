using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tailotWorkshop
{
    class TailorWorkshop
    {
        static void Main()
        {
            double numTables = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double area = numTables * (length + 2 * 0.30) * (width + 2 * 0.30);
            double area2 = numTables * (length / 2) * (length / 2);
            double price = area * 7;
            double price2 = area2 * 9;

            double finalPrice = price + price2;
            double priceLeva = finalPrice * 1.85;

            Console.WriteLine(finalPrice.ToString("0.00") +" USD");
            Console.WriteLine(priceLeva.ToString("0.00") + " BGN");

        }
    }
}
