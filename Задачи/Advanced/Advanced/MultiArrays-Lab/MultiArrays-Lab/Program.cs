using System;
using System.Linq;

namespace MultiArrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine()
                                        .Split(", ")
                                        .Select(int.Parse)
                                        .ToArray();

            var rows = rowsAndColumns[0];
            var cols = rowsAndColumns[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currenRow = Console.ReadLine()
                                       .Split(", ")
                                       .Select(int.Parse)
                                       .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currenRow[col];
                }
            }

            var sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
