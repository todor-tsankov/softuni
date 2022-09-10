using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radians_degrees
{
    class Program
    {
        static void Main()
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;
            double wholedeg = Math.Round(deg , 0);
            Console.WriteLine(wholedeg);
        }
    }
}
