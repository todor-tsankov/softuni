using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doubleFloat
{
    class Program
    {
        static void Main(string[] args)
        {

            int a;
            int b;

            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            bool greaterA = (a > b);
            bool greaterB = (a < b);
            bool equal = (a == b);

            if (greaterA)
            {
                Console.WriteLine("A is bigger");
            }
            else if (greaterB)
            {
                Console.WriteLine("B is bigger");
            }
            else
            {
                Console.WriteLine("A and B are equal");
            }
        }
    }
}
