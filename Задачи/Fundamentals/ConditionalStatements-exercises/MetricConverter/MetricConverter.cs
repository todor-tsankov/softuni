using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class MetricConverter
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "m")
            {
                if (outputUnit == "cm")
                {
                    number = number * 100;
                }
                else
                {
                    number = number * 1000;
                }
            }
            else if (inputUnit == "cm")
            {
                if(outputUnit == "m")
                {
                    number = number / 100.0;
                }
                else
                {
                    number = number * 10.0;
                }
            }
            else
            {
                if (outputUnit == "m")
                {
                    number = number / 1000.0;
                }
                else
                {
                    number = number / 10.0;
                }
            }

            Console.WriteLine($"{number:f3}");

        }
    }
}
