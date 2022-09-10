using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSuntaxMoreExrcises
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());

            if (x1 >= x2 && x2 >= x3)
            {
                Console.WriteLine(x1);
                Console.WriteLine(x2);
                Console.WriteLine(x3);
            }
            else if (x1 >= x3 && x3 >= x2)
            {
                Console.WriteLine(x1);
                Console.WriteLine(x3);
                Console.WriteLine(x2);
            }
            else if (x2 >= x3 && x3 >= x1)
            {
                Console.WriteLine(x2);
                Console.WriteLine(x3);
                Console.WriteLine(x1);
            }
            else if (x2 >= x1 && x1 >= x3)
            {
                Console.WriteLine(x2);
                Console.WriteLine(x1);
                Console.WriteLine(x3);
            }
            else if (x3 >= x2 && x2 >= x1)
            {
                Console.WriteLine(x3);
                Console.WriteLine(x2);
                Console.WriteLine(x1);
            }
            else if (x3 >= x1 && x1 >= x2)
            {
                Console.WriteLine(x3);
                Console.WriteLine(x1);
                Console.WriteLine(x2);
            }

        }
    }
}
