using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RecursiveFiabonacci
{
    class RecursiveFiabonacci
    {
        static void Main(string[] args)
        {
            BigInteger[] fiabonaciiSequence = new BigInteger[50];
            fiabonaciiSequence[0] = 1;
            fiabonaciiSequence[1] = 1;

            for (int i = 2; i < 50; i++)
            {
                fiabonaciiSequence[i] = fiabonaciiSequence[i - 2] + fiabonaciiSequence[i - 1];
            }

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(fiabonaciiSequence[n-1]);
        }
    }
}
