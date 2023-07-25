using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            string[] numberString = Console.ReadLine().Split();

            for (int i = 0; i < numberString.Length; i++)
            {
                Console.Write(double.Parse(numberString[i]) + " => ");
                Console.WriteLine( Math.Round(double.Parse(numberString[i]), MidpointRounding.AwayFromZero));
            }
        }
    }
}
