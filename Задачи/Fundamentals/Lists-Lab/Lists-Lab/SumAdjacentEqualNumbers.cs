using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Lab
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            bool end = true;

            while (end)
            {
                end = false;

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] = numbers[i] * 2;
                        numbers.RemoveAt(i + 1);
                        end = true;
                    }
                }
            }

            foreach (double item in numbers)
            {
                Console.Write(item + " ");
            }
            
        }
    }
}
