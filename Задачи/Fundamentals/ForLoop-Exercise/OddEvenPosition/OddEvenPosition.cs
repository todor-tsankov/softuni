using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenPosition
{
    class OddEvenPosition
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double evenSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNumber;

                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }
                }
                else
                {
                    oddSum += currentNumber;

                    if (currentNumber > oddMax)
                    {
                        oddMax = currentNumber;
                    }
                    if (currentNumber < oddMin)
                    {
                        oddMin = currentNumber;
                    }
                }

            }

            Console.WriteLine("OddSum=" + oddSum.ToString("f2") + ",");

            if (oddMax == double.MinValue && oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine("OddMin=" + oddMin.ToString("f2") + ",");
                Console.WriteLine("OddMax=" + oddMax.ToString("f2") + ",");
            }

            Console.WriteLine("EvenSum=" + evenSum.ToString("f2") + ",");

            if (evenMax == double.MinValue && evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("EvenMin=" + evenMin.ToString("f2") + ",");
                Console.WriteLine("EvenMax=" + evenMax.ToString("f2"));
            }
        }
    }
}
