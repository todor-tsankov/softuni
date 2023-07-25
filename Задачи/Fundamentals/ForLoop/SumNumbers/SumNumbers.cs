using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = 0;
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
