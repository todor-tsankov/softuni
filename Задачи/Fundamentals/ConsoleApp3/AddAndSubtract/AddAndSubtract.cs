using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());

            int result = Subtract(x1, x2, x3);
            Console.WriteLine(result);
        }

        static int Sum(int x1, int x2)
        {
            return x1 + x2;
        }

        static int Subtract(int x1, int x2, int x3)
        {
            return Sum(x1, x2) - x3;
        }
    }
}
