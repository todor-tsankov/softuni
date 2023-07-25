using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numForDogs = Int32.Parse(Console.ReadLine());
            int numOther = Int32.Parse(Console.ReadLine());
            Double costDogs = numForDogs * 2.5;
            Double costOther = numOther * 4;
            Double price = costDogs + costOther;
            Console.WriteLine($"{price.ToString("0.00")} lv.");

            
        }
    }
}
