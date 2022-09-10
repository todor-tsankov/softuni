using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yardGreening
{
    class yardGreening
    {
        static void Main()
        {
            Double squareMeters = Double.Parse(Console.ReadLine() );
            Double price = squareMeters * 7.61;
            Double discount = price * 0.18;
            Double final = price - discount;

            Console.WriteLine($"The final price is: {final.ToString("0.00")} lv.");
            Console.WriteLine($"The discount is: {discount.ToString("0.00")} lv.");
        }
    }
}
