using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousePainting
{
    class HousePainting
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double frontWalls = (x * x * 2) - (1.2 * 2);
            double sideWalls = (x * y * 2) - (1.5 * 1.5 *2);
            double greenArea = frontWalls + sideWalls;
            double greenPaint = greenArea / 3.4;

            double roofTop = x * y * 2;
            double roffSides = x * h;
            double redArea = roofTop + roffSides;
            double redPaint = redArea / 4.3;

            Console.WriteLine(greenPaint.ToString("0.00"));
            Console.WriteLine(redPaint.ToString("0.00"));

        }
    }
}
