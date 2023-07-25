using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPyramid
{
    class NumberPyramid
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int i = 1;

            while (i <= n)
            {
                for (int g = 0; g < counter && i <= n; g++)
                {
                    Console.Write(i + " ");
                    i++;
                }

                counter++;
                Console.Write($"\n");
            }
        }
    }
}
