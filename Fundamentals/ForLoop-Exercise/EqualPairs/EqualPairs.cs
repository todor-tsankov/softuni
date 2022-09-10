using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPairs
{
    class EqualPairs
    {
        static void Main(string[] args)
        {
            int numberOfPairs = int.Parse(Console.ReadLine());
            double first = 0;
            double second = 0;
            double lastSum = 0;
            double sum = 0;
            double diff = 0;
            int counter = 0;
            

            for (int i = 0; i < numberOfPairs; i++)
            {
                first = double.Parse(Console.ReadLine());
                second = double.Parse(Console.ReadLine());
                sum = first + second;
                if (lastSum == 0)
                {

                }
                else if ( sum == lastSum)
                {
                    counter++;
                }
                else if (Math.Abs(sum-lastSum) > diff)
                {
                    diff = Math.Abs(sum - lastSum);
                }

                lastSum = sum;
                
            }

            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
