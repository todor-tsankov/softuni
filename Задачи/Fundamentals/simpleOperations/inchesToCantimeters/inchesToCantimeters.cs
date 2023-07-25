using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inchesToCantimeters
{
    class inchesToCantimeters
    {
        static void Main(string[] args)
        {
            double inches = Double.Parse(Console.ReadLine());
            double canti = inches * 2.54;
            Double cantimeters = Math.Round(canti, 2);
            
            Console.WriteLine(cantimeters.ToString("0.00"));
        }
    }
}
