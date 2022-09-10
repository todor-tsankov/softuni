using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Coding
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            

            for (int i = number.Length; i > 0; i--)
            {
                string digit = string.Empty;
                digit += number[i - 1];
                int n = int.Parse(digit) + 33;

                if (n != 33)
                {
                    for (int j = 0; j < n - 33; j++)
                    {
                        Console.Write((char)n);
                    }
                }
                else
                {
                    Console.Write("ZERO");
                }

                Console.Write($"\n");

            }
        }
    }
}
