using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPrimeNonPrime
{
    class SumPrimeNonPrimeProgram
    {
        static void Main(string[] args)
        {
            string numInString = "-1";
            double primeSum = 0;
            double nonPrimeSum = 0;

            while (numInString != "stop")
            {
               
                double n = int.Parse(numInString);

                if (n < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (n % 2 == 0 && n % 3 == 0 && n % 5 == 0 && n != 2 && n != 3 && n != 5)
                {
                    primeSum += n;
                }
                else
                {
                    nonPrimeSum += n;
                }

                numInString = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
