using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualArrays
{
    class EqualArrays
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();
            bool equal = true;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    equal = false;
                    break;
                }
            }

            if (equal)
            {
                double sum = 0;

                for (int i = 0; i < firstArray.Length; i++)
                {
                    sum += double.Parse(firstArray[i]);
                }

                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
