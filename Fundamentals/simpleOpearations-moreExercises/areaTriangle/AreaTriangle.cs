using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace areaTriangle
{
    class AreaTriangle
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = (a * h) / 2;
            Console.WriteLine(area.ToString("0.00"));
        }
    }
}
