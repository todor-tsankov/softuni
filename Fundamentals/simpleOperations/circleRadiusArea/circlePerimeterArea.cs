using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circleRadiusArea
{
    class circlePerimeterArea
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            Double r = Double.Parse(Console.ReadLine());
            Double perimeter = 2 * r * pi;
            Double area = pi * r * r;
            perimeter = Math.Round(perimeter, 2);
            area = Math.Round (area, 2);
            Console.WriteLine(area);
            Console.WriteLine(perimeter);

        }
    }
}
