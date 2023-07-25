using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                string firstElement = inputArray[0];

                for (int j = 0; j  < inputArray.Length ; j++)
                {
                    if (j < inputArray.Length - 1)
                    {
                        inputArray[j] = inputArray[j + 1];
                    }
                    else 
                    {
                        inputArray[inputArray.Length - 1] = firstElement;
                    }
                    
                }
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.Write(inputArray[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
