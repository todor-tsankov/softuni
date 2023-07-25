using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussTrick
{
    class GaussTrick
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> sumOfNumbers = new List<int>();
            int count = numbers.Count;

            for (int i = 0; i < count / 2; i++)
            {
                    sumOfNumbers.Add(numbers[i] + numbers[count - i - 1]);
            }

            if (count % 2 != 0)
            {
                sumOfNumbers.Add(numbers[count / 2]);
            }

            foreach (int item in sumOfNumbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
