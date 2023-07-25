using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());

            if (IsResultPositive(x1, x2, x3) == 1)
            {
                Console.WriteLine("positive");
            }
            else if(IsResultPositive(x1, x2, x3) == -1)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("zero");
            }
        }

        static int IsResultPositive(double x1, double x2, double x3)
        {
            int counter = 0;

            if (x1 < 0)
            {
                counter++;
            }

            if (x2 < 0)
            {
                counter++;
            }

            if (x3 < 0)
            {
                counter++;
            }

            if (x1 == 0 || x2 == 0 || x3 == 0)
            {
                return 0;
            }

            if (counter % 2 != 0)
            {
                return - 1;
            }

            return 1;
        }
    }
}
