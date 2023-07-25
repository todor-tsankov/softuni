using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average
{
    class Average
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            int counter = 0;
            double sum = 0;


            while ( numberOfNumbers > counter)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                counter++;
            }

            Console.WriteLine((sum / numberOfNumbers).ToString("f2"));

        }
    }
}
