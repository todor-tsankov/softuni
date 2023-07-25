using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribonacciSequnece
{
    class TribonacciSequnece
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(TriabonacciSequnece()[i] + " ");
            }
        }

        static int[] TriabonacciSequnece()
        {
            int[] triabonacci = new int[100];
            triabonacci[0] = 1;
            triabonacci[1] = 1;
            triabonacci[2] = 2;

            for (int i = 3; i < 100; i++)
            {
                triabonacci[i] = triabonacci[i - 1] + triabonacci[i - 2] + triabonacci[i - 3];
            }

            return triabonacci;
        }
    }
}
