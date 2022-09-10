using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            if (FindsDistanceOfLine(x1, y1 , x2, y2) >= FindsDistanceOfLine(x3, y3, x4, y4))
            {
                if (FindsTheDistanceToCenetr(x1, y1) <= FindsTheDistanceToCenetr(x2, y2))
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (FindsTheDistanceToCenetr(x3, y3) <= FindsTheDistanceToCenetr(x4, y4))
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }


        }

        static double FindsTheDistanceToCenetr(double x1, double y1)
        {
            double distance = Math.Abs(x1) + Math.Abs(y1);
            return distance;
        }

        static double FindsDistanceOfLine(double x1, double y1, double x2, double y2)
        {
            double distance = 0;
            double a = 0;
            double b = 0;

            if (x1 > x2)
            {
                a = x1 - x2;
            }
            else
            {
                a = x2 - x1;
            }

            a = Math.Abs(a);

            if (y1 > y2)
            {
                b = y1 - y2;
            }
            else
            {
                b = y2 - y1;
            }

            b = Math.Abs(b);

            distance = Math.Sqrt(a * a + b * b);
            return distance;
        }
    }
}
