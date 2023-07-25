using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxN
{
    class NxN
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintsMatrixNxN(n);
        }

        static void PrintsMatrixNxN(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
