﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast2
{
    class WeatherForecast2
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            
            if (degrees>=26.0 && degrees<=35.0)
            {
                Console.WriteLine("Hot");
            }
            else if (degrees >= 20.1 && degrees <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (degrees >= 15 && degrees <= 20.0)
            {
                Console.WriteLine("Mild");
            }
            else if (degrees >= 12.0 && degrees <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (degrees >= 5.0 && degrees <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }

    }
}

