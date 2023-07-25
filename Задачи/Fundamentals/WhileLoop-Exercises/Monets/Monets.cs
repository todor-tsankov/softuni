using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monets
{
    class Monets
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            double rest = sum;
            double monetCount = 0;
            int counter = 0;
            double devider = 2;

            while (rest != 0)
            {
                if (counter == 3)
                {
                    devider = 0.2;
                }
                if (counter == 6)
                {
                    devider = 0.02;
                }

                monetCount += (int)(rest / devider);
                rest = rest % devider;
                counter++;
                devider /= 2;
                rest = Math.Round(rest, 2);

            }

            Console.WriteLine(monetCount);
        }
    }
}
