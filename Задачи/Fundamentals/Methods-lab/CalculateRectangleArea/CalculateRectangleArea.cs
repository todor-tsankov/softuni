using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double area = RectangleArea(height, width);
            Console.WriteLine(area);
        }

        static double RectangleArea(double height, double width)
        {
            return height * width;
        }
    }
}
