using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZag
{
    class ZigZag
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstArray = new string[n];
            string[] secondArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] current = Console.ReadLine().Split();

                if (i % 2 == 0)
                {
                    firstArray[i] = current[0];
                    secondArray[i] = current[1];
                }
                else
                {
                    firstArray[i] = current[1];
                    secondArray[i] = current[0];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(firstArray[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(secondArray[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
