using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxNumberOfElements = 0;
            int value = 0;
            int counter = 1;

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] == array[i-1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter >= maxNumberOfElements)
                {
                    maxNumberOfElements = counter;
                    value = array[i];
                }
            }

            for (int i = 0; i < maxNumberOfElements; i++)
            {
                Console.Write(value + " ");

            }

            Console.WriteLine();
        }
    }
}
