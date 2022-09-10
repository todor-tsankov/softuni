using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celsius_Fahrenhait
{
    class CelsiusFahrenheit
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = celsius * 1.8 + 32.0;
            Console.WriteLine(fahrenheit.ToString("0.00"));
        }
    }
}
