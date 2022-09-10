using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterNumber
{
    class GreaterNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if (number>number2)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(number2);
            }
        }
    }
}
