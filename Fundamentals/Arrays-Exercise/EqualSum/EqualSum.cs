using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isThereSuchElement = false;

            for (int i = 0; i < intArray.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < intArray.Length; j++)
                {
                    if (j < i)
                    {
                        leftSum += intArray[j];
                    }
                    else if (j > i)
                    {
                        rightSum += intArray[j];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isThereSuchElement = true;
                    break;
                }
            }

            if (!isThereSuchElement)
            {
                Console.WriteLine("no");
            }
        }
    }
}
