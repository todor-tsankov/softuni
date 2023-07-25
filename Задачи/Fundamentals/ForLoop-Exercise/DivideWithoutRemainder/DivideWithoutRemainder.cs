using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideWithoutRemainder
{
    class DivideWithoutRemainder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double counter2 = 0;
            double counter3 = 0;
            double counter4 = 0;

            for (int i = 0; i < n; i++)
            {
                double current = double.Parse(Console.ReadLine());

                if (current % 2 == 0)
                {
                    counter2++;
                }
                if (current % 3 == 0)
                {
                    counter3++;
                }
                if (current % 4 == 0)
                {
                    counter4++;
                }
            }

            counter2 = counter2 * 100 / n;
            counter3 = counter3 * 100 / n;
            counter4 = counter4 * 100 / n;

            Console.WriteLine($"{counter2:f2}%");
            Console.WriteLine($"{counter3:f2}%");
            Console.WriteLine($"{counter4:f2}%");
        }
    }
}
