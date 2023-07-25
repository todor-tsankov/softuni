using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            double counter200 = 0;
            double counter399 = 0;
            double counter599 = 0;
            double counter799 = 0;
            double counter800 = 0;

            for (int i = 0; i < n; i++)
            {
                double currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 200)
                {
                    counter200++;
                }
                else if (currentNumber <= 399)
                {
                    counter399++;
                }
                else if (currentNumber <= 599)
                {
                    counter599++;
                }
                else if (currentNumber <= 799)
                {
                    counter799++;
                }
                else 
                {
                    counter800++;
                }
            }

            double double1 = counter200 * 100 / n;
            double double2 = counter399 * 100 / n;
            double double3 = counter599 * 100 / n;
            double double4 = counter799 * 100 / n;
            double double5 = counter800 * 100 / n;

            Console.WriteLine($"{double1:f2}%");
            Console.WriteLine($"{double2:f2}%");
            Console.WriteLine($"{double3:f2}%");
            Console.WriteLine($"{double4:f2}%");
            Console.WriteLine($"{double5:f2}%");
        }
    }
}
