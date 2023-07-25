using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangle2DArea
{
    class Rectangle2DArea
    {
        static void Main()
        {
            double x1, y1, x2, y2;
            x1 = double.Parse(Console.ReadLine());
            y1 = double.Parse(Console.ReadLine());
            x2 = double.Parse(Console.ReadLine());
            y2 = double.Parse(Console.ReadLine());

            double a = Math.Abs(x1 - x2);
            double b = Math.Abs(y1 - y2);

            double area = a * b;
            double peri = (a + b) * 2;

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{peri:f2}");

        }
    }
}
