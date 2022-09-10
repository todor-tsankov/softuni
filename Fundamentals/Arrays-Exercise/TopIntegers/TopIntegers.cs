using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] arrayIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();
           

            for (int i = 0; i < arrayIntegers.Length; i++)
            {
                bool isBigger = true;

                for (int j = i + 1 ; j < arrayIntegers.Length; j++)
                {
                    if (arrayIntegers[i] <= arrayIntegers[j])
                    {
                        isBigger = false;
                    }
                }

                if (isBigger)
                {
                    Console.Write(arrayIntegers[i] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
