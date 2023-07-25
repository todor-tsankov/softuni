using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoop_Exercise
{
    class NumbersEndingIn7
    {
        static void Main()
        {

            for (int i = 0; i <= 99 ; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(7);
                }
                else
                {
                    Console.WriteLine($"{i}7");
                }
            }
        }
    }
}
