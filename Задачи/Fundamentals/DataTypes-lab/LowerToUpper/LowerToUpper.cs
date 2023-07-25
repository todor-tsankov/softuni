using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerToUpper
{
    class LowerToUpper
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.ToUpper() == input)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
