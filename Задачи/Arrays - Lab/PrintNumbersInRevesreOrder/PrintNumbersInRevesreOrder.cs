using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbersInRevesreOrder
{
    class PrintNumbersInRevesreOrder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int j = 0; j < n; j++)
            {
                numbers[j] = int.Parse(Console.ReadLine());
            }

            for (int i = n; i > 0; i--)
            {
                Console.Write(numbers[i-1] + " ");
            }
        }
    }
}
