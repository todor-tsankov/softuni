using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] arrayStrings = Console.ReadLine().Split();

            for (int i = arrayStrings.Length -1; i >= 0; i--)
            {
                Console.Write(arrayStrings[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
