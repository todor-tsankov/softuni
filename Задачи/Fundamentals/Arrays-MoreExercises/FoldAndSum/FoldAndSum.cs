using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;
            int length = array.Length;
            int[] firstRow = new int[length / 2];
            int[] secondRow = new int[length / 2];
            int counter = 0;

            for (int i = 0; i < length / 2; i++)
            {
                secondRow[i] = array[length / 4 + i];
            }

            for (int i = length / 4 - 1; i >= 0 ; i--)
            {
                firstRow[counter] = array[i];
                counter++;
            }

            for (int i = length -1; i >= length * 3 / 4; i--)
            {
                firstRow[counter] = array[i];
                counter++;
            }

            for (int i = 0; i < length / 2; i++)
            {
                Console.Write(firstRow[i] + secondRow[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
