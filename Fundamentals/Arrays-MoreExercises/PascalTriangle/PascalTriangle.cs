using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] currentRow = new int[60];
            int[] nextRow = new int[60];
            nextRow[0] = 1;
            currentRow[0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < nextRow.Length; j++)
                {
                    if (nextRow[j] == 0)
                    {
                        break;
                    }
                    Console.Write(nextRow[j] + " ");
                }

                for (int j = 0; j < nextRow.Length; j++)
                {
                    currentRow[j] = nextRow[j];
                }

                for (int j = 1; j < 60; j++)
                {
                    nextRow[j] = currentRow[j - 1] + currentRow[j];
                }

                Console.WriteLine();

            }
        }
    }
}
