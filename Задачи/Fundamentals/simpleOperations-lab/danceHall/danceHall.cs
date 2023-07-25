using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceHall
{
    class DanceHall
    {
        static void Main()
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double areaHall = L * W;
            double areaWardrobe = A * A;
            double areaSit = areaHall * 0.1;

            double areaFree = areaHall - areaWardrobe - areaSit;
            double numberDancers = Math.Floor(areaFree / 0.7040);

            Console.WriteLine(numberDancers);
        }
    }
}
