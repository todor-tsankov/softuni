using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvenNumbers
{
    class SumEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbersInt = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < numbersInt.Length; i++)
            {
                if (numbersInt[i] % 2 == 0)
                {
                    sum += numbersInt[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
